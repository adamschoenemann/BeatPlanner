//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.todo;


import dk.aschoen.beatplanner.core.Beat;
import dk.aschoen.beatplanner.core.Sequence;
//
//public class activity_track
//{
//    private final List<Sequence> sequences = new List<Sequence>();
//    public Sequence[] getSequences() throws Exception {
//        Sequence[] result = new Sequence[sequences.Count];
//        sequences.CopyTo(result);
//        return result;
//    }
//
//    public void appendSequence(Beat beat, int reps) throws Exception {
//        sequences.Add(new Sequence(beat,reps));
//    }
//
//    public void prependSequence(Beat beat, int reps) throws Exception {
//        sequences.Insert(0, new Sequence(beat,reps));
//    }
//
//    public void insertSequence(Beat Beat, int reps, int i) throws Exception {
//        sequences.Insert(i, new Sequence(Beat,reps));
//    }
//
//    // METER BPM REPS
//    // 4/4   180 4
//    private static Sequence parseSequence(String line) throws Exception {
//        String[] splits = line.Split(StringSplitOptions.RemoveEmptyEntries);
//        Beat beat = Beat.Parse(splits);
//        int reps = Integer.valueOf(splits[2]);
//        return new Sequence(beat,reps);
//    }
//
//    public static activity_track parse(String[] lines) throws Exception {
//        activity_track track = new activity_track();
//        Sequence seq;
//        for (int i = 0;i < lines.Length;i++)
//        {
//            seq = ParseSequence(lines[i]);
//            track.appendSequence(seq.beat,seq.reps);
//        }
//        return track;
//    }
//
//    public static activity_track parse(String input) throws Exception {
//        return Parse(input.Split(StringSplitOptions.RemoveEmptyEntries));
//    }
//
//    public String compose() throws Exception {
//        StringBuilder sb = new StringBuilder();
//        for (Object __dummyForeachVar0 : sequences)
//        {
//            Sequence seq = (Sequence)__dummyForeachVar0;
//            sb.AppendFormat("{0} {1} {2}{3}", seq.beat.Meter, seq.beat.BPM, seq.reps, Environment.NewLine);
//        }
//        return sb.ToString();
//    }
//
//    public void save(String path) throws Exception {
//        File.WriteAllText(path, compose());
//    }
//
//    public static activity_track load(String path) throws Exception {
//        String[] lines = File.ReadAllLines(path);
//        return Parse(lines);
//    }
//
//}


