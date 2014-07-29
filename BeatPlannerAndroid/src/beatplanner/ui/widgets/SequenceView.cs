
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
using BeatPlanner;
using Android.Content.Res;
using System.Security.Cryptography;

namespace BeatPlannerAndroid
{
  public class SequenceView : LinearLayout
  {

    public Sequence Sequence;

    public NumberPicker BpmPicker { private set; get; }

    public UpperMeterSpinner UpperMeterView { private set; get; }

    public LowerMeterSpinner LowerMeterView { private set; get; }

    public Button PlayBtn { private set; get; }

    public SequenceView(Context context) :
      base(context)
    {
      Initialize();
    }

    public SequenceView(Context context, IAttributeSet attrs) :
      base(context, attrs)
    {
      SetAttrs(context, attrs);
      Initialize();
    }

    public SequenceView(Context context, IAttributeSet attrs, int defStyle) :
      base(context, attrs, defStyle)
    {
      SetAttrs(context, attrs);
      Initialize();
    }

    private void Initialize()
    {
//      var tv = new TextView(Context);
//      tv.Text = "BPM: " + Sequence.Beat.BPM +
//      "\nUpper: " + Sequence.Beat.Meter.Upper +
//      "\nLower: " + Sequence.Beat.Meter.Lower +
//      "\nReps: " + Sequence.Reps;
//      AddView(tv);
      LayoutInflater inflater = 
        (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
      inflater.Inflate(Resource.Layout.SequenceView, this, true);

      BpmPicker = FindViewById<NumberPicker>(Resource.Id.bpmPicker);
      UpperMeterView = FindViewById<UpperMeterSpinner>(Resource.Id.upperMeter);
      LowerMeterView = FindViewById<LowerMeterSpinner>(Resource.Id.lowerMeter);
      PlayBtn = FindViewById<Button>(Resource.Id.playBtn);

      BpmPicker.WrapSelectorWheel = false;
      BpmPicker.MinValue = 1;
      BpmPicker.MaxValue = 300;
      BpmPicker.Value = 100;
      BpmPicker.ValueChanged += (object sender, NumberPicker.ValueChangeEventArgs e) =>
      {
        Sequence.Beat.BPM = e.NewVal;
      };


    }

    private void SetAttrs(Context ctx, IAttributeSet attrs)
    {
      TypedArray a = ctx.Theme.ObtainStyledAttributes(
                       attrs, Resource.Styleable.SequenceView, 0, 0);

      try
      {
        int
        bpm = a.GetInt(Resource.Styleable.SequenceView_bpm, 100),
        lowerMeter = a.GetInt(Resource.Styleable.SequenceView_lowerMeter, 4),
        upperMeter = a.GetInt(Resource.Styleable.SequenceView_upperMeter, 4),
        reps = a.GetInt(Resource.Styleable.SequenceView_reps, 4);

        Sequence = new Sequence(
          new Beat(
            new Meter(upperMeter, lowerMeter), 
            bpm),
          reps);
      }
      finally
      {
        a.Recycle();
      }
    }
  }
}

