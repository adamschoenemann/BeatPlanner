//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui;






public class TrackActivity  extends Activity 
{
    private Metronome __Metronome;
    public Metronome getMetronome() {
        return __Metronome;
    }

    public void setMetronome(Metronome value) {
        __Metronome = value;
    }

    private List<SequenceView> seqViews = new List<SequenceView>();
    protected void onCreate(Bundle bundle) throws Exception {
        super.OnCreate(bundle);
        setMetronome(MetroApp.DefaultMetronome(this));
        SetContentView(Resource.Layout.Track);
        /* [UNSUPPORTED] 'var' as type is unsupported "var" */ cv = FindViewById<LinearLayout>(Resource.Id.trackRoot);
        for (int i = 0;i < cv.ChildCount;i++)
        {
            View v = cv.GetChildAt(i);
            if (v instanceof SequenceView)
                addSequenceView((SequenceView)v);
             
        }
    }

    //      var root = FindViewById<LinearLayout>(Resource.Id.trackRoot);
    //      view_sequence sv = new view_sequence(this, new Sequence(new beat(Meter.Common, 100), 4));
    //      root.AddView(sv);
    private void addSequenceView(SequenceView v) throws Exception {
        v.getPlayBtn().Click += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, EventArgs e) => {
            Sequence s = v.Sequence;
            /* [UNSUPPORTED] 'var' as type is unsupported "var" */ btn = (Button)sender;
            getMetronome().setBeat(s.Beat);
            getMetronome().toggle();
            btn.Text = (StringSupport.equals(btn.Text, "Play")) ? "Stop" : "Play";
        }" */;
        seqViews.Add(v);
    }

}


