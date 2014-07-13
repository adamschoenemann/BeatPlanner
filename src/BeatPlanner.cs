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

	public class Beat
	{
		public int BPM;
		public int Duration;
		public Beat(int BPM, int duration)
		{
			this.BPM = BPM;
			this.Duration = duration;
		}
	}

	public class BeatPlanner
	{
		public static void Main(string[] args)
		{
			List<Beat> beats = new List<Beat>();
			beats.Add(new Beat(80, 8));
			beats.Add(new Beat(120, 8));
			beats.Add(new Beat(200, 4));
			beats.Add(new Beat(40, 4));

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
			// MetroTest(args);
		}

		public static void MetroTest(string[] args)
		{
			Console.WriteLine("Hello!");

			Metronome metro = new Metronome();
			metro.Start();
			

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
						metro.BPM = bpm;
						break;

					default:
						break;
				}
			}
			
		}
	}
}
