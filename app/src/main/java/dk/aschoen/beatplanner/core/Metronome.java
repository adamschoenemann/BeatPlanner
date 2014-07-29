//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.core;

import java.util.ArrayList;


public class Metronome
{

    private static class BeatEnumerator
    {
        public static class Info   
        {
            public final int index;
            public final long duration;
            public Info(int i, long d) {
                index = i;
                duration = d;
            }
        
        }

        public final Beat beat;
        private int index = 1;
        public BeatEnumerator(Beat beat) {
            this.beat = beat;
        }

        public Info next() {
            int retIndex = index;
            index++;
            if (index > beat.meter.upper)
                index = 1;
             
            long fourthDur = 60000 / beat.BPM;
            long dur = (long)(fourthDur * (4 / (float) beat.meter.lower));
            return new Info(retIndex,dur);
        }
    
    }

    private int beats = 0;
    public int getBeats() {
        return beats;
    }

    public void setBeats(int value) {
        beats = value;
    }

    private int bars = 0;
    public int getBars() {
        return bars;
    }

    public void setBars(int value) {
        bars = value;
    }

    public Beat getBeat() {
        return bEnum.beat;
    }

    public void setBeat(Beat value) {
        bEnum = new BeatEnumerator(value);
    }

    public int getBPM() {
        return getBeat().BPM;
    }


    public void setBPM(int value) {
        int oldBPM = getBeat().BPM;
        getBeat().BPM = value;
        for(BPMChangedHandler h : bpmChangedHandlers)
            h.handle(oldBPM, value);
    }

    public Meter getMeter() {
        return getBeat().meter;
    }

    public void setMeter(Meter value) {
        setBeat(new Beat(value,getBeat().BPM));
    }

    private Thread thread = new Thread();
    private BeatEnumerator bEnum;
    private boolean shouldStop = false;

    // -------------------------------------------------------- //
    public static interface BeatEventHandler {
        public void handle(int index, int beats, int bars);
    }
    private ArrayList<BeatEventHandler> beatEventHandlers = new ArrayList<BeatEventHandler>();
    public void OnBeatEvent(BeatEventHandler h) {
        beatEventHandlers.add(h);
    }

    // -------------------------------------------------------- //
    public static interface BPMChangedHandler {
        public void handle(int oldBPM, int newBPM);
    }
    private ArrayList<BPMChangedHandler> bpmChangedHandlers = new ArrayList<BPMChangedHandler>();
    public void onBPMChangedEvent(BPMChangedHandler h) {
        bpmChangedHandlers.add(h);
    }
    // -------------------------------------------------------- //



    public Metronome(Beat beat) {

        bEnum = new BeatEnumerator(beat);
        setBeats(0);
    }

    public Metronome() {
        this(new Beat(Meter.Common,60));
    }

    public boolean isPlaying() {
        return (thread != null && thread.isAlive());
    }

    public void start() {
        if (thread != null && thread.isAlive())
            return ;
         
        // already running
        thread = new Thread(new Runnable() {
            @Override
            public void run() {
                loop();
            }
        });
        thread.setPriority(Thread.MAX_PRIORITY);
        thread.start();
    }

    public boolean toggle() {
        if (isPlaying())
        {
            stop();
            return false;
        }
         
        start();
        return true;
    }

    public void stop() {
        if (thread != null && thread.isAlive())
        {
            shouldStop = true;
            try {
                thread.join();
            }
            catch (InterruptedException e){
                e.printStackTrace();
            }
        }
//            Console.WriteLine("Metronome stopped");

    }

    public void reset() {
        setBeats(0);
        setBars(0);
        bEnum = new BeatEnumerator(bEnum.beat);

    }

    public void restart() {
        reset();
        if (thread.isAlive() == false)
            start();
         
    }

    private void loop() {
        //Thread.Sleep(200); // HACK to get first beat audible
        Metronome.BeatEnumerator.Info info;
        while (shouldStop == false) {
            info = bEnum.next();
            if (info.index == getBeat().meter.upper) {
                bars++;
            }
            beats++;
            for(BeatEventHandler h : beatEventHandlers)
                h.handle(info.index, getBeats(), getBars());
             
//            Console.WriteLine(sw.ElapsedMilliseconds + ", index: " + info.index + ", Bars: " + getBars());
            try {
                Thread.sleep(info.duration);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        // Not very accurate, unfortunately. Alternatives appear limited
        shouldStop = false;
    }

}


