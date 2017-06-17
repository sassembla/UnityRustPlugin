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


    [InitializeOnLoadMethod] static void OnProjectLoadedInEditor () {
        // ここで、吐き出したファイルの読み方をあれこれ試す。
        // 文字で出すのがまず問題っぽいので、
        /*
        " ???+?!<>~$߻? 73??J???]73? ??t7??P
ix



!??????*? ?^bhlors?tu|}~???????????????$,-/06?
           ???DzDzD?7.?	?????	Q	?@????UNKNOWNAudio ListenerMain Threadr??+?!)?o/?!
                                                                                    ?0?!gN0?!?1?!?1?!?1?!?1?!2?!!2?!)2?!+2?!-2?!12?!32?!82?!82?!82?!;2?!<2?!<2?!=2?!=2?!>2?!?2?!A2?!A2?!C2?!2?!I2?!f2?!f2?!h2?!j2?!n2?!o2?!q2?!v2?!?2?!?2?!?2?!?2?!?2?!?2?!?2?!?2?!?2?!?2?!?3?!??3?!?W<?!
                                                                                                              @[<?!_<?!m<?!n<?!n<?!o<?!t<?!u<?!{<?!
|<?!
?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<??<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!e?<?!	?<?!#?<?!?<?!?<?!?<?!	?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!=?!=?!=?!=?!"=?!,=?!.=?!/=?!0=?!1=?!5=?!6=?!6=?!^=?!`=?!g=?!2?b?!yd?UpdateScreenManagerAndInputGUIUtility.SetSkin()	WLoading.UpdateWebStreamLoading.UpdatePreloadingApplication.Integrate Assets in Background
Cleanup Unused Cached DataGameView.GetMainGameViewTargetSize()	ProcessRemoteInput
                                                                                  GlobalEventQueuePhysics.InterpolationAudioManager.FixedUpdateFixedBehaviourUpdatePhysics.StoreInterpolationPosesPhysics2D.FixedUpdatePhysics2D.MovementStatePhysics2D.SimulatePhysics2D.UpdateTransformsPhysics2D.EffectorFixedUpdatePhysics2D.JointBreakLimitsPhysics2D.CallbacksPhysics2D.ContactReportingPhysics2D.SimulatePhysics.InterpolationPhysics2D.DynamicUpdatePhysics2D.MovementStateHandleUtility.SetViewInfo()	Monobehaviour.OnMouse_SendMouseEvents.DoSendMouseEvents()	BehaviourUpdateDirectorUpdateNavMeshManagerNetwork.Update	ParticleSystem.UpdateLateBehaviourUpdateCanvas.SendWillRenderCanvases()	AudioManager.UpdatePhysics.UpdateClothParticleSystem.EndUpdateAllParticleSystem.Update2Substance.UpdateLightProbeProxyVolumeManager.UpdateRendering.UpdateDirtyRenderersMeshSkinning.UpdateMeshSkinning.PrepareGfx.WaitForPresentReflectionProbes.UpdateWaitForRenderJobsRenderTexture.SetActiveCamera.RenderCullingCamera.FireOnPreCull()	ScheduleCullingGroupsCullingGroupSendEventsRecalc BoundsPrepareSceneCullingParametersLOD.ComputeLODLOD.ComputeLODSceneCullingPrepareSceneNodesCullAllVisibleLightsFindActiveLightsAddDirectionalLightsFindDirectionalShadowCastingLightsFindShadowCastingLightsShadows.CullDirectionalShadowCastersAddActiveLocalLightsFindLocalShadowCastingLightsFindShadowCastingLightsCullSendEventsTerrain.Trees.OnWillRenderWaitForJobGroupCamera.FireOnPreRender()	UpdateDepthTextureRenderTexture.SetActiveRenderLoop.CleanupNodeQueueRenderTexture.SetActiveRenderTexture.SetActiveDrawingRender.PrepareRender.OpaqueGeometryRenderForwardOpaque.PrepareRenderForwardOpaque.RenderClearWaitForJobGroupRenderForward.RenderLoopJobBatchRenderer.FlushCamera.RenderSkyboxFindBrightestDirectionalLightMaterial.SetPassFastRenderLoop.CleanupNodeQueueRender.MotionVectorsCamera.ImageEffectsRenderLoop.CleanupNodeQueueRender.TransparentGeometryRenderForwardAlpha.PrepareRenderForwardAlpha.RenderRenderForward.RenderLoopJobBatchRenderer.FlushCamera.FireOnPostRender()	Flare.RenderCamera.ImageEffectsRenderLoop.CleanupNodeQueueCamera.GUILayerRenderLoop.CleanupNodeQueueDestroyCullResultsRenderLoop.CleanupNodeQueueRenderLoop.CleanupNodeQueueGUI.RepaintEvent.Internal_MakeMasterEventCurrent()	PlayerEndOfFrameProfiler.FinalizeAndSendFrameOverheadRender Thread?+?!
 x/?!*?1?!,O3?!W3?!?3?!?3?!??;?!??<?!?<?!?<?!?<?!
                                                 b=?!?b?!?c?!d?!Gfx.ProcessCommandsGfx.ProcessCommandsGfx.ProcessCommandsPutAllGeometryJobFenceGfx.ProcessCommandsGfx.SetRenderTargetGfx.ProcessCommandsGfx.ProcessCommandsGfx.SetRenderTargetGfx.SetRenderTargetGfx.SetRenderTargetGfx.ProcessCommandsGfx.ProcessCommandsGfx.ProcessCommandsGfx.Proce=?!IdleIdleIdleIdleUnity Job SystemWorker ThreadF?<?!)?<?+???+?!?<?!?<?!?<?!H?<?!(?<?!	=?!?,	=?!IdleIdleIdleIdleIdleIdleRenderForwardAlpha.SortIdleUnity Job SystemWorker Thread?+?!??+?!?<?!?<?!?<?!?<?!?<?!?<?!?<?!@?<?!?<?!?<?!?<?!?<?!*?<?!	=?!	=?!	=?!-
=?!IdleSceneNodesInitJobPrepareSceneNodesSetUpPrepareSceneNodesSetUpPrepareSceneNodesSetUpPrepareSceneNodesSetUpPrepareSceneNodesSetUpPrepareSceneNodesCombineJobIdleRenderForwardOpaque.SortIdleIdleIdleIdleIdleIdleIdleIdlePreloadManagerWorker Thread????
         */

        //  とかなってるので、まずはhexでみてみよう。
        // サイズに関連するところはバリッバリの0なので、それ以外の見方を探すか。固定長のような気がする。
        // で、4000byteかっ飛ばしてみる。
        using (var fs = File.OpenRead("exp")) {
            var by = new byte[3000];

            fs.Read(by, 0, by.Length);
            Debug.LogError("この続きをcharに変換できる気がする。このあたりのフィールドになんかインデックス情報があるのかな。");

            
        }
    }

    private void Some () {
        Profiler.AddFramesFromFile("");
    }
    
    [MenuItem("Window/readfile")] public static void Read () {
        var dataFileProfilerName = "prof/prof_0001";
        var dataFileName = dataFileProfilerName + ".data";
        
        var header = new byte[16];
        
        using (var fs = File.OpenRead(dataFileName)) {
            while (true) {
                // ヘッダサイズ16byte
                fs.Read(header, 0, header.Length);

                int size = GetIntValue(header, 8); // オフセットの前のとこは最初は固定値なんだけど、なんか情報を含んでそう。同じファイルに複数フレーム含んだ場合かな。
                Debug.LogError("データのsize:" + size + " こんだけのサイズのデータがあるはず。");

                
                // 1フレームのデータがこれ。
                var buffer = new byte[size];
                fs.Read(buffer, 0, size);

                // ということで、あとは中身をアレする。
                using (var sw = File.OpenWrite("exp")) {
                    sw.Write(buffer, 0, buffer.Length);
                }


                if (fs.Position == fs.Length) {// read to end.
                    break;
                }
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

    /**
        プロファイルオン/オフの切り替え
     */
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