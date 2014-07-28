
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Security.Cryptography;
using BeatPlanner;

namespace BeatPlannerAndroid
{
  [Activity(Label = "TrackActivity", MainLauncher = true, Icon = "@drawable/icon")]			
  public class TrackActivity : Activity
  {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetContentView(Resource.Layout.Track);
//      var root = FindViewById<LinearLayout>(Resource.Id.trackRoot);
//      SequenceView sv = new SequenceView(this, new Sequence(new Beat(Meter.Common, 100), 4));
//      root.AddView(sv);
    }
  }
}

