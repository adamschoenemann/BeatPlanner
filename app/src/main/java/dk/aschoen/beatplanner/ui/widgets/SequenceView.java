//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui.widgets;

import android.content.Context;
import android.content.res.TypedArray;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.NumberPicker;

import dk.aschoen.beatplanner.R;
import dk.aschoen.beatplanner.core.Beat;
import dk.aschoen.beatplanner.core.Meter;
import dk.aschoen.beatplanner.core.Sequence;
import dk.aschoen.beatplanner.ui.views.LowerMeterSpinner;
import dk.aschoen.beatplanner.ui.views.UpperMeterSpinner;

public class SequenceView  extends LinearLayout 
{
    private Sequence sequence;

    private NumberPicker bpmPicker;

    private UpperMeterSpinner upperMeterView;

    private LowerMeterSpinner lowerMeterView;

    private Button playBtn;


    public SequenceView(Context context) {
        super(context);
        initialize();
    }

    public SequenceView(Context context, AttributeSet attrs) {
        super(context, attrs);
        setAttrs(context,attrs);
        initialize();
    }

    public SequenceView(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
        setAttrs(context,attrs);
        initialize();
    }

    private void initialize() {
        //      var tv = new TextView(Context);
        //      tv.Text = "BPM: " + sequence.beat.BPM +
        //      "\nupper: " + sequence.beat.Meter.upper +
        //      "\nlower: " + sequence.beat.Meter.lower +
        //      "\nreps: " + sequence.reps;
        //      AddView(tv);
        LayoutInflater inflater = (LayoutInflater)getContext().getSystemService(getContext().LAYOUT_INFLATER_SERVICE);
        inflater.inflate(R.layout.view_sequence, this, true);
        bpmPicker = (NumberPicker) findViewById(R.id.bpmPicker);
        upperMeterView = (UpperMeterSpinner) findViewById(R.id.upperMeter);
        lowerMeterView = (LowerMeterSpinner) findViewById(R.id.lowerMeter);
        playBtn = (Button) findViewById(R.id.playBtn);
        bpmPicker.setWrapSelectorWheel(false);
        bpmPicker.setMinValue(1);
        bpmPicker.setMaxValue(300);
        bpmPicker.setValue(100);
        bpmPicker.setOnValueChangedListener(new NumberPicker.OnValueChangeListener() {
            @Override
            public void onValueChange(NumberPicker picker, int oldVal, int newVal) {
                getSequence().getBeat().setBPM(newVal);
            }
        });
    }

    private void setAttrs(Context ctx, AttributeSet attrs) {
        TypedArray a = ctx.getTheme().obtainStyledAttributes(attrs, R.styleable.SequenceView, 0, 0);
        try
        {
            int bpm = a.getInt(R.styleable.SequenceView_bpm, 100),
                lowerMeter = a.getInt(R.styleable.SequenceView_lowerMeter, 4),
                upperMeter = a.getInt(R.styleable.SequenceView_upperMeter, 4),
                reps = a.getInt(R.styleable.SequenceView_reps, 4);
            sequence = new Sequence(new Beat(new Meter(upperMeter,lowerMeter),bpm),reps);
        }
        finally
        {
            a.recycle();
        }
    }

    public Button getPlayBtn() {
        return playBtn;
    }

    public Sequence getSequence() {
        return sequence;
    }
}


