using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //关联场景上的控件对象
    public CustomGUILabel LabScore;     //得分
    public CustomGUILabel LabTime;      //时间
    public CustomGUIButton btnQuit;     //退出
    public CustomGUIButton btnSetting;  //设置
    public CustomGUITexture TexHP;      //血量

    /// <summary>
    /// 记录当前玩家的当前分数和时间
    /// </summary>
    [HideInInspector]
    public int nowScore =0 ;
    [HideInInspector]
    public float nowTime= 0;
    private int time;

    void Start()
    {
        btnSetting.clickEvent+=()=>
        {
            SettingPanel.Instance.ShowPanel();

            //打开面板时不继续计时
            Time.timeScale=0;
        };
        btnQuit.clickEvent += () =>
        {
           //返回游戏初始界面
           //弹出一个确定退出的按钮
           QuitPanel.Instance.ShowPanel();

            //打开面板时不继续计时
            Time.timeScale = 0;
        };
    }

    void Update()
    {
        nowTime+=Time.deltaTime;
        //换算时间
        time = (int)nowTime;
        LabTime.content.text = "";
        if (time / 3600 > 0)
        {
            LabTime.content.text += time / 3600 + "h ";
        }
        if (time % 3600 / 60 > 0 || LabTime.content.text != "")
        {
            LabTime.content.text += time % 3600 / 60 + "min ";
        }
        LabTime.content.text += time % 60 + "s ";
    }

    /// <summary>
    /// 得分方法
    /// </summary>
    public void AddScore(int score)
    {
        nowScore+=score;
        //更新面板显示
        LabScore.content.text = nowScore.ToString();
    }

    /// <summary>
    /// 扣血方法
    /// </summary>
    public void UpdateHP(int maxHP,int HP)
    {
        TexHP.guiPos.width=(float)HP/maxHP *300;
    }
}
