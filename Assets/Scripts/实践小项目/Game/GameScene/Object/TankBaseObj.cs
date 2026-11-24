using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHP;
    public int hp;

    public float moveSpeed=10;        //移动
    public float roundSpeed=100;      //旋转
    public float headRoundSpeed=100;  //炮台旋转

    public GameObject deadEff;        //死亡特效
    public Transform tankFort;        //炮台

    //抽象方法--->子类进行重写
    /// <summary>
    /// 开火方法
    /// </summary>
    public abstract void Fire();  
   
    /// <summary>
    /// 受击方法
    /// </summary>
    /// <param name="other">进行攻击的对象</param>
    public virtual void Wound(TankBaseObj other)
    {
        int dmg =other.atk-this.def;
        if (dmg<=0)
        {
            return ;
        }
        this.hp-=dmg;
        if (this.hp<=0)
        {
            this.hp=0;
            this.Dead();
        }
    }

    /// <summary>
    /// 死亡方法
    /// </summary>
    public virtual void Dead()
    {
        //对象死亡：在场景上移除对象
        Destroy(this.gameObject);
        if (deadEff !=null)
        {
            //在实例化对象的同时 设置位置和角度
            GameObject effobj=Instantiate(deadEff,this.transform.position,this.transform.rotation);

            //控制预设体身上的音效
            AudioSource audioSource =effobj.GetComponent<AudioSource>();
            //设置音效大小
            audioSource.volume=GameDataMgr.Instance.musicData.SoundValue;
            //控制音效播放
            audioSource.mute=!GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }
    }
    
}
