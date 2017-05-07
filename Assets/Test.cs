using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

public class Test : MonoBehaviour
{
    
    // [DllImport("libtest_plugin", EntryPoint="generate_image")] private static extern void GenerateImage(Color32[] buffer, int width, int height);

    // [DllImport("libtest_plugin", EntryPoint="set_log")] private static extern void SetLogMessage(Color32[] buffer);


    void Start ()
    {
        // var startTime = Time.realtimeSinceStartup;

        // var pixels = new Color32[10 * 10];
        // GenerateImage(pixels, 10, 10);

        // var endTime = Time.realtimeSinceStartup;
        // Debug.Log("execution time = " + (endTime - startTime));

        // var texture = new Texture2D(10, 10);
        // texture.wrapMode = TextureWrapMode.Clamp;
        // texture.SetPixels32(pixels);
        // texture.Apply();

        // GetComponent<Renderer>().material.mainTexture = texture;

        // var v = new Color32[5];
        // SetLogMessage(v);

        // foreach (var a in v) {
        //     Debug.LogError("a:" + a.r + " " + a.g + " " + a.b + " " + a.a);
        // }


        var start = Time.realtimeSinceStartup; 
        int[,] tab = fillArray(10);
    }

    [DllImport ("LowLevelPlugin")] private static extern int [,] fillArray(int size);
}
