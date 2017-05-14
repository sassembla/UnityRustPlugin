using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

public class Smaple {

    private const string controlPath = "control.log";
    private const string profilePath = "prof/prof_";
    private const int filePerFrameLimit = 100;
    
    private static bool running;
    [MenuItem("Window/test")] public static void Run () {
        var dest = System.IO.Path.Combine(Application.persistentDataPath, profilePath);
        
        running = !running;
        
        if (running) {
            StartProfiling();
            using (var sw = new StreamWriter(controlPath)) {
                sw.WriteLine("changed. to running:" + running);
            }
            EditorApplication.update += CountUp;
        }　else {
            StopProfiling();
            using (var sw = new StreamWriter(controlPath)) {
                sw.WriteLine("changed. to running:" + running);
            }
            EditorApplication.update -= CountUp;
        }
    }

    private static void StartProfiling () {
        Profiler.logFile = PaddedProfilePath();
        Profiler.enableBinaryLog = true;
        Profiler.enabled = true;
    }

    private static void StopProfiling () {
        Profiler.logFile = string.Empty;
        Profiler.enableBinaryLog = false;
        Profiler.enabled = false;
    }

    private static int frame = 0;
    private static int count = 0;

    private static void CountUp () {
        frame++;
        if (frame == filePerFrameLimit) {
            count++;
            frame = 0;
            Profiler.logFile = PaddedProfilePath();
        }
    }

    private static string PaddedProfilePath () {
        return profilePath + count.ToString().PadLeft(4, '0');
    }
}