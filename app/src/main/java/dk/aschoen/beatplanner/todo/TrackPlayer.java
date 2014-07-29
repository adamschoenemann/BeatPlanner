//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.todo;


import dk.aschoen.beatplanner.core.Beat;
import dk.aschoen.beatplanner.core.Metronome;
import dk.aschoen.beatplanner.core.Sequence;

//public class TrackPlayer
//{
//    private Metronome metro;
//    private boolean shouldPlay = false;
//    private int __Index;
//    public int getIndex() {
//        return __Index;
//    }
//
//    public void setIndex(int value) {
//        __Index = value;
//    }
//
//    public final dk.aschoen.beatplanner.todo.activity_track activity_track;
//    public TrackPlayer(activity_track track, Metronome metro) throws Exception {
//        this.activity_track = track;
//        this.metro = metro;
//    }
//
//    public TrackPlayer(activity_track track) throws Exception {
//        this(track, new Metronome());
//    }
//
//    public void playAsync() throws Exception {
//        Thread thread = new Thread(Play);
//        thread.Start();
//    }
//
//    public void stop() throws Exception {
//        shouldPlay = false;
//    }
//
//    public void reset() throws Exception {
//        setIndex(0);
//    }
//
//    public void play() throws Exception {
//        shouldPlay = true;
//        Sequence[] sequences = activity_track.getSequences();
//        Sequence seq = sequences[getIndex()];
//        Beat beat = seq.beat;
//        int reps = seq.reps;
//        int nextChange = reps;
//        metro.setBeat(beat);
//        metro.start();
//        while (shouldPlay)
//        {
//            if (metro.getBars() == nextChange)
//            {
//                if (getIndex() == sequences.Length - 1)
//                    break;
//
//                seq = sequences[++getIndex()];
//                beat = seq.beat;
//                reps = seq.reps;
//                metro.setBeat(beat);
//                nextChange += reps;
//            }
//
//        }
//        metro.stop();
//    }
//
//}
//

