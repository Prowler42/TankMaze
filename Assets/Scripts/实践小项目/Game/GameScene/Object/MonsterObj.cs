using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj :TankBaseObj
{
    //实现目标：
    //1.让坦克在两点之间来回移动
    private Transform targetPos;   //当前坦克移动的目标点
    public Transform[] randomPos;  //外部关联位置
    //2.让坦克一直盯着玩家
    public Transform lookAtTarget;
    //3.当目标进入攻击范围 执行开火逻辑
    public float fireDis=20;        //开火距离
    public float fireOffsetTime=1;  //攻击间隔时间
    private float nowTime=0;

    public Transform[] shootPos;       //开火点
    public GameObject bulletObj;      //子弹预设体

    //4.怪物血条绘制
    public Texture maxHPBK;
    public Texture HPBK;
    private Rect maxHPRect;
    private Rect HPRect;
    private float ShowTime;          //控制血条显示的时间
    void Start()
    {
        RandomPos();
    }

    void Update()
    {
         this.transform.LookAt(targetPos);
         this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);

         //若当前距离到目标距离过近时：认为到达目标点
        if (Vector3.Distance(this.transform.position, targetPos.position)<0.05f)
        {
            RandomPos();//重新随机点
        }
        if (lookAtTarget!=null)
        {
            tankFort.LookAt(lookAtTarget);
            if (Vector3.Distance(this.transform.position, lookAtTarget.position)<= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
        
    }
    private void RandomPos()
    {
        if (randomPos.Length==0)
        {
            return;
        }
        targetPos=randomPos[Random.Range(0,randomPos.Length)];
    }
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //在枪口实例化子弹 并 设置子弹的拥有者
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead()
    {
        base.Dead();
        //移动怪物死亡之后需要加分
        GamePanel.Instance.AddScore(10);

    }

    /// <summary>
    /// 绘制怪物血条
    /// </summary>
    private void OnGUI()
    {
        if (ShowTime>0)
        {
            
            ShowTime-=Time.deltaTime;

            //血条要在怪物上方出现
            //1.将世界坐标转换为屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2.将屏幕坐标转换为GUI坐标
            screenPos.y = Screen.height - screenPos.y;

            //底图绘制
            maxHPRect.x = screenPos.x - 50;
            maxHPRect.y = screenPos.y - 70;
            maxHPRect.width = 100;
            maxHPRect.height = 15;
            GUI.DrawTexture(maxHPRect, maxHPBK);
            //血条绘制
            HPRect.x = screenPos.x - 50;
            HPRect.y = screenPos.y - 70;
            HPRect.width = (float)hp / maxHP * 100f;
            HPRect.height = 15;
            GUI.DrawTexture(HPRect, HPBK);
        }
       
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //敌方坦克受伤时设置血条显示
        ShowTime=3;
    }
}
