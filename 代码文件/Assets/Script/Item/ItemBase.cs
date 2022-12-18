using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;

namespace Assets.Script.Item
{
    public class ItemBase : Actor
    {
        [Header("Id索引")] public int Id;

        public void AddToInventory()
        {
            InventoryManager.Instance.AddItem(Id);
            ObjectPoolManager.Instance.AddToPool(ObjectType.Item, Id, gameObject);
        }
    }
}