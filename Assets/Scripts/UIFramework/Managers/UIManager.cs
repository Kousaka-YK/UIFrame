using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储所有UI信息，并可以创建或销毁UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// 存储所有UI信息的字典
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }


    /// <summary>
    /// 创建UI对象
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (!canvas)
        {
            Debug.LogError("canvas 不存在");
            return null;
        }

        if (!dicUI.ContainsKey(type))
        {
            GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), canvas.transform);
            dicUI.Add(type, ui);
        }
        return dicUI[type];
    }

    /// <summary>
    /// 删除UI对象
    /// </summary>
    /// <param name="type"></param>
    public void DestroyUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }
}
