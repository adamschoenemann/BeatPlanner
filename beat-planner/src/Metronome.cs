using System;
using System.Diagnostics;
using System.Threading;
using System.Media;

namespace BeatPlanner
{
	public class Metronome
	{
		private class BeatEnumerator
		{
			public struct Info
			{
				public readonly int Index;
				public readonly long Duration;

				public Info(int i, long d)
				{
					Index = i;
					Duration = d;
				}
			}

			public readonly Beat Beat;
			private int index = 1;

			public BeatEnumerator(Beat beat)
			{
				this.Beat = beat;
			}

			public Info Next()
			{
				int retIndex = index;
				index++;
				if (index > Beat.Meter.Upper)
					index = 1;

				long fourthDur = 60000 / Beat.BPM;
				long dur = (long)(fourthDur * (4 / (float)Beat.Meter.Lower));

				return new Info(retIndex, dur);
			}
		}

		private int beats = 0;

		public int Beats { get { return beats; } private set { beats = value; } }

		private int bars = 0;

		public int Bars { get { return bars; } private set { bars = value; } }

		public Beat Beat
		{
			get { return bEnum.Beat; }
			set
			{
				bEnum = new BeatEnumerator(value);
			}
		}

		public int BPM
		{
			get { return Beat.BPM; }
			set
			{
				Beat.BPM = value;
			}
		}

		public Meter Meter
		{
			get { return Beat.Meter; }
			set { Beat = new Beat(value, Beat.BPM); }
		}
		// Not really used
		private Stopwatch sw;
		private Thread thread;
		private SoundPlayer accentSoundPlayer;
		private SoundPlayer soundPlayer;
		private BeatEnumerator bEnum;
		private bool shouldStop = false;

		public ReaderWriterLockSlim Lock { get; private set; }

		public Metronome(Beat beat, ISound sound, ISound accSound)
		{
			sw = new Stopwatch();
			bEnum = new BeatEnumerator(beat);
			soundPlayer = new SoundPlayer(sound.Stream);
			accentSoundPlayer = new SoundPlayer(accSound.Stream);
			Beats = 0;
			Lock = new ReaderWriterLockSlim();
		}

		public Metronome() : 
			this(new Beat(Meter.Common, 60), 
			     new BeepSound(440, 50, ushort.MaxValue / 2), 
			     new BeepSound(660, 50, ushort.MaxValue / 2))
		{

		}

		public void Start()
		{
			if (thread != null && thread.IsAlive) // already running
				return;
			thread = new Thread(Loop);
			thread.Priority = ThreadPriority.Highest;
			sw.Start();

			thread.Start();
		}

		public void Stop()
		{
			if (thread != null && thread.IsAlive)
			{
				sw.Stop();
				shouldStop = true;
				thread.Join();

				Console.WriteLine("Metronome stopped");
			}
				
		}

		public void Reset()
		{
			Beats = 0;
			Bars = 0;
			sw.Reset();
			bEnum = new BeatEnumerator(bEnum.Beat);
			if (thread.IsAlive)
			{
				sw.Start();
			}
		}

		public void Restart()
		{
			Reset();
			if (thread.IsAlive == false)
				Start();

		}

		private void Loop()
		{
			//Thread.Sleep(200); // HACK to get first beat audible
			BeatEnumerator.Info info;
			while (shouldStop == false)
			{
				Lock.EnterReadLock();
				info = bEnum.Next();
				Lock.ExitReadLock();
				if (info.Index == Beat.Meter.Upper)
					Interlocked.Increment(ref bars);
				Interlocked.Increment(ref beats);
				if (info.Index == 1)
					accentSoundPlayer.Play();
				else
					soundPlayer.Play();
				
				Console.WriteLine(sw.ElapsedMilliseconds + ", Index: " + info.Index + ", Bars: " + Bars);
				Thread.Sleep((int)info.Duration); // Not very accurate, unfortunately. Alternatives appear limited
			}
			shouldStop = false;
		}
	}
}