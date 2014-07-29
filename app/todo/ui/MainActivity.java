//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui;




public class MainActivity  extends Activity 
{
    int count = 1;
    private Metronome metro;
    protected void onCreate(Bundle bundle) throws Exception {
        super.OnCreate(bundle);
        // Set our view from the "activity_main" layout resource
        SetContentView(Resource.Layout.Main);
        // Get our button from the layout resource,
        // and attach an event to it
        Button button = FindViewById<Button>(Resource.Id.myButton);
        metro = new Metronome();
        SoundPool sp = new SoundPool(2, Android.Media.Stream.Music, 0);
        int clave_low = sp.Load(this, Resource.Raw.llfclave_low, 1);
        int clave_high = sp.Load(this, Resource.Raw.llfclave, 1);
        metro.BeatEvent += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, BeatEventArgs e) => {
            int sid;
            if (e.index == 1)
                sid = clave_high;
            else
                sid = clave_low; 
            sp.Play(sid, 1, 1, 1, 0, 1.0f);
        }" */;
        button.Click += ;
    }

}


