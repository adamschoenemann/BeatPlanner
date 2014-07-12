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

	public class BeatPlanner
	{
		public static void Main(string[] args)
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

					default:
						break;
				}
			}
			
		}
	}
}
