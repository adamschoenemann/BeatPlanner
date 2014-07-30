//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui.views;


import android.content.Context;
import android.util.AttributeSet;

import dk.aschoen.beatplanner.R;

public class UpperMeterSpinner extends MeterSpinner 
{
    public UpperMeterSpinner(Context context) {
        super(context);
    }

    public UpperMeterSpinner(Context context, int mode) {
        super(context, mode);
    }

    public UpperMeterSpinner(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    public UpperMeterSpinner(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
    }

    public UpperMeterSpinner(Context context, AttributeSet attrs, int defStyle, int mode) {
        super(context, attrs, defStyle, mode);
    }

    protected int getTextArrayId() {
        return R.array.upperMeterValues;
    }

}


