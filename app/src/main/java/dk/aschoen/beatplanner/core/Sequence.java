//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.core;


import dk.aschoen.beatplanner.core.Beat;

public class Sequence
{
    private Beat beat;
    public int reps;
    public Sequence(Beat beat, int reps) {
        this.beat = beat;
        this.reps = reps;
    }

    public Beat getBeat() {
        return beat;
    }
}


