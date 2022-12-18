using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Manager
{
    public sealed class BagManager : ConfigActor<BagManager>
    {
        private int _nowClickItem;

        public Transform BagContent; //背包内容父物体位置
        public GameObject DaoQiButton;

        public GameObject FuluButton;

        public FuluItemData_SO FuluItemData;
        public GameObject Item; //道具预制体

        public GameObject ItemInfor;
        public TextMeshProUGUI ItemIntro;
        public TextMeshProUGUI ItemName;
        public Dictionary<int, int> InventoryDic => InventoryManager.Instance.InventoryDic;

        public override void OnStart()
        {
            //设置对象池获取ID数组
            for (var i = 0; i < FuluItemData.FuluList.Count; i++)
            {
                var obj = Instantiate(Item, BagContent);
                obj.SetActive(false);
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 0, obj);
            }

            InventoryDic.Add(0, 0);
            InventoryDic.Add(1, 1001);
            InventoryDic.Add(2, 1002);
            InventoryDic.Add(3, 1003);
            InventoryDic.Add(4, 1004);
            RefreshBag();
        }

        public void RefreshBag()
        {
            //把原先的背包物体放进对象池
            ClearBag();


            foreach (var i in InventoryDic.Values)
            {
                if (BagContent.Find(i.ToString()))
                {
                    var t = BagContent.Find(i.ToString()).GetChild(0).gameObject;
                    t.GetComponent<TextMeshProUGUI>().text =
                        (int.Parse(t.GetComponent<TextMeshProUGUI>().text) + 1).ToString();
                    continue;
                }

                //获取预制体
                var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 0);
                g.SetActive(true);
                //设置名字为ID
                g.name = i.ToString();
                //设置图像
                g.GetComponent<Image>().sprite = FuluItemData.GetFuluDetail(i).image;
                g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "1";
                //根据ID号判断是符箓还是道器
                g.GetComponent<UIBase>().Type = (i / 1000) switch
                {
                    //符箓
                    0 => UIType.BlankFuLu,
                    1 => UIType.FuLu,
                    //道器
                    2 => UIType.DaoQi,
                    _ => g.GetComponent<UIBase>().Type
                };
            }
        }

        public void ClearBag()
        {
            if (BagContent.childCount <= 0) return;
            for (var i = BagContent.childCount - 1; i >= 0; i--)
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 0, BagContent.GetChild(i).gameObject);
        }

        public void AutoSort()
        {
            InventoryManager.Instance.AutoSort();
        }

        public void AddItem(int t)
        {
            InventoryDic.Add(InventoryDic.Count + 1, t);
            AutoSort();
            RefreshBag();
            SkillManager.Instance.SkillLock(t, SkillLockEventType.GetItem);
        }

        public void RemoveItem(int t)
        {
            if (InventoryDic.ContainsValue(t))
            {
                foreach (var i in InventoryDic)
                    if (i.Value == t)
                    {
                        InventoryDic.Remove(i.Key);
                        break;
                    }
            }
            else
            {
                return;
            }

            AutoSort();
            RefreshBag();
            SkillManager.Instance.SkillLock(t, SkillLockEventType.RemoveItem);
        }

        /// <summary>
        ///     更新内容
        /// </summary>
        public void SetNowInfor(string nam, string intro)
        {
            ItemName.text = nam;
            ItemIntro.text = intro;
        }

        public void SetNowClickItem(int id)
        {
            _nowClickItem = id;
        }

        public int GetNowClickItem()
        {
            return _nowClickItem;
        }
    }
}