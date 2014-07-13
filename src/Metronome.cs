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
		private int beats = 0;
		public int Beats {get {return beats;} private set {beats = value;}}

		private long lastBeat = 0;
		private long beatDur = 1000; // 60 bpm
		private Stopwatch sw;
		private Thread thread;
		private SoundPlayer player;

		private bool shouldStop = false;

		public Metronome()
		{
			sw = new Stopwatch();
			player = new SoundPlayer();
			Beats = 0;
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
			lastBeat = 0;
			Beats = 0;
			sw.Reset();
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
			while (shouldStop == false)
			{
				long elapsed = sw.ElapsedMilliseconds;
				if (elapsed - lastBeat >= beatDur)
				{
					Interlocked.Increment(ref beats);
					Console.WriteLine(elapsed + ", Beats: " + Beats);
					lastBeat = sw.ElapsedMilliseconds;
					player.PlayBeep(440, 50);
				}
			}
			shouldStop = false;
		}
	}
}