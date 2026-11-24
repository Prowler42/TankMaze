using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //关联奖励预设体
    public GameObject[] rewardObjects;
    //关联死亡特效
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        // 获取碰撞对象的子弹组件
        BulletObj bullet = other.GetComponentInParent<BulletObj>();

        // 不是子弹，或者没有发射者，直接返回
        if (bullet == null || bullet.fatherObj == null)
            return;

        // 只有玩家的子弹才能摧毁立方体
        if (!bullet.fatherObj.CompareTag("Player"))
            return;

        //破坏箱体：触发随机奖励
        int rangeInt = Random.Range(0, 100);
        if (rangeInt<5)
        {
            rangeInt=Random.Range(0,rewardObjects.Length);
            Instantiate(rewardObjects[rangeInt],this.transform.position, this.transform.rotation);
        }
        GameObject effObj=Instantiate(deadEff,this.transform.position,this.transform.rotation);
        AudioSource audios = effObj.GetComponent<AudioSource>();
        audios.volume = GameDataMgr.Instance.musicData.SoundValue;
        audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
