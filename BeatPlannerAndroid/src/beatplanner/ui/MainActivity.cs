using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BeatPlanner;
using Android.Media;
using Android.Net.Rtp;

namespace BeatPlannerAndroid
{
    [Activity(Label = "BeatPlannerAndroid")]
    public class MainActivity : Activity
    {
        int count = 1;
        private Metronome metro;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            metro = new Metronome();
            SoundPool sp = new SoundPool(2, Android.Media.Stream.Music, 0);
            int clave_low = sp.Load(this, Resource.Raw.llfclave_low, 1);
            int clave_high = sp.Load(this, Resource.Raw.llfclave, 1);

            metro.BeatEvent += (object sender, BeatEventArgs e) =>
            {
                int sid;
                if (e.Index == 1)
                    sid = clave_high;
                else
                    sid = clave_low;
                sp.Play(sid, 1, 1, 1, 0, 1.0f);
            };

            button.Click += delegate
            {
                if (!metro.IsPlaying)
                    metro.Start();
                else
                    metro.Stop();
            };
        }
    }
}


