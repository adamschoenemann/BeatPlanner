
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
  public abstract class MeterSpinner : Spinner
  {

    public MeterSpinner(Context context) :
      base(context)
    {
      Initialize();
    }

    public MeterSpinner(Context context, int mode) :
      base(context, SpinnerMode.Dialog)
    {
      Initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs) :
      base(context, attrs)
    {
      Initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs, int defStyle) :
      base(context, attrs, defStyle)
    {
      Initialize();
    }

    public MeterSpinner(Context context, IAttributeSet attrs, int defStyle, int mode) :
      base(context, attrs, defStyle, SpinnerMode.Dialog)
    {
      Initialize();
    }

    protected abstract int TextArrayId { get; }

    protected virtual void Initialize()
    {
      var adapter = ArrayAdapter.CreateFromResource(
                      Context,
                      TextArrayId,
                      Android.Resource.Layout.SimpleSpinnerItem
                    );

      adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
      this.Adapter = adapter;
    }

  }
}

