
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
using BeatPlanner;
using Android.Media;
using Android.Util;

namespace BeatPlannerAndroid
{
  [Activity(Label = "Metronome")]
  public class MetroActivity : Activity
  {
    private Metronome metro;
    private SoundPool sp;
    private int claveId, claveLowId;

    Button startBtn;
    Button stopBtn;
    EditText bpmText;
    SeekBar bpmSeekBar;
    Button bpmIncBtn;
    Button bpmDecBtn;

    Spinner lowerMeterSpinner;

    Spinner upperMeterSpinner;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.Metro);
      Init();
    }

    private void Init()
    {

      metro = MetroApp.DefaultMetronome(this);

      metro.BPMChangedEvent += OnBPMChanged;

      // UI init
      startBtn = FindViewById<Button>(Resource.Id.startBtn);
      stopBtn = FindViewById<Button>(Resource.Id.stopBtn);
      bpmText = FindViewById<EditText>(Resource.Id.bpmText);
      bpmSeekBar = FindViewById<SeekBar>(Resource.Id.bpmSeekBar);
      bpmIncBtn = FindViewById<Button>(Resource.Id.inc_tempo);
      bpmDecBtn = FindViewById<Button>(Resource.Id.dec_tempo);
      upperMeterSpinner = FindViewById<Spinner>(Resource.Id.upperMeter);
      lowerMeterSpinner = FindViewById<Spinner>(Resource.Id.lowerMeter);



    

      // Initialize UI with values
      bpmText.Text = metro.BPM.ToString();
      bpmSeekBar.Progress = metro.BPM;
      upperMeterSpinner.SetSelection(3);
      lowerMeterSpinner.SetSelection(1);

      upperMeterSpinner.ItemSelected += 
        (object sender, AdapterView.ItemSelectedEventArgs e) =>
      {
        metro.Beat.Meter.Upper = 
          Convert.ToInt32(e.Parent.GetItemAtPosition(e.Position).ToString());
      };

      lowerMeterSpinner.ItemSelected += 
        (object sender, AdapterView.ItemSelectedEventArgs e) =>
      {
        metro.Beat.Meter.Lower = 
          Convert.ToInt32(e.Parent.GetItemAtPosition(e.Position).ToString());
      };

      startBtn.Click += (object sender, EventArgs e) => metro.Start();
      stopBtn.Click += (object sender, EventArgs e) => metro.Stop();

      bpmIncBtn.Click += (object sender, EventArgs e) => metro.BPM += 5;


      bpmDecBtn.Click += (object sender, EventArgs e) => metro.BPM -= 5;

      bpmText.FocusChange += (object sender, View.FocusChangeEventArgs e) =>
      {
        try
        {
          if (e.HasFocus == false)
            metro.BPM = Convert.ToInt32(bpmText.Text);
        }
        catch (FormatException ex)
        {
          Log.Error(Class.SimpleName, ex.StackTrace);
        }
      };

      bpmSeekBar.ProgressChanged += 
        (object sender, SeekBar.ProgressChangedEventArgs e) => 
          metro.BPM = e.Progress;

    }

    void OnBPMChanged(object sender, BPMChangedEventArgs e)
    {
      bpmText.Text = e.BPM.ToString();
      bpmSeekBar.Progress = e.BPM;
    }
  }
}

