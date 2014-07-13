using System;
using System.Diagnostics;
using System.Threading;

namespace BeatPlanner
{
	public class SoundPlayer
	{
		private Thread thread;
		private readonly ManualResetEventSlim mres;

		private UInt16 frequency, volume;
		private int msDuration;

		public SoundPlayer()
		{
			mres = new ManualResetEventSlim(false);
			thread = new Thread(Loop);
			thread.IsBackground = true;
			thread.Start();
		}

		public void PlayBeep(UInt16 frequency, int msDuration, UInt16 volume = 16383)
		{
			this.frequency = frequency;
			this.msDuration = msDuration;
			this.volume = volume;

			mres.Set();
		}

		private void Loop()
		{
			while(true)
			{
				SoundUtils.PlayBeep(frequency, msDuration, volume);
				mres.Reset();
				mres.Wait();
			}
		}
	}
}