//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui.activities;


import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;

import java.util.ArrayList;

import dk.aschoen.beatplanner.MetroApp;
import dk.aschoen.beatplanner.R;
import dk.aschoen.beatplanner.core.Metronome;
import dk.aschoen.beatplanner.core.Sequence;
import dk.aschoen.beatplanner.ui.widgets.SequenceView;

public class TrackActivity  extends Activity
{
    private Metronome __Metronome;
    public Metronome getMetronome() {
        return __Metronome;
    }

    public void setMetronome(Metronome value) {
        __Metronome = value;
    }

    private ArrayList<SequenceView> seqViews = new ArrayList<SequenceView>();
    protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);
        setMetronome(MetroApp.defaultMetronome(this));
        setContentView(R.layout.activity_track);
        LinearLayout cv = (LinearLayout) findViewById(R.id.trackRoot);
        for (int i = 0;i < cv.getChildCount();i++)
        {
            View v = cv.getChildAt(i);
            if (v instanceof SequenceView)
                addSequenceView((SequenceView)v);
             
        }
    }


    private void addSequenceView(final SequenceView v) {
        v.getPlayBtn().setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View sender) {
                Sequence s = v.getSequence();
                Button btn = (Button)sender;
                getMetronome().setBeat(s.getBeat());
                getMetronome().toggle();
                btn.setText(btn.getText().equals("Play") ? "Stop" : "Play");
            }
        });

        seqViews.add(v);
    }

}


