using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

 /// <summary>
 /// 游戏数据管理类
 /// </summary>
 /// 单例模式
public class GameDataMgr 
{
     //音乐数据对象
     public MusicData musicData;
     //排行榜数据对象
     public RankList rankData;

     private static GameDataMgr instance=new GameDataMgr();
     public static GameDataMgr Instance
     {
        get { return instance; }
     }

     public GameDataMgr()
     {
        //构造函数 初始化游戏数据 
        //音效数据
        musicData=PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        if (!musicData.notFirstTime) //第一次加载数据 进行初始化赋值
        {
             musicData.notFirstTime=true;
             musicData.isOpenBK=true;
             musicData.isOpenSound = true;
             musicData.bkValue=1;
             musicData.SoundValue=1;
             PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
        }
        //排行榜数据
        rankData=PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;
    }

     /// <summary>
     /// 数据改变存储API
     /// </summary>
     /// <param name="isOpen"></param>
     //音效相关
     public void OpenOrCloseBKMusic(bool isOpen)
     {
          musicData.isOpenBK=isOpen;
          BKMusic.Instance.ChangeOpen(isOpen);
          PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
     }
     public void OpenOrCloseSound(bool isOpen)
     {
         musicData.isOpenSound = isOpen;
         PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
     }
     public void ChangeBKValue(float value)
     {
         musicData.bkValue = value;
         BKMusic.Instance.ChangeValue(value);
         PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
     }
     public void ChangeSoundValue(float value)
     {
         musicData.SoundValue = value;
         PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
     }
     
     //排行榜相关
     public void AddRankInfo(string name,int score,float time)
     {
         rankData.list.Add(new RankInfo(name,score,time));
         rankData.list.Sort((a,b)=>a.time<b.time?-1:1 );
         for (int i = rankData.list.Count-1; i >=8; i--)
         {
             rankData.list.RemoveAt(i);
         }
         PlayerPrefsDataMgr.Instance.SaveData(rankData,"Rank");
     }
}
