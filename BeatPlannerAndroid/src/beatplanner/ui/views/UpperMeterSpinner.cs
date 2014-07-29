
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
  public class UpperMeterSpinner : MeterSpinner
  {
    public UpperMeterSpinner(Context context) :
      base(context)
    {
    }

    public UpperMeterSpinner(Context context, int mode) :
      base(context, mode)
    {
    }

    public UpperMeterSpinner(Context context, IAttributeSet attrs) :
      base(context, attrs)
    {
    }

    public UpperMeterSpinner(Context context, IAttributeSet attrs, int defStyle) :
      base(context, attrs, defStyle)
    {

    }

    public UpperMeterSpinner(Context context, IAttributeSet attrs, int defStyle, int mode) :
      base(context, attrs, defStyle, mode)
    {

    }

    protected override int TextArrayId
    {
      get
      {
        return Resource.Array.upperMeterValues;
      }
    }
  }
}

