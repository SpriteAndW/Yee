using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using RootLibrary;

namespace Assets.Script.Manager
{
    public sealed class InventoryManager : HideActor<InventoryManager>
    {
        public Dictionary<int, int> InventoryDic = new();

        public void AddItem(int t)
        {
            InventoryDic.AddItem(t);
        }

        public void RemoveItem(int t)
        {
            InventoryDic.RemoveItem(t);
        }

        public void AutoSort()
        {
            InventoryDic = InventoryDic.AutoSortByValue();
        }
    }
}