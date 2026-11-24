using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //两个多选框和一个按钮控件
    //音乐
    public CustomGUIToggle togMusic;
    public CustomGUISlider silderMusic;
    //音效
    public CustomGUIToggle togSound;
    public CustomGUISlider silderSound;
    //退出
    public CustomGUIButton btnClose;

    void Start()
    {
        silderMusic.changeValue+=(value)=>
        {
            //音乐拖动条
            GameDataMgr.Instance.ChangeBKValue(value);
        };
        silderSound.changeValue += (value) =>
        {
            //音效拖动条
            GameDataMgr.Instance.ChangeSoundValue(value);
        };
        togMusic.changeValue += (value) =>
        {
            //音乐开关
            GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        };
        togSound.changeValue += (value) =>
        {
            //音效开关
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };
        btnClose.clickEvent+=()=>
        {
            this.HidePanel();
            //判断当前所在场景
            if (SceneManager.GetActiveScene().name =="BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
        };
        HidePanel();
    }
   public void UpdataPanelInfo()
   {
        MusicData data=GameDataMgr.Instance.musicData;
        silderMusic.nowValue= data.bkValue;
        silderSound.nowValue = data.SoundValue;
        togMusic.isSel=data.isOpenBK;
        togSound.isSel=data.isOpenSound;

    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdataPanelInfo();
    }
    public override void HidePanel()
    {
        base.HidePanel();
        Time.timeScale = 1.0f;
    }
}
