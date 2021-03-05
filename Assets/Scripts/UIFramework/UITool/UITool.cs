using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理工具，包括获取某个对象组件的操作
/// </summary>
public class UITool
{
    /// <summary>
    /// 当前活动面板
    /// </summary>
    private GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }

    /// <summary>
    /// 添加获取当前活动面板根节点上的组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>() where T : Component
    {
        if (activePanel.GetComponent<T>() == null)
        {
            activePanel.AddComponent<T>();
        }

        return activePanel.GetComponent<T>();
    }

    /// <summary>
    /// 添加获取target对象上的组件
    /// </summary>
    /// <param name="path">对象路径</param>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>(string path) where T : Component
    {
        GameObject target = activePanel.transform.Find(path).gameObject;
        if (target.GetComponent<T>() == null)
        {
            target.AddComponent<T>();
        }

        return target.GetComponent<T>();
    }


}
