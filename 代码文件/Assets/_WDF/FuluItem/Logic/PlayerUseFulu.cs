// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Assets.Plugins.System;
// using Assets.Script.AI;
// using Assets.Script.Manager;
// using UnityEngine;
// using DG.Tweening;
//
// public class PlayerUseFulu : MonoBehaviour
// {
//     private PlayerState playerState;
//
//     [Header("符箓相关")] public int currentFuluID;
//     public UseFuluType useFuluType; //使用符箓类型
//     [Header("测试使用符箓(按E)")] public bool isUse;
//
//     public GameObject wallClone; //墙壁预制体
//     public GameObject blackSmoke; //烟雾预制体
//
//     private void Awake()
//     {
//         playerState = GetComponent<PlayerState>();
//     }
//
//
//     private void Update()
//     {
//         //测试符箓使用效果
//         if (isUse)
//         {
//             isUse = false;
//             UseFulu(currentFuluID, useFuluType);
//         }
//     }
//
//
//     /// <summary>
//     /// 使用符箓得到的效果
//     /// </summary>
//     /// <param name="fuluID">符箓ID</param>
//     /// <param name="useFuluType">使用类型</param>
//     private void UseFulu(int fuluID, UseFuluType useFuluType)
//     {
//         // FuluDetail fuluDetail = fuluItemDataSo.GetFuluDetail(fuluID);
//
//         switch (fuluID)
//         {
//             case 1001:
//                 Fulu_KuiShui(useFuluType);
//                 break;
//             case 1002:
//                 Fulu_YangHuo(useFuluType);
//                 break;
//             case 1003:
//                 Fulu_TuHeChe(useFuluType);
//                 break;
//             case 1004:
//                 Fulu_ChangSheng(useFuluType);
//                 break;
//         }
//     }
//
//     #region 各符箓使用效果
//
//     private void Fulu_KuiShui(UseFuluType useFuluType)
//     {
//         switch (useFuluType)
//         {
//             case UseFuluType.化符水:
//                 //获得符箓影响范围内的所有对象
//                 Collider[] colliders = Physics.OverlapSphere(transform.position, playerState.fuluEffectRadius);
//                 foreach (var coll in colliders)
//                 {
//                     var PetController = coll.gameObject.GetComponent<PetController>();
//                     if (PetController)
//                     {
//                         //将所有宠物Hp回复满
//                         PetController.curHp = PetController.maxHp;
//                     }
//
//                     //敌人听见玩家
//                     var enemyAI = coll.GetComponent<AIBase>();
//                     if (enemyAI)
//                     {
//                         Debug.Log("敌人听见了");
//                         enemyAI.AISense[AIStimulator.Hear] = true;
//                         enemyAI.HearPos = transform.position;
//                     }
//                 }
//
//                 break;
//             case UseFuluType.燃烧:
//                 //获得:破火阵的符箓,添加到背包
//                 BagManager.Instance.AddItem(1005);
//                 break;
//             case UseFuluType.吞服:
//                 //治疗自己,Hp回复满
//                 playerState.playerCurHp = playerState.playerMaxHp;
//                 break;
//         }
//     }
//
//     private void Fulu_YangHuo(UseFuluType useFuluType)
//     {
//         switch (useFuluType)
//         {
//             case UseFuluType.化符水:
//                 //治疗寒毒
//                 playerState.isHanDuing = false;
//                 break;
//             case UseFuluType.燃烧:
//                 //TODO:燃烧特效
//                 //点燃一个区域,造成伤害+点燃场景可点燃的物品
//                 Collider[] colliders = Physics.OverlapSphere(transform.position, playerState.fuluEffectRadius);
//                 foreach (var coll in colliders)
//                 {
//                     var enemyController = coll.gameObject.GetComponent<EnemyController>();
//                     if (enemyController)
//                     {
//                         //对所有敌人造成伤害
//                         enemyController.curHp -= 20;
//                         //敌人状态改变
//                         enemyController.gameObject.GetComponent<AIBase>().AISense[AIStimulator.Pain] = true;
//                     }
//
//                     var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
//                     if (otherThingController)
//                     {
//                         // if (otherThingController.otherType == OtherThingType.可燃烧)
//                         // {
//                         //     //点燃场景可点燃的物品(目前是销毁)
//                         //     Debug.Log(coll.gameObject.name + "燃烧起来了(被销毁)");
//                         //     Destroy(otherThingController.gameObject);
//                         // }
//                     }
//                 }
//
//                 break;
//             case UseFuluType.吞服:
//                 //获得道器:水火
//                 BagManager.Instance.AddItem(2001);
//                 break;
//         }
//     }
//
//     private void Fulu_TuHeChe(UseFuluType useFuluType)
//     {
//         switch (useFuluType)
//         {
//             case UseFuluType.化符水:
//                 //TODO:特效 洒在地面,打开地道
//                 Collider[] colliders = Physics.OverlapSphere(transform.position, playerState.fuluEffectRadius);
//                 foreach (var coll in colliders)
//                 {
//                     var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
//                     if (otherThingController)
//                     {
//                         // if (otherThingController.otherType == OtherThingType.下有地道)
//                         // {
//                         //     Destroy(otherThingController.gameObject);
//                         // }
//                     }
//                     
//                     //敌人听见玩家
//                     var enemyAI = coll.GetComponent<AIBase>();
//                     if (enemyAI)
//                     {
//                         enemyAI.AISense[AIStimulator.Hear] = true;
//                         enemyAI.HearPos = transform.position;
//                     }
//                 }
//
//                 break;
//             case UseFuluType.燃烧:
//                 //TODO:升起土墙(可放入对象池)
//                 var wall = Instantiate(wallClone, transform.position + Vector3.forward * 10, Quaternion.identity);
//                 
//                 break;
//             case UseFuluType.吞服:
//                 //TODO:控制时间 玩家穿墙（完成）
//                 gameObject.GetComponent<Collider>().isTrigger = true;
//                 gameObject.GetComponent<Rigidbody>().useGravity = false;
//                 break;
//         }
//     }
//
//     private void Fulu_ChangSheng(UseFuluType useFuluType)
//     {
//         switch (useFuluType)
//         {
//             case UseFuluType.化符水:
//                 //TODO:洒在地面,使植物快速生长
//                 Collider[] colliders = Physics.OverlapSphere(transform.position, playerState.fuluEffectRadius);
//                 foreach (var coll in colliders)
//                 {
//                     var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
//                     if (otherThingController)
//                     {
//                         //植物生长（目前只是普通的把Scale变大两倍）
//                         // if (otherThingController.otherType == OtherThingType.植物)
//                         // {
//                         //     Vector3 tempScale = otherThingController.gameObject.transform.localScale;
//                         //     otherThingController.transform.DOScale(tempScale * 2, 2);
//                         // }
//                     }
//                     
//                     //敌人听见玩家
//                     var enemyAI = coll.GetComponent<AIBase>();
//                     if (enemyAI)
//                     {
//                         enemyAI.AISense[AIStimulator.Hear] = true;
//                         enemyAI.Target = transform;
//                     }
//                 }
//
//                 break;
//             case UseFuluType.燃烧:
//                 //TODO:化出浓雾,敌人进入迷雾后会失明,直到受到攻击为止(敌人失明效果没做)
//                 var smoke = Instantiate(blackSmoke, transform.position + Vector3.forward * 30, Quaternion.identity);
//                 smoke.transform.DOScale(smoke.transform.localScale * 3, 2f);
//                 break;
//             case UseFuluType.吞服:
//                 //TODO:治疗一切负面buff（还有其他）
//                 playerState.isHanDuing = false;
//                 break;
//         }
//     }
//
//     #endregion
// }