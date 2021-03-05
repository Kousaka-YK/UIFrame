using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 全局管理的一些东西
/// </summary>
public class GameRoot : MonoBehaviour
{
    /// <summary>
    /// 全局管理单例
    /// </summary>
    public static GameRoot Instance { get; private set; }

    /// <summary>
    /// 场景管理器
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }

    /// <summary>
    /// 显示一个面板
    /// </summary>
    public UnityAction<BasePanel> Push { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneSystem = new SceneSystem();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }

    /// <summary>
    /// 显示panel面板
    /// </summary>
    /// <param name="push"></param>
    private void SetPanel(UnityAction<BasePanel> push)
    {
        Push = push;
    }
}
