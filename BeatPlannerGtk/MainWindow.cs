using System;
using Gtk;
using BeatPlanner;
using GLib;

public partial class MainWindow: Gtk.Window
{
	private Metronome metro = new Metronome();

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		const int maxUpper = 24;

		for (int i = 1; i <= maxUpper; i++)
			UpperMeterCB.AppendText(i.ToString());

		LowerMeterCB.AppendText("2");
		LowerMeterCB.AppendText("4");
		LowerMeterCB.AppendText("8");
		LowerMeterCB.AppendText("16");

		UpperMeterCB.Changed += (object sender, EventArgs e) =>
		{
			TreeIter iter;
			if (UpperMeterCB.GetActiveIter(out iter))
			{
				int val = Convert.ToInt32(UpperMeterCB.Model.GetValue(iter, 0));
				metro.Beat.Meter = new Meter(val, metro.Beat.Meter.Lower);
			}
		};

		LowerMeterCB.Changed += (object sender, EventArgs e) =>
		{
			TreeIter iter;
			if (LowerMeterCB.GetActiveIter(out iter))
			{
				int val = Convert.ToInt32(LowerMeterCB.Model.GetValue(iter, 0));
				metro.Beat.Meter = new Meter(metro.Beat.Meter.Upper, val);
			}
		};

	}

	private void Exit()
	{
		metro.Stop();
		Application.Quit();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Exit();
		a.RetVal = true;
	}

	protected void OnStartBtnPressed(object sender, EventArgs e)
	{
		metro.Start();
	}

	protected void OnStopBtnPressed(object sender, EventArgs e)
	{
		metro.Stop();
	}

	protected void OnKeyPressEvent(object sender, KeyPressEventArgs e)
	{
		if (e.Event.Key == Gdk.Key.Escape)
		{
			Exit();
			e.RetVal = true;
		}
	}

	protected void OnResetBtnPressed(object sender, EventArgs e)
	{
		metro.Reset();
	}

	protected void OnDecTempoBtnPressed(object sender, EventArgs e)
	{
		metro.BPM -= 5;
	}

	protected void OnIncTempoBtnPressed(object sender, EventArgs e)
	{
		metro.BPM += 5;
	}
}
