using UnityEngine;

public static class StageProgress
{
    const string Stage1ClearKey = "stage_clear_stage1";
    const string Stage2ClearKey = "stage_clear_stage2";
    const string Stage3ClearKey = "stage_clear_stage3";

    public static bool IsStage1Cleared() => PlayerPrefs.GetInt(Stage1ClearKey, 0) == 1;

    public static bool IsStage2Cleared() => PlayerPrefs.GetInt(Stage2ClearKey, 0) == 1;

    public static bool IsStage3Cleared() => PlayerPrefs.GetInt(Stage3ClearKey, 0) == 1;

    public static void MarkClearedForScene(string sceneName)
    {
        if (sceneName == "Stage1")
            SetCleared(Stage1ClearKey);
        else if (sceneName == "Stage2")
            SetCleared(Stage2ClearKey);
        else if (sceneName == "Stage3")
            SetCleared(Stage3ClearKey);
    }

    static void SetCleared(string key)
    {
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }
}
