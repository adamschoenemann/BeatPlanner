//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.core;

import java.util.ArrayList;

public class Track
{
    private final ArrayList<Sequence> sequences = new ArrayList<Sequence>();
    public Sequence[] getSequences() {
        Sequence[] result = new Sequence[sequences.size()];
        sequences.toArray(result);
        return result;
    }

    public void appendSequence(Beat beat, int reps) {
        sequences.add(new Sequence(beat, reps));
    }

    public void prependSequence(Beat beat, int reps) {
        sequences.add(0, new Sequence(beat, reps));
    }

    public void insertSequence(Beat beat, int reps, int i) {
        sequences.add(i, new Sequence(beat, reps));
    }

    // METER BPM REPS
    // 4/4   180 4
    private static Sequence parseSequence(String line) {
        String[] splits = line.split(" ");
        Beat beat = Beat.parse(splits);
        int reps = Integer.valueOf(splits[2]);
        return new Sequence(beat, reps);
    }

    public static Track parse(String[] lines) {
        Track track = new Track();
        Sequence seq;
        for (String line : lines) {
            seq = parseSequence(line);
            track.appendSequence(seq.getBeat(), seq.reps);
        }
        return track;
    }

    public static Track parse(String input) {
        return parse(input.split(" "));
    }

    public String compose() {
        StringBuilder sb = new StringBuilder();
        for (Object __dummyForeachVar0 : sequences)
        {
            Sequence seq = (Sequence)__dummyForeachVar0;
            sb.append(String.format("%s %d %d\n", seq.getBeat().getMeter(), seq.getBeat().getBPM(), seq.reps));
        }
        return sb.toString();
    }

}


