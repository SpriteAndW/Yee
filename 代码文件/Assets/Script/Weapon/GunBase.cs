using System.Collections;
using UnityEngine;

namespace Assets.Script.Weapon
{
    public class GunBase : WeaponBase
    {
        //发射子弹委托
        public delegate void FireBullet();

        public delegate void GunInputs();

        [Header("携带子弹数")] public int CarryAmmo;
        [Header("弹夹子弹数")] public int ClipAmmo;
        [Header("子弹伤害")] public float Damage;
        public GunInputs DoReload;
        public GunInputs DoShoot;
        [Header("正在开火")] public bool IsFiring;
        [Header("是否连发")] public bool IsRepeat;
        [Header("当前子弹数")] public int NowAmmo;
        [Header("射程")] public float Range;

        [Header("射速")] public float Rate;

        //射线检测
        public FireBullet RayCastBullet;

        //每单位射速射出子弹数
        public float ShootRate
        {
            set => Rate = value;
            get => 1.0f / Rate;
        }

        public override void Init()
        {
        }

        public override void Employ()
        {
        }

        public void Start()
        {
            DoShoot += InputDoShoot;
            DoReload += InputDoReload;
        }

        public void InputDoShoot()
        {
            if (Input.GetMouseButton(0)) Shoot();
            if (!Input.GetMouseButtonUp(0)) return;
            IsFiring = false;
            StopAllCoroutines();
        }

        public void InputDoReload()
        {
            if (Input.GetKeyDown(KeyCode.R)) Reload();
        }

        public void Update()
        {
            DoShoot?.Invoke();
            DoReload?.Invoke();
        }

        public void Reload()
        {
            if (NowAmmo >= ClipAmmo) return;
            if (CarryAmmo <= 0) return;
            var drain = ClipAmmo - NowAmmo;
            if (CarryAmmo > drain)
            {
                CarryAmmo -= drain;
                NowAmmo = ClipAmmo;
            }
            else
            {
                NowAmmo += CarryAmmo;
                CarryAmmo = 0;
            }
        }

        public void ShootBullet()
        {
            NowAmmo--;
            RayCastBullet?.Invoke();
        }

        public IEnumerator Repeating()
        {
            IsFiring = true;
            while (NowAmmo > 0)
            {
                ShootBullet();
                yield return new WaitForSeconds(ShootRate);
            }

            IsFiring = false;
        }

        public IEnumerator Fire()
        {
            IsFiring = true;
            ShootBullet();
            yield return new WaitForSeconds(ShootRate);
            IsFiring = false;
        }

        public void Shoot()
        {
            if (NowAmmo <= 0 || IsFiring) return;
            StartCoroutine(IsRepeat ? Repeating() : Fire());
        }
    }
}