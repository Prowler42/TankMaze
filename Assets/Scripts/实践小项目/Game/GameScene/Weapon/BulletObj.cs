using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50f; 
    public TankBaseObj fatherObj; //发射子弹的对象
    public GameObject effObj;
    void Start()
    {
        
    }

    void Update()
    {
         this.transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }
    //子弹发生碰撞
    private void OnTriggerEnter(Collider other)
    {
        // 发射者已经死亡，销毁这颗子弹
        if (fatherObj == null)
        {
            Destroy(this.gameObject);
            return;
        }

        //射击立方体和固定不动的敌方坦克会爆炸
        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
        {
            //判断是否受伤
            TankBaseObj obj=other.GetComponent<TankBaseObj> ();   
            if (obj!=null) 
            {
               obj.Wound(fatherObj);
            }
            //同时触发碰撞特效
            if (effObj!=null)
            {
                GameObject eff =Instantiate(effObj,this.transform.position, this.transform.rotation);
                //设置开火音效
                AudioSource audios=eff.GetComponent <AudioSource> ();
                audios.volume=GameDataMgr.Instance.musicData.SoundValue;
                audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            }
            Destroy(this.gameObject);
        }
        
    }
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
