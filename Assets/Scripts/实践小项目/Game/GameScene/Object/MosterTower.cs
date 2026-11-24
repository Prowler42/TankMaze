using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterTower : TankBaseObj
{
    //间隔开火时间
    public float fireOffsetTime=1;
    private float nowTime=0;
    //发射位置
    public Transform[] shootPos;

    //关联子弹预设体
    public GameObject bulletObj;

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
             //在枪口实例化子弹 并 设置子弹的拥有者
             GameObject obj= Instantiate(bulletObj,shootPos[i].position,shootPos[i].rotation);
             BulletObj bullet =obj.GetComponent<BulletObj>();
             bullet.SetFather(this);
        }
    }

    void Update()
    {
        nowTime+=Time.deltaTime;
        if (nowTime>=fireOffsetTime)
        {
            Fire();
            nowTime=0;
        }
    }

    public override void Wound(TankBaseObj other)
    {
        //固定不动的敌方坦克不会受伤
    }
}
