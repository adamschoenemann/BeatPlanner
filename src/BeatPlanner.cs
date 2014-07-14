using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace BeatPlanner
{
	public class Track
	{
		public List<IBar> Bars;
		// Maintains a mapping from bar index to tempo
		public Dictionary<int, ITempo> Tempos;
	}

	public interface ITempo
	{
		float Tempo { get; }
	}

	public interface IBar
	{
		IMeter Meter { get; }
	}

	public interface IMeter
	{
		int Lower { get; }

		int Upper { get; }
	}

	public class Meter
	{
		public readonly int Upper;
		public readonly int Lower;

		public Meter(int u, int l)
		{
			Upper = u;
			if (l == 2 || l == 4 || l == 8 || l == 16 || l == 32)
				Lower = l;
			else
				throw new ArgumentException("Invalid lower meter given");
		}

		public static readonly Meter Common = new Meter(4, 4);
	}

	public class Beat
	{
		public int BPM;
		public Meter Meter;

		public Beat(int BPM, Meter meter)
		{
			this.BPM = BPM;
			this.Meter = meter;
		}
	}

	public class BeatPlanner
	{
		private List<Tuple<Beat, int>> sequences = new List<Tuple<Beat, int>>();

		public void AppendSequence(Beat beat, int reps)
		{
			sequences.Add(new Tuple<Beat, int>(beat, reps));
		}

		public void Play()
		{
			Metronome metro = new Metronome();
			int i = 0;
			Tuple<Beat, int> seq = sequences[i];
			Beat beat = seq.Item1;
			int reps = seq.Item2;
			int nextChange = reps;
			metro.Beat = beat;
			metro.Start();
			while (true)
			{
				if (metro.Bars == nextChange)
				{
					if (i == sequences.Count - 1)
						break;
					seq = sequences[++i];
					beat = seq.Item1;
					reps = seq.Item2;
					metro.Beat = beat;
					nextChange += reps;
				}
			}
			metro.Stop();
		}

		public static void Main(string[] args)
		{
			BeatPlanner planner = new BeatPlanner();
			planner.AppendSequence(new Beat(80, Meter.Common), 4);
			planner.AppendSequence(new Beat(120, new Meter(3, 4)), 4);
			planner.AppendSequence(new Beat(200, new Meter(7, 8)), 4);
//			planner.AppendSequence(new Beat(40, Meter.Common), 4);

			planner.Play();



//			MetroTest(args);
		}

		public static void MetroTest(string[] args)
		{
			Console.WriteLine("Hello!");

			Metronome metro = new Metronome();
			// metro.Start();
			

			String read;
			while (true)
			{
				read = Console.ReadLine();
				switch (read)
				{
					case "q":
					case "quit":
						metro.Stop();
						return;

					case "stop":
						metro.Stop();
						break;

					case "start":
						metro.Start();
						break;

					case "reset":
						metro.Reset();
						break;

					case "restart":
						metro.Restart();
						break;

					case "bpm":
						string bpmstr = Console.ReadLine();
						int bpm = Convert.ToInt32(bpmstr);
						metro.Lock.EnterWriteLock();
						metro.Beat = new Beat(bpm, metro.Beat.Meter);
						metro.Lock.ExitWriteLock();
						// metro.BPM = bpm;
						break;

					case "beat":
						string beatstr = Console.ReadLine(); // e.g. 3/4
						string[] nums = beatstr.Split('/');
						int upper = Convert.ToInt32(nums[0]);
						int lower = Convert.ToInt32(nums[1]);
						// Console.WriteLine(upper);
						// Console.WriteLine(lower);
						metro.Lock.EnterWriteLock();
						metro.Beat = new Beat(metro.Beat.BPM, new Meter(upper, lower));
						metro.Lock.ExitWriteLock();
						break;

					default:
						break;
				}
			}
			
		}
	}
}
