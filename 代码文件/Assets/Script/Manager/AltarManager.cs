using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Script.Characters;
using Assets.Script.Manager;
using Assets.Plugins.Script.BaseClass.Active;

namespace Assets.Script.Manager
{
    public class AltarManager : ConfigActor<AltarManager>
    {
        public GameObject PlayerInfor;
        public YiChingPlayer Player => PlayerManager.Instance.Player;
        public Image Hp;
        public Image Mp;
        public TextMeshProUGUI LevelName;

        public void CheckPlayerInfor()
        {
            PlayerInfor.GetComponent<Canvas>().enabled = !PlayerInfor.GetComponent<Canvas>().enabled;
            Hp.fillAmount = Player.HP / Player.MaxHP;
            Mp.fillAmount = Player.MP / Player.MaxMP;
            if(SkillManager.Instance.DebuffSkillDic.ContainsKey(4)) PlayerManager.Instance.RemoveBC();
            if(SkillManager.Instance.DebuffSkillDic.ContainsKey(3)) PlayerManager.Instance.RemoveIB();
            if(SkillManager.Instance.DebuffSkillDic.ContainsKey(8)) PlayerManager.Instance.RemoveQD();


        }

        public void StorePlayer()
        {
            RunTimeManager.Instance.Save();
        }


        public void ReSpawn()
        {
            RunTimeManager.Instance.Load();
        }


    }
}
