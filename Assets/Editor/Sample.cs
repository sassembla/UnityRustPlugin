using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

public class Smaple {

    private const string controlPath = "control.log";
    private const string profilePath = "prof/prof_";
    private const int filePerFrameLimit = 1;
    
    private static bool running;

    [MenuItem("Window/prof")] public static void Read () {
        var dataFileProfilerName = "prof/prof_0002";
        var dataFileName = dataFileProfilerName + ".data";
        
        var header = new byte[16];
        
        using (var fs = File.OpenRead(dataFileName)) {
            while (true) {
                // ヘッダサイズ16byte
                fs.Read(header, 0, header.Length);

                int size = GetIntValue(header, 8); // オフセットの前のとこは最初は固定値なんだけど、なんか情報を含んでそう。
                Debug.LogError("size:" + size);
                
                // 1フレームのデータサイズがこれ。
                var buffer = new byte[size];
                var rest = fs.Read(buffer, 0, size);

                // このデータに何がどうやって入っているのかを追うことができれば、幸せになれそうなんですが。
                // たぶん同じようなフォーマットだと思うんだよね。
                
                Debug.LogError("a:" + Encoding.Default.GetString(buffer));
                fs.Read(header, 0, header.Length);
                // int size2 = GetIntValue(header, 8);
                // Debug.LogError("size2:" + size2);

                break;

                if (0 < rest) {
                    continue;
                }
                break;
            }
        }

        Profiler.AddFramesFromFile(dataFileProfilerName);
    }
    private static int GetIntValue(byte[] bin, int offset) {
        return (bin[offset + 0] << 0) +
            (bin[offset + 1] << 8) +
            (bin[offset + 2] << 16) +
            (bin[offset + 3] << 24);
    }


    [MenuItem("Window/test")] public static void Run () {
        var dest = Path.Combine(Application.persistentDataPath, profilePath);
        
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