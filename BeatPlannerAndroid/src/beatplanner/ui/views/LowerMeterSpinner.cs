
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BeatPlannerAndroid
{
  public class LowerMeterSpinner : MeterSpinner
  {
    public LowerMeterSpinner(Context context) :
      base(context)
    {
    }

    public LowerMeterSpinner(Context context, int mode) :
      base(context, mode)
    {
    }

    public LowerMeterSpinner(Context context, IAttributeSet attrs) :
      base(context, attrs)
    {
    }

    public LowerMeterSpinner(Context context, IAttributeSet attrs, int defStyle) :
      base(context, attrs, defStyle)
    {

    }

    public LowerMeterSpinner(Context context, IAttributeSet attrs, int defStyle, int mode) :
      base(context, attrs, defStyle, mode)
    {

    }

    protected override int TextArrayId
    {
      get
      {
        return Resource.Array.lowerMeterValues;
      }
    }
  }
}

