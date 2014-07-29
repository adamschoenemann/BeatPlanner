
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

    public Metronome Metronome { get; private set; }

    private List<SequenceView> seqViews = new List<SequenceView>();

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      Metronome = MetroApp.DefaultMetronome(this);

      SetContentView(Resource.Layout.Track);


      var cv = FindViewById<LinearLayout>(Resource.Id.trackRoot);

      for (int i = 0; i < cv.ChildCount; i++)
      {
        View v = cv.GetChildAt(i);
        if (v is SequenceView)
          AddSequenceView((SequenceView)v);
      }

//      var root = FindViewById<LinearLayout>(Resource.Id.trackRoot);
//      SequenceView sv = new SequenceView(this, new Sequence(new Beat(Meter.Common, 100), 4));
//      root.AddView(sv);
    }

    private void AddSequenceView(SequenceView v)
    {
      v.PlayBtn.Click += (object sender, EventArgs e) =>
      {
        var s = v.Sequence;
        var btn = (Button)sender;
        Metronome.Beat = s.Beat;
        Metronome.Toggle();
        btn.Text = (btn.Text == "Play") ? "Stop" : "Play";

      };

      seqViews.Add(v);
    }
  }
}

