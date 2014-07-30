//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:12
//

package dk.aschoen.beatplanner.ui.activities;


import android.app.Activity;
import android.media.SoundPool;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.SeekBar;
import android.widget.Spinner;

import dk.aschoen.beatplanner.MetroApp;
import dk.aschoen.beatplanner.R;
import dk.aschoen.beatplanner.core.Metronome;

public class MetroActivity  extends Activity 
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

    protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);
        setContentView(R.layout.activity_metro);
        init();
    }

    private void init() {
        metro = MetroApp.defaultMetronome(this);
        metro.onBPMChangedEvent(new Metronome.OnBPMChangedListener() {
            @Override
            public void onBPMChanged(int oldBPM, int newBPM) {
                bpmText.setText(String.valueOf(newBPM));
                bpmSeekBar.setProgress(newBPM);
            }
        });
        // UI init
        startBtn = (Button) findViewById(R.id.startBtn);
        stopBtn = (Button) findViewById(R.id.stopBtn);
        bpmText = (EditText) findViewById(R.id.bpmText);
        bpmSeekBar = (SeekBar) findViewById(R.id.bpmSeekBar);
        bpmIncBtn = (Button) findViewById(R.id.inc_tempo);
        bpmDecBtn = (Button) findViewById(R.id.dec_tempo);
        upperMeterSpinner = (Spinner) findViewById(R.id.upperMeter);
        lowerMeterSpinner = (Spinner) findViewById(R.id.lowerMeter);
        // Initialize UI with values
        bpmText.setText(String.valueOf(metro.getBPM()));
        bpmSeekBar.setProgress(metro.getBPM());



        upperMeterSpinner.setSelection(3);
        lowerMeterSpinner.setSelection(1);

        upperMeterSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                metro.getBeat().getMeter().setUpper(Integer.valueOf(parent.getItemAtPosition(position).toString()));
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        lowerMeterSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                metro.getBeat().getMeter().setLower(Integer.valueOf(parent.getItemAtPosition(position).toString()));
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });


        startBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                metro.start();
            }
        });


        stopBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                metro.stop();
            }
        });


        bpmIncBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                metro.setBPM(metro.getBPM() + 5);
            }
        });


        bpmDecBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                metro.setBPM(metro.getBPM() - 5);
            }
        });

        bpmText.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                try {
                    if (hasFocus == false)
                        metro.setBPM(Integer.valueOf(bpmText.getText().toString()));
                } catch (NumberFormatException e) {
                    e.printStackTrace();
                }
            }
        });

        bpmSeekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                metro.setBPM(progress);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

    }


}


