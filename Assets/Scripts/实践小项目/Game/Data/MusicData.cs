using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音乐音效数据类
/// </summary>
/// 用于存储设置面板的数据信息
public class MusicData 
{
    /// <summary>
    /// 要存储的数据
    /// </summary>
    //1.音乐是否开关   
    public bool isOpenBK;
    //2.音效是否开关
    public bool isOpenSound;

    //3.音乐音量大小
    public float bkValue;
    //4.音效音量大小
    public float SoundValue;

    //初始化数据
    public bool notFirstTime=false;
}
