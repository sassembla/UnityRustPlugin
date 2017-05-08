using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

public class Smaple {
    [MenuItem("Window/test")] public static void Run () {
        // var dest = System.IO.Path.Combine(Application.persistentDataPath, "profiler.log");
        Profiler.logFile = "profiler.log";//dest;
        // バイナリファイルを有効に( profiler.log.data )として保存します

        Profiler.enableBinaryLog = true;
        
        Profiler.enabled = true;

        Debug.LogError("here!");
    }
}