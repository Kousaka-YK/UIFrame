using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel() : base(new UIType(path)) { }

    public override void OnEnter()
    {
        base.OnEnter();
        UITool.GetOrAddComponent<Button>("img_Background/btn_Setting").onClick.AddListener(OpenSettingPanel);
        UITool.GetOrAddComponent<Button>("img_Background/btn_GameStart").onClick.AddListener(BtnGameStart);
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

    private void OpenSettingPanel()
    {
        Push(new SettingPanel());
    }

    private void BtnGameStart()
    {
        GameRoot.Instance.SceneSystem.SetScene(new SampleScene());
    }
}
