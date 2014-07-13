using System;
using System.Diagnostics;
using System.Threading;

namespace BeatPlanner
{

	public class BeatEnumerator
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
			if(index > Beat.Meter.Upper)
				index = 1;

			long fourthDur = 60000 / Beat.BPM;
			long dur = (long)(fourthDur * (4 / (float)Beat.Meter.Lower));

			return new Info(retIndex, dur);
		}
	}

	public class Metronome
	{

		private int beats = 0;
		public int Beats {get {return beats;} private set {beats = value;}}

		public Beat Beat
		{
			get { return bEnum.Beat; }
			set 
			{
				bEnum  = new BeatEnumerator(value);
			}
		}

		private Stopwatch sw;
		private Thread thread;
		private SoundPlayer player;
		private BeatEnumerator bEnum;

		private bool shouldStop = false;

		public Metronome(Beat beat)
		{
			sw = new Stopwatch();
			bEnum = new BeatEnumerator(beat);
			player = new SoundPlayer();
			Beats = 0;
		}

		public Metronome() : this(new Beat(60, Meter.Common))
		{

		}

		public void Start()
		{
			thread = new Thread(Loop);
			sw.Start();
			thread.Start();
		}

		public void Stop()
		{
			sw.Stop();
			shouldStop = true;
			thread.Join();
			Console.WriteLine("Metronome stopped");
		}

		public void Reset()
		{
			Beats = 0;
			sw.Reset();
			bEnum = new BeatEnumerator(bEnum.Beat);
			if(thread.IsAlive)
			{
				sw.Start();
			}
		}

		public void Restart()
		{
			Reset();
			sw.Start();
		}

		private void Loop()
		{
			//Thread.Sleep(200); // HACK to get first beat audible
			BeatEnumerator.Info info;
			while (shouldStop == false)
			{
				info = bEnum.Next();
				Interlocked.Increment(ref beats);
				player.PlayBeep((info.Index == 1 ? (ushort)660 : (ushort)440), 50);
				Console.WriteLine(sw.ElapsedMilliseconds + ", Index: " + info.Index);
				Thread.Sleep((int)info.Duration); // Not very accurate, unfortunately. Alternatives appear limited
			}
			shouldStop = false;
		}
	}
}