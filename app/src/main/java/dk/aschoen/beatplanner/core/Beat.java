package dk.aschoen.beatplanner.core;

public class Beat
{
    public int BPM;
    public Meter meter;
    public Beat(Meter meter, int BPM) {
        this.BPM = BPM;
        this.meter = meter;
    }

    public static Beat parse(String[] splits) {
        String bpmStr = splits[1];
        int bpm = Integer.valueOf(bpmStr);
        String meterStr = splits[0];
        String[] meterSplits = meterStr.split("/");
        int upper = Integer.valueOf(meterSplits[0]);
        int lower = Integer.valueOf(meterSplits[1]);
        return new Beat(new Meter(upper,lower),bpm);
    }

    // METER BPM
    // 4/4   180
    public static Beat parse(String line) {
        String[] splits = line.split(" ");
        return parse(splits);
    }

}


