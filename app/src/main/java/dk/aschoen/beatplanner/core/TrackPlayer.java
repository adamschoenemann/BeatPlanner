//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.core;



public class TrackPlayer
{
    private Metronome metro;
    private boolean shouldPlay = false;

    private int index;
    public int getIndex() {
        return index;
    }

    public final Track track;
    public TrackPlayer(Track track, Metronome metro) {
        this.track = track;
        this.metro = metro;
    }

    public TrackPlayer(Track track) {
        this(track, new Metronome());
    }

    public void playAsync() {
        Thread thread = new Thread(new Runnable() {
            @Override
            public void run() {
                play();
            }
        });
        thread.start();
    }

    public void stop() {
        shouldPlay = false;
    }

    public void reset() {
        index = 0;
    }

    public void play() {
        shouldPlay = true;
        Sequence[] sequences = track.getSequences();
        Sequence seq = sequences[getIndex()];
        Beat beat = seq.getBeat();
        int reps = seq.reps;
        int nextChange = reps;
        metro.setBeat(beat);
        metro.start();
        while (shouldPlay)
        {
            if (metro.getBars() == nextChange)
            {
                if (getIndex() == sequences.length - 1)
                    break;

                index++;
                seq = sequences[getIndex()];
                beat = seq.getBeat();
                reps = seq.reps;
                metro.setBeat(beat);
                nextChange += reps;
            }

        }
        metro.stop();
    }

}


