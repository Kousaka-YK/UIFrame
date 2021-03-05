using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/SettingPanel";
    public SettingPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        base.OnEnter();
        UITool.GetOrAddComponent<Button>("img_Background/btn_Close").onClick.AddListener(ButtonClick);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void ButtonClick()
    {
        Pop();
    }
}
