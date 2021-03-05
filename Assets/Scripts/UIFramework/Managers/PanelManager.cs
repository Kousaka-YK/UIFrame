using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板管理器，用栈存储UI
/// </summary>
public class PanelManager
{
    /// <summary>
    /// 存储UI的栈
    /// </summary>
    private Stack<BasePanel> stackPanel;

    /// <summary>
    /// UI管理器
    /// </summary>
    private UIManager uIManager;

    private BasePanel basePanel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uIManager = new UIManager();
    }

    /// <summary>
    /// UI的入栈操作，此操作会显示一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            basePanel = stackPanel.Peek();
            basePanel.OnPause();
        }
        stackPanel.Push(nextPanel);
        GameObject panel = uIManager.GetSingleUI(nextPanel.UIType);
        nextPanel.Iniitalize(new UITool(panel));
        nextPanel.Iniitalize(this);
        nextPanel.Iniitalize(uIManager);
        nextPanel.OnEnter();
    }

    /// <summary>
    /// UI出栈操作，关闭当前UI面板
    /// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnResume();
        }
    }

    /// <summary>
    /// 清空所有面板
    /// </summary>
    public void PopAll()
    {
        while (stackPanel.Count > 0)
        {
            stackPanel.Pop().OnExit();
        }
    }
}
