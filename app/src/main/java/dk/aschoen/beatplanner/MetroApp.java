//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner;

import android.app.Application;
import android.content.Context;
import android.media.AudioManager;
import android.media.SoundPool;
import android.util.Log;

import dk.aschoen.beatplanner.core.Metronome;

public class MetroApp extends Application
{

    @Override
    public void onCreate() {
        super.onCreate();
        Log.d(getClass().getSimpleName(), "MetroApp starting");
//        Console.WriteLine("MetroApp starting");
    }

    public static Metronome defaultMetronome(Context context) {
        Metronome metro = new Metronome();
        final SoundPool sp = new SoundPool(2, AudioManager.STREAM_MUSIC, 0);
        final int claveId = sp.load(context, R.raw.llfclave, 1);
        final int claveLowId = sp.load(context, R.raw.llfclave_low, 1);

        metro.OnBeatEvent(new Metronome.BeatEventHandler() {
            @Override
            public void handle(int index, int beats, int bars) {
                int sid;
                if (index == 1)
                    sid = claveId;
                else
                    sid = claveLowId;
                sp.play(sid, 1.0f, 1.0f, 1, 0, 1.0f);
            }
        });

        return metro;
    }

}


