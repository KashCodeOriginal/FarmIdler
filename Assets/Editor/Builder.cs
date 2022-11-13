using System;
using UnityEditor;
using UnityEditor.Build.Reporting;
using static UnityEditor.BuildPipeline;

namespace Editor
{
    public static class Builder
    {
        [MenuItem("Build/Android")]
        public static void BuildAndroid()
        {
            var report = BuildPlayer(
                new BuildPlayerOptions {
            target = BuildTarget.Android,
            locationPathName = "C:/Users/Lindf/Documents/GitHub/TestTaskForLavaProject/Build/Build.apk",
            scenes = new []{"Assets/Scenes/Bootstrap.unity"}
                });
            
            if (report.summary.result != BuildResult.Succeeded)
            {
                throw new Exception("Failed to build android package");
            }
            
        }
    }
}

