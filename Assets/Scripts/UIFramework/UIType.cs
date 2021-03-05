﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储单个UI的信息 包括名字和路径
/// </summary>
public class UIType
{
    /// <summary>
    /// UI Name
    /// </summary>
    /// <value></value>
    public string Name { get; private set; }
    /// <summary>
    /// UI Path
    /// </summary>
    /// <value></value>
    public string Path { get; private set; }


    public UIType(string path)
    {
        Name = path.Substring(path.LastIndexOf('/') + 1);
        Path = path;
    }
}
