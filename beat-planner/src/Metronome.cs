using System;
using System.Diagnostics;
using System.Threading;
using Android.Media;
using Android.Content.Res;


namespace BeatPlanner
{
    public class BeatEventArgs : EventArgs
    {
        public readonly int Index, Beat, Bar;

        public BeatEventArgs(int i, int b, int bar)
        {
            Index = i;
            Beat = b;
            Bar = bar;
        }
    }

    public class Metronome
    {
        private class BeatEnumerator
        {
            public struct Info
            {
                public readonly int Index;
                public readonly long Duration;

                public Info(int i, long d)
                {
                    Index = i;
                    Duration = d;
                }
            }

            public readonly Beat Beat;
            private int index = 1;

            public BeatEnumerator(Beat beat)
            {
                this.Beat = beat;
            }

            public Info Next()
            {
                int retIndex = index;
                index++;
                if (index > Beat.Meter.Upper)
                    index = 1;

                long fourthDur = 60000 / Beat.BPM;
                long dur = (long)(fourthDur * (4 / (float)Beat.Meter.Lower));

                return new Info(retIndex, dur);
            }
        }

        private int beats = 0;

        public int Beats { get { return beats; } private set { beats = value; } }

        private int bars = 0;

        public int Bars { get { return bars; } private set { bars = value; } }

        public Beat Beat
        {
            get { return bEnum.Beat; }
            set
            {
                bEnum = new BeatEnumerator(value);
            }
        }

        public int BPM
        {
            get { return Beat.BPM; }
            set
            {
                Beat.BPM = value;
            }
        }

        public Meter Meter
        {
            get { return Beat.Meter; }
            set { Beat = new Beat(value, Beat.BPM); }
        }
        // Not really used
        private Stopwatch sw;
        private Thread thread;
 
        private BeatEnumerator bEnum;
        private bool shouldStop = false;
        public EventHandler<BeatEventArgs> BeatEvent;

        public ReaderWriterLockSlim Lock { get; private set; }

        public Metronome(Beat beat)
        {
            sw = new Stopwatch();
            bEnum = new BeatEnumerator(beat);
            Beats = 0;
            Lock = new ReaderWriterLockSlim();
        }

        public Metronome() :
            this(new Beat(Meter.Common, 60))
        {

        }

        public void Start()
        {
            if (thread != null && thread.IsAlive) // already running
				return;
            thread = new Thread(Loop);
            thread.Priority = ThreadPriority.Highest;
            sw.Start();

            thread.Start();
        }

        public void Stop()
        {
            if (thread != null && thread.IsAlive)
            {
                sw.Stop();
                shouldStop = true;
                thread.Join();

                Console.WriteLine("Metronome stopped");
            }
				
        }

        public void Reset()
        {
            Beats = 0;
            Bars = 0;
            sw.Reset();
            bEnum = new BeatEnumerator(bEnum.Beat);
            if (thread.IsAlive)
            {
                sw.Start();
            }
        }

        public void Restart()
        {
            Reset();
            if (thread.IsAlive == false)
                Start();

        }

        private void Loop()
        {
            //Thread.Sleep(200); // HACK to get first beat audible
            BeatEnumerator.Info info;
            while (shouldStop == false)
            {
                Lock.EnterReadLock();
                info = bEnum.Next();
                Lock.ExitReadLock();
                if (info.Index == Beat.Meter.Upper)
                    Interlocked.Increment(ref bars);
                Interlocked.Increment(ref beats);

                if (BeatEvent != null)
                    BeatEvent(this, new BeatEventArgs(info.Index, Beats, Bars));

                Console.WriteLine(sw.ElapsedMilliseconds + ", Index: " + info.Index + ", Bars: " + Bars);
                Thread.Sleep((int)info.Duration); // Not very accurate, unfortunately. Alternatives appear limited
            }
            shouldStop = false;
        }
    }
}