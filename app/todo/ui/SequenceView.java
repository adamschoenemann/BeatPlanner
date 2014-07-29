//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui;







public class SequenceView  extends LinearLayout 
{
    public Sequence Sequence;
    private NumberPicker __BpmPicker = new NumberPicker();
    public void setBpmPicker(NumberPicker value) {
        __BpmPicker = value;
    }

    public NumberPicker getBpmPicker() {
        return __BpmPicker;
    }

    private UpperMeterSpinner __UpperMeterView;
    public void setUpperMeterView(UpperMeterSpinner value) {
        __UpperMeterView = value;
    }

    public UpperMeterSpinner getUpperMeterView() {
        return __UpperMeterView;
    }

    private LowerMeterSpinner __LowerMeterView;
    public void setLowerMeterView(LowerMeterSpinner value) {
        __LowerMeterView = value;
    }

    public LowerMeterSpinner getLowerMeterView() {
        return __LowerMeterView;
    }

    private Button __PlayBtn = new Button();
    public void setPlayBtn(Button value) {
        __PlayBtn = value;
    }

    public Button getPlayBtn() {
        return __PlayBtn;
    }

    public SequenceView(Context context) throws Exception {
        super(context);
        initialize();
    }

    public SequenceView(Context context, IAttributeSet attrs) throws Exception {
        super(context, attrs);
        setAttrs(context,attrs);
        initialize();
    }

    public SequenceView(Context context, IAttributeSet attrs, int defStyle) throws Exception {
        super(context, attrs, defStyle);
        setAttrs(context,attrs);
        initialize();
    }

    private void initialize() throws Exception {
        //      var tv = new TextView(Context);
        //      tv.Text = "BPM: " + Sequence.beat.BPM +
        //      "\nUpper: " + Sequence.beat.Meter.Upper +
        //      "\nLower: " + Sequence.beat.Meter.Lower +
        //      "\nreps: " + Sequence.reps;
        //      AddView(tv);
        LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
        inflater.Inflate(Resource.Layout.SequenceView, this, true);
        setBpmPicker(FindViewById<NumberPicker>(Resource.Id.bpmPicker));
        setUpperMeterView(FindViewById<UpperMeterSpinner>(Resource.Id.upperMeter));
        setLowerMeterView(FindViewById<LowerMeterSpinner>(Resource.Id.lowerMeter));
        setPlayBtn(FindViewById<Button>(Resource.Id.playBtn));
        getBpmPicker().WrapSelectorWheel = false;
        getBpmPicker().MinValue = 1;
        getBpmPicker().MaxValue = 300;
        getBpmPicker().Value = 100;
        getBpmPicker().ValueChanged += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, NumberPicker.ValueChangeEventArgs e) => {
            Sequence.beat.BPM = e.NewVal;
        }" */;
    }

    private void setAttrs(Context ctx, IAttributeSet attrs) throws Exception {
        TypedArray a = ctx.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.SequenceView, 0, 0);
        try
        {
            int bpm = a.GetInt(Resource.Styleable.SequenceView_bpm, 100), lowerMeter = a.GetInt(Resource.Styleable.SequenceView_lowerMeter, 4), upperMeter = a.GetInt(Resource.Styleable.SequenceView_upperMeter, 4), reps = a.GetInt(Resource.Styleable.SequenceView_reps, 4);
            Sequence = new Sequence(new Beat(new Meter(upperMeter,lowerMeter),bpm),reps);
        }
        finally
        {
            a.Recycle();
        }
    }

}


