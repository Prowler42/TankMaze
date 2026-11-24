using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weaponObj;
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        //若触发trigger的物体是玩家
        if (other.CompareTag("Player") )
        {
            //切换武器
            //切换武器
            int index=Random.Range(0,weaponObj.Length);
            PlayerObj player =other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);
            //播放奖励特效
            GameObject eff=Instantiate(getEff,this.transform.position,this.transform.rotation);
            AudioSource audios = eff.GetComponent<AudioSource>();
            audios.volume = GameDataMgr.Instance.musicData.SoundValue;
            audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //销毁现在的标志
            Destroy(this.gameObject);
        }                    
    }
    
    
}
