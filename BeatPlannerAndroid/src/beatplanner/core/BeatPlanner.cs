using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BeatPlanner
{

  public class Meter
  {
    public int Upper;
    public int Lower;

    public Meter(int u, int l)
    {
      Upper = u;
      if (l == 2 || l == 4 || l == 8 || l == 16 || l == 32)
        Lower = l;
      else
        throw new ArgumentException("Invalid lower meter given");
    }

    public override string ToString()
    {
      return string.Format("{0}/{1}", Upper, Lower);
    }

    public static readonly Meter Common = new Meter(4, 4);
  }

  public class Beat
  {
    public int BPM;
    public Meter Meter;

    public Beat(Meter meter, int BPM)
    {
      this.BPM = BPM;
      this.Meter = meter;
    }

    public static Beat Parse(string[] splits)
    {
      string bpmStr = splits[1];
      int bpm = Convert.ToInt32(bpmStr);

      string meterStr = splits[0];
      string[] meterSplits = meterStr.Split('/');
      int upper = Convert.ToInt32(meterSplits[0]);
      int lower = Convert.ToInt32((meterSplits[1]));

      return new Beat(new Meter(upper, lower), bpm);
    }
    // METER BPM
    // 4/4   180
    public static Beat Parse(string line)
    {
      string[] splits = line.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      return Parse(splits);

    }
  }


  public class BeatPlanner
  {
    public static void Main(string[] args)
    {
      Track track = Track.Load("assets/track1.txt");
      Metronome metro = new Metronome(
                          new Beat(Meter.Common, 60)
                        );

      TrackPlayer player = new TrackPlayer(track, metro);
      player.PlayAsync();
      String read = "";
      do
      {
        if (read == "stop")
        {
          player.Stop();
        }
        read = Console.ReadLine();
      } while (read != "q");
      player.Stop();
    }

    public static void LoadSaveTest(string[] args)
    {
      Track track = Track.Load("assets/track1.txt");
      TrackPlayer player = new TrackPlayer(track);
      track.Save("assets/track2.txt");
//			player.Play();
    }

    public static void ParseBeatTest(string[] args)
    {
      string input = Console.ReadLine();
      Metronome metro = new Metronome();

      while (input != "q")
      {
        Beat beat = Beat.Parse(input);
        metro.Beat = beat;
        metro.Start();
        while (metro.Bars < 2)
          ;
        metro.Stop();
        metro.Reset();
        input = Console.ReadLine();
      }
    }

    public static void TrackTest(string[] args)
    {
      Track track = new Track();
      TrackPlayer player = new TrackPlayer(track);
      track.AppendSequence(new Beat(Meter.Common, 80), 4);
      track.AppendSequence(new Beat(new Meter(3, 4), 120), 4);
      track.AppendSequence(new Beat(new Meter(7, 8), 200), 4);
      track.PrependSequence(new Beat(new Meter(5, 4), 160), 2);

      player.Play();
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
            metro.BPM = bpm;
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
            metro.Meter = new Meter(upper, lower);
            metro.Lock.ExitWriteLock();
            break;

          default:
            break;
        }
      }
			
    }
  }
}
