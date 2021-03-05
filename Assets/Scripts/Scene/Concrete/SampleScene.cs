using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SampleScene场景管理
/// </summary>
public class SampleScene : SceneState
{
    readonly string sampleScene = "SampleScene";

    PanelManager panelManager;
    public override void OnEnter()
    {
        panelManager = new PanelManager();
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += SceneLoaded;
        panelManager.PopAll();
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    /// <summary>
    /// 场景加载完毕后执行的方法
    /// </summary>
    /// <param name="scene">场景</param>
    /// <param name="loadSceneMode">加载模式</param>
    public void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        panelManager.Push(new StartPanel());
        Debug.Log("场景加载完毕");
    }
}
