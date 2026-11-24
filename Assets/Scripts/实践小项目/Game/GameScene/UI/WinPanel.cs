using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel :BasePanel<WinPanel>
{
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnSure;

    private void Start()
    {
        btnSure.clickEvent+=()=>
        {
            Time.timeScale=1;

            //将数据记录到排行榜中
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text,
            GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);

            //回到主场景
            SceneManager.LoadScene("BeginScene");
        };
        HidePanel();
    }
}
