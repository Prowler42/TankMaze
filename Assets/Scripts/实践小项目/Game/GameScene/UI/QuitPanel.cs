using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton  btnClose;  //关闭面板
    public CustomGUIButton  btnYes;    //退出游戏
    public CustomGUIButton  btnNo;     //继续游戏--关闭面板

    // Start is called before the first frame update
    void Start()
    {
        btnYes.clickEvent+=()=>
        {
            //回到主界面
            SceneManager.LoadScene("BeginScene");
        };
        btnNo.clickEvent += () =>
        {
            //关闭面板
            HidePanel();
        };
        btnClose.clickEvent += () =>
        {
            //关闭面板
            HidePanel();
        };
        HidePanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        Time.timeScale = 1.0f;
    }
}
