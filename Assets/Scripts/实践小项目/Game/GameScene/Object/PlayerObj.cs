using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class PlayerObj : TankBaseObj
{
    //当前装备的武器
    public WeaponObj nowWeapon;
    //装备武器的位置
    public Transform weaponPos;
    void Start()
    {
        
    }
    void Update()
    {
        #region 1.前进后退
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*moveSpeed*Time.deltaTime);
        #endregion
        #region 2.左右旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        #endregion
        #region 3.炮台旋转
        tankFort.transform.Rotate(Input.GetAxis("Mouse X")*Vector3.up * headRoundSpeed * Time.deltaTime);
        #endregion
        #region 4.开火
        if (Input.GetMouseButtonDown(1))
        {
             Fire();
        }
        #endregion
    }
    //开火方法
    public override void Fire()
    {
        if (nowWeapon!=null)
        {
            nowWeapon.Fire();
        }
    }
    //死亡方法
    public override void Dead()
    {
        //base.Dead(); 玩家为摄像机的父对象
        //不能直接移除玩家
        Time.timeScale=0;
        LosePanel.Instance.ShowPanel();

    }

    //受伤方法
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板血条
        GamePanel.Instance.UpdateHP(this.maxHP,this.hp) ;
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="obj">武器</param>
    public void ChangeWeapon(GameObject weapon)
    {
        //删除当前装备的武器
        if (nowWeapon!=null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon=null;
        }
        //实例化新的武器对象
        //第二个参数：设置武器为XX的子对象
        GameObject weaponobj=Instantiate(weapon,weaponPos,false);
        nowWeapon=weaponobj.GetComponent<WeaponObj>();

        //设置当前武器的拥有者
        nowWeapon.SetFather(this);
    }
}
