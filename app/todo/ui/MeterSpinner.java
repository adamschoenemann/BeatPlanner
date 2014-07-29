//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui;


public abstract class MeterSpinner  extends Spinner 
{
    public MeterSpinner(Context context) throws Exception {
        super(context);
        initialize();
    }

    public MeterSpinner(Context context, int mode) throws Exception {
        super(context, SpinnerMode.Dialog);
        initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs) throws Exception {
        super(context, attrs);
        initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs, int defStyle) throws Exception {
        super(context, attrs, defStyle);
        initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs, int defStyle, int mode) throws Exception {
        super(context, attrs, defStyle, SpinnerMode.Dialog);
        initialize();
    }

    protected abstract int getTextArrayId() throws Exception ;

    protected void initialize() throws Exception {
        /* [UNSUPPORTED] 'var' as type is unsupported "var" */ adapter = ArrayAdapter.CreateFromResource(Context, getTextArrayId(), Android.Resource.Layout.SimpleSpinnerItem);
        adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        this.Adapter = adapter;
    }

}


