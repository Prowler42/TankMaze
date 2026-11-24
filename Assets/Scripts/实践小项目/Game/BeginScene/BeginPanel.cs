using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //关联按钮控件
    //开始游戏
    public CustomGUIButton btnBegin;
    //设置游戏                
    public CustomGUIButton btnSetting;
    //退出游戏                
    public CustomGUIButton btnExit;
    //排行榜                  
    public CustomGUIButton btnRank;

    void Start()
    {
        //控制坦克头部转向【鼠标锁定与窗口内】
        Cursor.lockState = CursorLockMode.Confined;

        btnBegin.clickEvent +=() =>
        {
            //切换到游戏场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowPanel();
            HidePanel();
        };
        btnExit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowPanel();
            HidePanel();
        };
    }
}
