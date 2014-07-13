using System;
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
			if(l == 2 || l == 4 || l == 8 || l == 16 || l == 32)
				Lower = l;
			else throw new ArgumentException("Invalid lower meter given");
		}

		public static readonly Meter Common = new Meter(4,4);
		
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
		public static void Main(string[] args)
		{
			List<Beat> beats = new List<Beat>();
			beats.Add(new Beat(80, Meter.Common));
			beats.Add(new Beat(120, Meter.Common));
			beats.Add(new Beat(200, Meter.Common));
			beats.Add(new Beat(40, Meter.Common));

			/*
			Metronome metro = new Metronome();
			int i = 0;
			Beat beat = beats[i];
			int nextChange = beat.Duration;
			metro.BPM = beat.BPM;
			metro.Start();
			while(true)
			{
				if(metro.Beats > nextChange)
				{
					if(i == beats.Count - 1)
						break;
					beat = beats[++i];
					metro.BPM = beat.BPM;
					nextChange += beat.Duration;
				}
			}
			metro.Stop();
			*/
			MetroTest(args);
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
						metro.Beat = new Beat(bpm, metro.Beat.Meter);
						// metro.BPM = bpm;
						break;

					case "beat":
						string beatstr = Console.ReadLine(); // e.g. 3/4
						string[] nums = beatstr.Split('/');
						int upper = Convert.ToInt32(nums[0]);
						int lower = Convert.ToInt32(nums[1]);
						// Console.WriteLine(upper);
						// Console.WriteLine(lower);
						metro.Beat = new Beat(metro.Beat.BPM, new Meter(upper, lower));
						break;

					default:
						break;
				}
			}
			
		}
	}
}
