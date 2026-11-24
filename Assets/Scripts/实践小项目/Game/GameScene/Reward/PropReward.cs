using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{ 
    Atk,
    Def,
    MaxHP,
    Hp,
}

public class PropReward : MonoBehaviour
{
    public E_PropType type=E_PropType.Atk;
    public int changeValue=20;
    //获取特效
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObj player=other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    player.atk+=changeValue;
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.MaxHP:
                    player.maxHP += changeValue;
                    player.hp = player.maxHP;
                    //更新血条
                    GamePanel.Instance.UpdateHP(player.maxHP,player.hp);
                    break;
                case E_PropType.Hp:
                    player.hp += changeValue;
                    if (player.hp>=player.maxHP)
                    {
                        player.hp = player.maxHP;
                    }
                    //更新血条
                    GamePanel.Instance.UpdateHP(player.maxHP, player.hp);
                    break;
                default:
                    break;
            }
            //创建特效
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //设置特效音效
            AudioSource audios = eff.GetComponent<AudioSource>();
            audios.volume = GameDataMgr.Instance.musicData.SoundValue;
            audios.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            Destroy(this.gameObject);
        }
    }
}
