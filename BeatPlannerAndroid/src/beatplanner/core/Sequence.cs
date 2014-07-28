using System;

namespace BeatPlanner
{
  public class Sequence
  {
    public Beat Beat;
    public int Reps;

    public Sequence(Beat beat, int reps)
    {
      this.Beat = beat;
      this.Reps = reps;
    }
  }
}

