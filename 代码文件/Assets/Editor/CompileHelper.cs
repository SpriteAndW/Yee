using System.IO;
using UnityEditor;
using UnityEditor.Build.Player;
using UnityEngine;

namespace Assets.Editor
{
    public static class CompileDllHelper
    {
        [MenuItem("基本工具/编译dll")]
        public static void CompileDll()
        {
            var tempOutputPath = $"{Application.dataPath}/../dll";
            Directory.CreateDirectory(tempOutputPath);
            var scriptCompilationSettings = new ScriptCompilationSettings
            {
                subtarget = 0,
                target = 0,
                group = BuildTargetGroup.Unknown,
                options = ScriptCompilationOptions.None,
                extraScriptingDefines = new string[]
                {
                }
            };
            scriptCompilationSettings.group = BuildPipeline.GetBuildTargetGroup(BuildTarget.StandaloneWindows64);
            scriptCompilationSettings.target = BuildTarget.StandaloneWindows64;
            PlayerBuildInterface.CompilePlayerScripts(scriptCompilationSettings, tempOutputPath);
        }
    }
}