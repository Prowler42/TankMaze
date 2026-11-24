using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BKMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private static BKMusic instance;
    public static BKMusic Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        instance = this;
        audioSource=this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
    }

    public void ChangeValue(float value)
    {
        audioSource.volume=value;
    }
    public void ChangeOpen(bool isOpen)
    {
        audioSource.mute= !isOpen;
    }
}
