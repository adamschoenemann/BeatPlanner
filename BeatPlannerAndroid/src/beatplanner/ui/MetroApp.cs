using System;
using Android.App;
using Android.Util;
using Android.Runtime;
using BeatPlanner;
using Android.Media;
using Android.Content;

namespace BeatPlannerAndroid
{
  [Application]
  public class MetroApp : Application
  {

    public MetroApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }

    public override void OnCreate()
    {
      base.OnCreate();
      Log.Debug(Class.SimpleName, "MetroApp starting");
      Console.WriteLine("MetroApp starting");
    }

    public static Metronome DefaultMetronome(Context context)
    {

      Metronome metro = new Metronome();
      SoundPool sp = new SoundPool(2, Android.Media.Stream.Music, 0);
      int claveId = sp.Load(context, Resource.Raw.llfclave, 1);
      int claveLowId = sp.Load(context, Resource.Raw.llfclave_low, 1);
      metro.BeatEvent += (object sender, BeatEventArgs e) =>
      {
        int sid;
        if (e.Index == 1)
          sid = claveId;
        else
          sid = claveLowId;
        sp.Play(sid, 1.0f, 1.0f, 1, 0, 1.0f);
      };

      return metro;
    }



  }
}

