//
// Translated by CS2J (http://www.cs2j.com): 2014-07-29 22:02:11
//

package dk.aschoen.beatplanner.todo;

import dk.aschoen.beatplanner.core.Beat;
import dk.aschoen.beatplanner.core.Meter;
import dk.aschoen.beatplanner.core.Metronome;
//
//@Deprecated
//public class BeatPlanner
//{
//    public static void activity_main(String[] args) throws Exception {
//        BeatPlanner.activity_main(args);
//    }
//
//    public static void activity_main(String[] args) throws Exception {
//        activity_track track = activity_track.load("assets/track1.txt");
//        Metronome metro = new Metronome(new beat(Meter.Common,60));
//        TrackPlayer player = new TrackPlayer(track,metro);
//        player.playAsync();
//        String read = "";
//        do
//        {
//            if (StringSupport.equals(read, "stop"))
//            {
//                player.stop();
//            }
//
//            read = Console.ReadLine();
//        }
//        while (!StringSupport.equals(read, "q"));
//        player.stop();
//    }
//
//    public static void loadSaveTest(String[] args) throws Exception {
//        activity_track track = activity_track.load("assets/track1.txt");
//        TrackPlayer player = new TrackPlayer(track);
//        track.save("assets/track2.txt");
//    }
//
//    //			player.Play();
//    public static void parseBeatTest(String[] args) throws Exception {
//        String input = Console.ReadLine();
//        Metronome metro = new Metronome();
//        while (!StringSupport.equals(input, "q"))
//        {
//            beat beat = beat.parse(input);
//            metro.setBeat(beat);
//            metro.start();
//            while (metro.getBars() < 2)
//                ;
//            metro.stop();
//            metro.reset();
//            input = Console.ReadLine();
//        }
//    }
//
//    public static void trackTest(String[] args) throws Exception {
//        activity_track track = new activity_track();
//        TrackPlayer player = new TrackPlayer(track);
//        track.appendSequence(new beat(Meter.Common,80),4);
//        track.appendSequence(new beat(new Meter(3,4),120),4);
//        track.appendSequence(new beat(new Meter(7,8),200),4);
//        track.prependSequence(new beat(new Meter(5,4),160),2);
//        player.play();
//    }
//
//    public static void metroTest(String[] args) throws Exception {
//        Console.WriteLine("Hello!");
//        Metronome metro = new Metronome();
//        // metro.Start();
//        String read = new String();
//        while (true)
//        {
//            read = Console.ReadLine();
//            System.String __dummyScrutVar0 = read;
//            if (__dummyScrutVar0.equals("q") || __dummyScrutVar0.equals("quit"))
//            {
//                metro.stop();
//                return ;
//            }
//            else if (__dummyScrutVar0.equals("stop"))
//            {
//                metro.stop();
//            }
//            else if (__dummyScrutVar0.equals("start"))
//            {
//                metro.start();
//            }
//            else if (__dummyScrutVar0.equals("reset"))
//            {
//                metro.reset();
//            }
//            else if (__dummyScrutVar0.equals("restart"))
//            {
//                metro.restart();
//            }
//            else if (__dummyScrutVar0.equals("bpm"))
//            {
//                String bpmstr = Console.ReadLine();
//                int bpm = Integer.valueOf(bpmstr);
//                metro.getLock().EnterWriteLock();
//                metro.setBPM(bpm);
//                metro.getLock().ExitWriteLock();
//            }
//            else // metro.BPM = bpm;
//            if (__dummyScrutVar0.equals("beat"))
//            {
//                String beatstr = Console.ReadLine();
//                // e.g. 3/4
//                String[] nums = beatstr.Split('/');
//                int upper = Integer.valueOf(nums[0]);
//                int lower = Integer.valueOf(nums[1]);
//                // Console.WriteLine(upper);
//                // Console.WriteLine(lower);
//                metro.getLock().EnterWriteLock();
//                metro.setMeter(new Meter(upper,lower));
//                metro.getLock().ExitWriteLock();
//            }
//            else
//            {
//            }
//        }
//    }
//
//}


