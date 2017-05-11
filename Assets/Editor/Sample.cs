using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

public class Smaple {
    [MenuItem("Window/test")] public static void Run () {
        // var dest = System.IO.Path.Combine(Application.persistentDataPath, "profiler.log");
        Profiler.logFile = "profiler.log";//dest;
        Profiler.enableBinaryLog = true;

        // Profiler.enableBinaryLog = false;
        Profiler.enabled = !Profiler.enabled;
        
        Debug.LogError("changed. Profiler.enabled:" + Profiler.enabled);// ここがfalseになると動くんだけど。なんで？
    }
}