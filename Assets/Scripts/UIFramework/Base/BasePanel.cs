using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有UI面板的父类,包含UI面板的状态信息
/// </summary>
public class BasePanel
{
    /// <summary>
    /// UI信息
    /// </summary>
    /// <value></value>
    public UIType UIType { get; private set; }
    public UITool UITool { get; private set; }
    public PanelManager PanelManager { get; private set; }
    public UIManager UIManager { get; private set; }

    public BasePanel(UIType uIType)
    {
        UIType = uIType;
    }

    public void Iniitalize(UITool uITool)
    {
        UITool = uITool;
    }

    public void Iniitalize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    public void Iniitalize(UIManager uIManager)
    {
        UIManager = uIManager;
    }

    /// <summary>
    /// UI进入时执行的操作，只会执行一次
    /// </summary>
    public virtual void OnEnter()
    {
        UITool.GetOrAddComponent<CanvasGroup>();
        Debug.Log("Base OnEnter");
    }

    /// <summary>
    /// UI暂停时执行的操作
    /// </summary>
    public virtual void OnPause()
    {
        UITool.GetOrAddComponent<CanvasGroup>().interactable = false;
        Debug.Log("Base OnPause");
    }

    /// <summary>
    /// UI继续时执行的操作
    /// </summary>
    public virtual void OnResume()
    {
        UITool.GetOrAddComponent<CanvasGroup>().interactable = true;
        Debug.Log("Base OnResume");
    }

    /// <summary>
    /// UI退出时执行的操作
    /// </summary>
    public virtual void OnExit()
    {
        Debug.Log("Base OnExit");
        UIManager.DestroyUI(UIType);
    }

    /// <summary>
    /// 显示一个面板
    /// </summary>
    /// <param name="panel"></param>
    public void Push(BasePanel panel) => PanelManager?.Push(panel);

    public void Pop() => PanelManager?.Pop();
}
