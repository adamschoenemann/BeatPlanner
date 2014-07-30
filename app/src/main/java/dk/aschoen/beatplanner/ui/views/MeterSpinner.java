//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui.views;


import android.content.Context;
import android.util.AttributeSet;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

import java.util.ArrayList;

public abstract class MeterSpinner extends Spinner 
{
    public MeterSpinner(Context context) {
        super(context);
        initialize();
    }

    public MeterSpinner(Context context, int mode) {
        super(context, Spinner.MODE_DIALOG);
        initialize();
    }

    public MeterSpinner(Context context, AttributeSet attrs) {
        super(context, attrs);
        initialize();
    }

    public MeterSpinner(Context context, AttributeSet attrs, int defStyle) {
        super(context, attrs, defStyle);
        initialize();
    }

    public MeterSpinner(Context context, AttributeSet attrs, int defStyle, int mode) {
        super(context, attrs, defStyle, Spinner.MODE_DIALOG);
        initialize();
    }

    protected abstract int getTextArrayId() ;

    protected void initialize() {
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(getContext(), getTextArrayId(), android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        setAdapter(adapter);
    }

}


