using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class ShortCutKeyManager : ConfigActor<ShortCutKeyManager>
    {
        public delegate void Inputs();

        // 四黑 对应Skill
        public int _skillUpID = -1;
        private int _skillDownID;
        public int _skillLeftID = -1;
        private int _skillRightID;
        //四白 对应Item
        //private int _itemUpID;
        public int _itemDownID = -1;
        //private int _itemLeftID;
        public int _itemRightID = -1;

        public Inputs ShortCutKeyInput;

        public void Update()
        {
            ShortCutKeyInput?.Invoke();
        }

        public void UpdateShortCutKey()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("按下Q");
                if(_skillUpID<0)
                {
                    MessageManager.Instance.ShowMessage("该快捷键栏为空");
                    return;
                }
                SkillManager.Instance.UseSkill(_skillUpID);
            }

            if(Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("按下W");
                if (_skillLeftID < 0)
                {
                    MessageManager.Instance.ShowMessage("该快捷键栏为空");
                    return;
                }
                SkillManager.Instance.UseSkill(_skillLeftID);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("按下E");
                if (_skillRightID < 0)
                {
                    MessageManager.Instance.ShowMessage("该快捷键栏为空");
                    return;
                }
                SkillManager.Instance.UseSkill(_skillRightID);
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("按下R"); 
                if (_skillDownID < 0)
                {
                    MessageManager.Instance.ShowMessage("该快捷键栏为空");
                    return;
                }
                SkillManager.Instance.UseSkill(_skillDownID);
            }
        }

        public void Start()
        {
            ShortCutKeyInput += UpdateShortCutKey;
        }

        public void SetSkillUp(int id)
        {
            _skillUpID = id;
        }

        public void SetSkillLeft(int id)
        {
            _skillLeftID = id;
        }

        public void SetSkillDown(int id)
        {
            _skillDownID = id;
        }

        public void SetSkillRight(int id)
        {
            _skillRightID = id;
        }

    }
}
