using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Data;
using Assets.Script.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RootLibrary;

namespace Assets.Script.Manager
{
    public sealed class SkillBoxManager : ConfigActor<SkillBoxManager>
    {
        public Dictionary<int, int> SkillDic = new();

        public SkillDatas SkillData;

        public Transform SkillContent; //背包内容父物体位置
        public GameObject Skill; //道具预制体

        public GameObject SkillInfor;
        public TextMeshProUGUI SkillName;
        public TextMeshProUGUI SkillIntro;

        private int _nowClickSkill;

        protected override void Awake()
        {
            base.Awake();
            //设置对象池获取ID数组
            for (int i = 0; i < SkillData.SkillsDatas.Count; i++)
            {
                var obj = Instantiate(Skill, SkillContent);
                obj.SetActive(false);
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 1, obj);
            }
            RefreshSkill();
        }
        public override void OnStart()
        {
            base.OnStart();
        }
        public void RefreshSkill()
        {

            //把原先的背包物体放进对象池
            ClearSkill();

            SkillDic.Add(0, 0);
            SkillDic.Add(1, 1);
            SkillDic.Add(2, 2);
            SkillDic.Add(5, 5);
            SkillDic.Add(6, 6);
            SkillDic.Add(7, 7);




            foreach (var i in SkillDic.Values)
            {
                
                //获取预制体
                var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 1);
                g.SetActive(true);
                //设置名字为ID
                g.name = i.ToString();
                //设置图像
                g.GetComponent<Image>().sprite = SkillData.GetSkillData(i).image;
                //根据ID号判断类型
            }
        }

        public void ClearSkill()
        {
            if (SkillContent.childCount <= 0) return;
            for (var i = SkillContent.childCount - 1; i >= 0; i--)
            {
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 1, SkillContent.GetChild(i).gameObject);
            }
        }

        public void AutoSort()
        {
            SkillDic = SkillDic.AutoSortByValue();
        }

        public void AddSkill(int t)
        {
            if (SkillContent.Find(t.ToString()))
            {
                MessageManager.Instance.ShowMessage("该特技已获得");
                return;
            }
            SkillDic.Add(SkillDic.Count,t);
            AutoSort();
            RefreshSkill();
        }

        public void RemoveSkill(int t)
        {
            AutoSort();
            RefreshSkill();
        }

        /// <summary>
        ///     更新内容
        /// </summary>
        public void SetNowInfor(string name, string intro)
        {
            SkillName.text = name;
            SkillIntro.text = intro;
        }

        public void SetNowClickSkill(int skill_ID)
        {
            _nowClickSkill = skill_ID;
        }

        public int GetNowClickSkill()
        {
            return _nowClickSkill;
        }


    }
}