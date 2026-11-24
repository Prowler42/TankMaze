using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;    //用于实例化的子弹
    public Transform[] shootPos; //炮管位置  
    public TankBaseObj fatherObj;//武器的拥有者
    public void SetFather(TankBaseObj obj)
    {
        fatherObj=obj;
    }
    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
             //创建子弹预设体   
             GameObject obj=Instantiate(bullet,shootPos[i].position,shootPos[i].rotation);
             BulletObj  bulletObj=obj.GetComponent<BulletObj>();
             bulletObj.SetFather(fatherObj);//找到子弹的根发射对象【X炮管 ✓坦克】
        }
    }
}
