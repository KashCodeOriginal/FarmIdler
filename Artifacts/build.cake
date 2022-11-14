#addin nuget:?package=Cake.Unity&version=0.9.0

var target = Argument("target", "Build-Android");

Task("Clean-Build")
    .Does(() =>
{
    CleanDirectory($"./Build");
});

Task("Build-Android")
    .IsDependentOn("Clean-Build")
    .Does(() =>
    {
        UnityEditor(
            2022,
            1,
            new UnityEditorArguments
            {
                ExecuteMethod = "Editor.Builder.BuildAndroid",
                BuildTarget = BuildTarget.Android,
                LogFile = "./unity.log"
            },
            new UnityEditorSettings
            {
                RealTimeLog = true
            });
    });

RunTarget(target);