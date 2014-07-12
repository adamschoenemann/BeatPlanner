using System;
using System.Diagnostics;
using System.Threading;

namespace BeatPlanner
{
	public class Metronome
	{
		private int bpm;
		public int BPM
		{
			get { return bpm; }
			set
			{
				bpm = value;
				beatDur = 60000 / bpm;
			}
		}
		private long lastBeat = 0;
		private long beatDur = 1000; // 60 bpm
		private Stopwatch sw;
		private Thread thread;

		private bool shouldStop = false;

		public Metronome()
		{
			sw = new Stopwatch();
		}

		public void Start()
		{
			sw.Start();
			thread = new Thread(Loop);
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
			if(thread.IsAlive)
			{
				Restart();
				return;
			}
			lastBeat = 0;
			sw.Reset();
		}

		public void Restart()
		{
			lastBeat = 0;
			sw.Restart();
		}

		private void Loop()
		{
			while (shouldStop == false)
			{
				Console.WriteLine(sw.ElapsedMilliseconds);
				if (sw.ElapsedMilliseconds - lastBeat > beatDur)
				{
					lastBeat = sw.ElapsedMilliseconds;
					SoundUtils.PlayBeep(440, 50);
				}
			}
			shouldStop = false;
		}
	}
}