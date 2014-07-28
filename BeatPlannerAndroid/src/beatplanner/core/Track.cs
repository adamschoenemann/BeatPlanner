using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BeatPlanner
{


  public class Track
  {
    private readonly List<Sequence> sequences = new List<Sequence>();

    public Sequence[] Sequences
    {
      get
      {
        Sequence[] result = new Sequence[sequences.Count];
        sequences.CopyTo(result);
        return result;
      }
    }

    public void AppendSequence(Beat beat, int reps)
    {
      sequences.Add(new Sequence(beat, reps));
    }

    public void PrependSequence(Beat beat, int reps)
    {
      sequences.Insert(0, new Sequence(beat, reps));
    }

    public void InsertSequence(Beat Beat, int reps, int i)
    {
      sequences.Insert(i, new Sequence(Beat, reps));
    }
    // METER BPM REPS
    // 4/4   180 4
    private static Sequence ParseSequence(string line)
    {
      string[] splits = line.Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
      Beat beat = Beat.Parse(splits);
      int reps = Convert.ToInt32(splits[2]);
      return new Sequence(beat, reps);
    }

    public static Track Parse(string[] lines)
    {
      Track track = new Track();
      Sequence seq;
      for (int i = 0; i < lines.Length; i++)
      {
        seq = ParseSequence(lines[i]);
        track.AppendSequence(seq.Beat, seq.Reps);
      }
      return track;
    }

    public static Track Parse(string input)
    {
      return Parse(input.Split(new []{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public string Compose()
    {
      StringBuilder sb = new StringBuilder();
      foreach (Sequence seq in sequences)
      {
        sb.AppendFormat("{0} {1} {2}{3}", seq.Beat.Meter, seq.Beat.BPM, 
          seq.Reps, Environment.NewLine);
      }
      return sb.ToString();
    }

    public void Save(string path)
    {
      File.WriteAllText(path, Compose());
    }

    public static Track Load(string path)
    {
      string[] lines = File.ReadAllLines(path);
      return Parse(lines);
    }
  }

}

