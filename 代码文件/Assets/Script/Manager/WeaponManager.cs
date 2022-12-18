using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Script.Weapon;
using RootLibrary;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Manager
{
    public class WeaponManager : HideActor<WeaponManager>
    {
        public delegate void WeaponEmploy();


        public List<WeaponData> Datas = new();
        public WeaponBase NowWeapon;
        public List<WeaponBase> WeaponCollects = new();
        public Dictionary<int, WeaponEmploy> WeaponEmployDic = new();

        public Dictionary<int, int> Inventory => InventoryManager.Instance.InventoryDic;

        private float _currentTime;
        private float _coolingTime;
        private Transform _nowWeapon;
        private bool _isCanUseWeapon = true;


        public void Update()
        {
            if (!_isCanUseWeapon) UpdateCoolingTime();
        }

        public void CreateWeapon(int id)
        {
            var canCreate = true;
            foreach (var data in Datas[id].InitData.CreateMaterials)
                if (!Inventory.ContainsKey(data.Key))
                {
                    canCreate = false;
                    break;
                }

                else if (Inventory.ContainsKey(data.Key))
                {
                    if (Inventory[data.Key] >= data.Value) continue;
                    canCreate = false;
                    break;
                }

            if (canCreate)
                foreach (var data in Datas[id].InitData.CreateMaterials)
                    Inventory[data.Key] -= data.Value;

            BagManager.Instance.AddItem(id);

            WeaponBase t = new();
            t.Init();
            WeaponCollects.Add(t);
        }

        public Vector3 RayCastMouse()
        {
            return LibV.GetMouseRayPosition();
        }

        public void EmployNowWeapon()
        {
            NowWeapon.Employ();
        }

        public void LastWeapon()
        {
            NowWeapon = NowWeapon.LastOne(WeaponCollects);
        }

        public void NextWeapon()
        {
            NowWeapon = NowWeapon.NextOne(WeaponCollects);
        }

        public void WeaponSwitch()
        {

        }

        public void WeaponTaoMu()
        {

        }


        public void UseWeapon(Transform weapon)
        {
            if (!_isCanUseWeapon) return;
            _nowWeapon = weapon;
            _coolingTime = 3.0f;
            _currentTime = 0.0f;
            _nowWeapon.GetChild(0).GetComponent<Image>().fillAmount = 1.0f;
            _isCanUseWeapon = false;
        }

        public void UpdateCoolingTime()
        {
            if (_currentTime < _coolingTime)
            {
                _currentTime += Time.deltaTime;
                _nowWeapon.GetChild(0).GetComponent<Image>().fillAmount = 1 - _currentTime / _coolingTime;
            }
            else _isCanUseWeapon = true;
        }
    }
}