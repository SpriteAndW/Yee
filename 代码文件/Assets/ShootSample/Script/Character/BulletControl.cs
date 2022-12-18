using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
  
    public int Count = 1; //一次生成的子弹的数量
    public float LifeTime = 4f; //子弹生命周期
    public float CdTime = 0.1f; //子弹间隔时间 =0时只触发一次
    public float Speed = 10; //子弹移动速度
    public float Angle = 0; //旋转角度
    public float Distance = 0; // 子弹间的间隔
    public float SelfRotation = 0; // 每帧自转角度
    public float AddRotation = 0; // 每帧自转角度增量
    public float CenterDis = 0; // 与发射点的距离

    public Color BulletColor = Color.white; //子弹的颜色
    public Vector3 R_Offset = Vector3.zero; //初始旋转的偏移量
    public Vector3 P_Offset = Vector3.zero;  //位置的偏移量
    public float DelayTime = 0;
    Quaternion selfRotation;
    int LimitI = 0;

    bool AutoShoot = false;

    BaseGameObjectPool m_bullet1_pool;
    GameObject m_BulletPrefab;
    private void Start()
    {
        m_BulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet_0");
        m_bullet1_pool = GameObjectPoolManager.Instance.CreatGameObjectPool<BaseGameObjectPool>("Bullet1_Pool");
        m_bullet1_pool.prefab = m_BulletPrefab;
        Quaternion rotation = new Quaternion();
        rotation = Quaternion.Euler(R_Offset.x, R_Offset.y, R_Offset.z);
        selfRotation = transform.rotation * rotation;
        if (CdTime != 0)
        {
            AutoShoot = true;
        }
     
    }
    private void FixedUpdate()
    {
        LimitI++;
        if (AutoShoot)
        {
            Shoot();
        }
    }

   public void Shoot()
    {    SelfRotation += AddRotation;
        SelfRotation = SelfRotation >= 360 ? SelfRotation - 360 : SelfRotation;
     
        var q = Quaternion.Euler(0, SelfRotation, 0) ;
        selfRotation *= q;
        BulletData bulletData = new BulletData();

        bulletData.SetValue(transform.position + P_Offset, selfRotation, Count, LifeTime, Speed, Angle, Distance, BulletColor, DelayTime, CenterDis);
        if (LimitI > CdTime * 50 || CdTime == 0)
        {
            BulletManager.Instance.ShootConfig(bulletData, m_bullet1_pool);
            LimitI = 0;
        }
    }

}
