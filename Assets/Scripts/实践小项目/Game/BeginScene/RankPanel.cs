using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关闭按钮
    public  CustomGUIButton btnClose;
    private List<CustomGUILabel> labPlayer = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            //使用.Find方法找子对象的子对象时，可以使用斜杠来区分父子关系
            labPlayer.Add(this.transform.Find("Name/Labelplayer" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/Labelscore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/Labeltime" + i).GetComponent<CustomGUILabel>());
        }
        btnClose.clickEvent += ()=>
        {  
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };

        HidePanel();
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {
         //根据排行榜数据更新面板
         List<RankInfo> list=GameDataMgr.Instance.rankData.list;
        for (int i = 0; i < list.Count; i++)
        {
            //名字 
            labPlayer[i].content.text=list[i].name;
            //分数
            labScore[i].content.text = list[i].score.ToString();
            //时间
            int time=(int)list[i].time;
            labTime[i].content.text="";
            if (time/3600>0)
            {
                labTime[i].content.text+=time/3600+"h ";
            }
            if (time % 3600 /60 > 0|| labTime[i].content.text!="")
            {
                labTime[i].content.text += time % 3600 / 60 + "min ";
            }
            labTime[i].content.text += time % 60 + "s ";
        }
    }
}
