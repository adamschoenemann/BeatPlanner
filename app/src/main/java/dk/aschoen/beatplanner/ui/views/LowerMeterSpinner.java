
package dk.aschoen.beatplanner.ui.views;


import android.content.Context;
import android.util.AttributeSet;

import dk.aschoen.beatplanner.R;

public class LowerMeterSpinner extends MeterSpinner 
{
    public LowerMeterSpinner(Context context) {
        super(context);
    }

    public LowerMeterSpinner(Context context, int mode) {
        super(context, mode);
    }

    public LowerMeterSpinner(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    public LowerMeterSpinner(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }

    public LowerMeterSpinner(Context context, AttributeSet attrs, int defStyle, int mode) {
        super(context, attrs, defStyle, mode);
    }

    protected int getTextArrayId() {
        return R.array.lowerMeterValues;
    }

}


