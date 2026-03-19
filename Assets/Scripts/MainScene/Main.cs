using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void OnEnable()
    {
        ApplyStageButtonVisibility();
    }

    void Start()
    {
        ApplyStageButtonVisibility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToExit() 
    {
        Application.Quit();
    }

    void ApplyStageButtonVisibility()
    {
        SetButtonVisible("Stage1Button", true);
        SetButtonVisible("Stage2Button", StageProgress.IsStage1Cleared());
        SetButtonVisible("Stage3Button", StageProgress.IsStage2Cleared());
    }

    void SetButtonVisible(string objectName, bool visible)
    {
        var button = GameObject.Find(objectName);
        if (button != null)
            button.SetActive(visible);
    }

    public void ToStage1()
    {
        LoadSceneIfAvailable("Stage1");
    }

    public void ToStage2()
    {
        if (!StageProgress.IsStage1Cleared())
            return;

        LoadSceneIfAvailable("Stage2");
    }

    public void ToStage3()
    {
        if (!StageProgress.IsStage2Cleared())
            return;

        LoadSceneIfAvailable("Stage3");
    }

    void LoadSceneIfAvailable(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
            SceneManager.LoadScene(sceneName);
    }
}
