//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui;





public class MetroActivity  extends Activity 
{
    private Metronome metro;
    private SoundPool sp = new SoundPool();
    private int claveId, claveLowId;
    Button startBtn = new Button();
    Button stopBtn = new Button();
    EditText bpmText = new EditText();
    SeekBar bpmSeekBar = new SeekBar();
    Button bpmIncBtn = new Button();
    Button bpmDecBtn = new Button();
    Spinner lowerMeterSpinner = new Spinner();
    Spinner upperMeterSpinner = new Spinner();
    protected void onCreate(Bundle bundle) throws Exception {
        super.OnCreate(bundle);
        SetContentView(Resource.Layout.Metro);
        init();
    }

    private void init() throws Exception {
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
        bpmText.Text = metro.getBPM().ToString();
        bpmSeekBar.Progress = metro.getBPM();
        upperMeterSpinner.SetSelection(3);
        lowerMeterSpinner.SetSelection(1);
        upperMeterSpinner.ItemSelected += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, AdapterView.ItemSelectedEventArgs e) => {
            metro.getBeat().Meter.Upper = Integer.valueOf(e.Parent.GetItemAtPosition(e.Position).ToString());
        }" */;
        lowerMeterSpinner.ItemSelected += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, AdapterView.ItemSelectedEventArgs e) => {
            metro.getBeat().Meter.Lower = Integer.valueOf(e.Parent.GetItemAtPosition(e.Position).ToString());
        }" */;
        startBtn.Click += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, EventArgs e) => {
            metro.start();
        }" */;
        stopBtn.Click += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, EventArgs e) => {
            metro.stop();
        }" */;
        bpmIncBtn.Click += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, EventArgs e) => {
            metro.setBPM(metro.getBPM() + 5);
        }" */;
        bpmDecBtn.Click += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, EventArgs e) => {
            metro.setBPM(metro.getBPM() - 5);
        }" */;
        bpmText.FocusChange += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, View.FocusChangeEventArgs e) => {
            try
            {
                if (e.HasFocus == false)
                    metro.setBPM(Integer.valueOf(bpmText.Text));
                 
            }
            catch (FormatException ex)
            {
                Log.Error(Class.SimpleName, ex.StackTrace);
            }
        
        }" */;
        bpmSeekBar.ProgressChanged += /* [UNSUPPORTED] to translate lambda expressions we need an explicit delegate type, try adding a cast "(Object sender, SeekBar.ProgressChangedEventArgs e) => {
            metro.setBPM(e.Progress);
        }" */;
    }

    void onBPMChanged(Object sender, BPMChangedEventArgs e) throws Exception {
        bpmText.Text = e.BPM.ToString();
        bpmSeekBar.Progress = e.BPM;
    }

}


