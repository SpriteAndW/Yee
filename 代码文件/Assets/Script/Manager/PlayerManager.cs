using System;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.AI;
using Assets.Script.Characters;
using DG.Tweening;
using RootLibrary;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Script.Manager
{
    public sealed class PlayerManager : HideActor<PlayerManager>
    {
        [Header("DeBuff状态影响字典")] public Dictionary<int, Action> DeBuffDic = new();
        [Header("画符成功概率")] public float DrawRate = 1f / 6f;
        [Header("现在DeBuff状态")] public List<int> NowDeBuffStates = new();
        [Header("玩家")] public YiChingPlayer Player;

        [Header("Buff状态影响字典")] public Dictionary<int, Action> BuffDic = new();
        [Header("现在buff状态")] public List<int> NowBuffStates = new();

        [Header("符箓字典")] public Dictionary<int, Action<SymbolType>> SymbolDic = new();

        [Header("符箓影响范围")] public float SymbolEffectRadius = 10f;
        

        public PlayerManager()
        {
            Init();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            DeBuffDic.Add(0, ColdToxin);
            DeBuffDic.Add(1, QingDao);
            DeBuffDic.Add(2, IllusionBlinding);
            DeBuffDic.Add(3, BeConfused);
            SymbolDic.Add(0, KuiShui);
            SymbolDic.Add(1, YangHuo);
            SymbolDic.Add(2, TuHeChe);
            SymbolDic.Add(3, ChangSheng);

            BuffDic.Add(0, TieHuanZhu_Buff);
            BuffDic.Add(1, ThroughWall);
            BuffDic.Add(2, IncreaseDrawRate);
        }

        /// <summary>
        ///     用出符箓
        /// </summary>
        public void ApplySymbol(int id, SymbolType t)
        {
            SymbolDic[id](t);
        }

        /// <summary>
        ///     增加DeBuff状态
        /// </summary>
        public void AddDeBuffState(int id)
        {
            if (DeBuffDic.ContainsKey(id) && !NowDeBuffStates.Contains(id)) NowDeBuffStates.Add(id);
        }

        /// <summary>
        ///     DeBuff状态影响
        /// </summary>
        public void DeBuffStateAffect()
        {
            foreach (var t in NowDeBuffStates)
                DeBuffDic[t]();
        }

        /// <summary>
        ///     增加Buff状态
        /// </summary>
        public void AdduffState(int id)
        {
            if (BuffDic.ContainsKey(id) && !NowBuffStates.Contains(id)) NowBuffStates.Add(id);
        }

        /// <summary>
        ///     Buff状态影响
        /// </summary>
        public void BuffStateAffect()
        {
            foreach (var t in NowBuffStates)
                BuffDic[t]();
        }

        /// <summary>
        ///     画符
        /// </summary>
        public bool DrawSymbol()
        {
            return MathV.RandomV.NextDouble() < DrawRate;
        }

        /// <summary>
        ///     符箓影响范围可视化
        /// </summary>
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Player.transform.position, SymbolEffectRadius);
        }

        #region DeBuff

        /// <summary>
        ///     寒毒
        /// </summary>
        public void ColdToxin()
        {
            Player.Speed /= 2;
        }
        
        
        /// <summary>
        ///     倾倒
        /// </summary>
        public void QingDao()
        {
            SkillManager.Instance.UseSkill(8);
        }

        public void RemoveQD()
        {
            SkillManager.Instance.StopSkill(8);
        }

        /// <summary>
        ///     （中）障眼法状态
        /// </summary>
        public void IllusionBlinding()
        {
            SkillManager.Instance.UseSkill(3);
        }

        /// <summary>
        ///     移除障眼法状态
        /// </summary>
        public void RemoveIB()
        {
            SkillManager.Instance.StopSkill(3);
        }

        /// <summary>
        ///     迷魂
        /// </summary>
        public void BeConfused()
        {
            SkillManager.Instance.UseSkill(4);
        }

        /// <summary>
        ///     移除迷魂状态
        /// </summary>
        public void RemoveBC()
        {
            SkillManager.Instance.StopSkill(4);
        }

        #endregion

        #region Buff

        /// <summary>
        ///     人物buff，效果是怪物将无法追踪玩家
        /// </summary>
        public void TieHuanZhu_Buff()
        {
            //是一个状态,玩家只要有这个状态,敌人就无法追玩家,攻击敌人除外
        }

        /// <summary>
        ///     土河车吞服效果,穿墙
        /// </summary>
        public void ThroughWall()
        {
            Player.gameObject.GetComponent<Collider>().isTrigger = true;
            Player.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

        /// <summary>
        ///     进入神坛,获得提高画符成功概率buff
        /// </summary>
        public void IncreaseDrawRate()
        {
            DrawRate += 1 / 3;
        }

        #endregion

        #region Symbol

        /// <summary>
        ///     葵水
        /// </summary>
        public void KuiShui(SymbolType t)
        {
            switch (t)
            {
                case SymbolType.RuneWater:
                    //获得符箓影响范围内的所有对象
                    var collides = Physics.OverlapSphere(Player.transform.position, SymbolEffectRadius);
                    foreach (var i in collides)
                    {
                        var one = i.gameObject.GetComponent<Role>();
                        if (one)
                            //将所有宠物Hp回复满
                            one.HP = one.MaxHP;

                        //敌人听见玩家
                        var enemyAI = i.GetComponent<AIBase>();
                        if (enemyAI)
                        {
                            Debug.Log("敌人听见了");
                            enemyAI.AISense[AIStimulator.Hear] = true;
                            enemyAI.HearPos = Player.transform.position;
                        }
                    }

                    break;
                case SymbolType.Burning:
                    //获得:破火阵的符箓,添加到背包
                    //BagManager.Instance.InventoryDic.Add(BagManager.Instance.InventoryDic.Count +1,1005);
                    break;
                case SymbolType.Swallow:
                    //治疗自己,Hp回复满
                    Player.HP = Player.MaxHP;
                    break;
                case SymbolType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(t), t, null);
            }
        }

        /// <summary>
        ///     阳火
        /// </summary>
        public void YangHuo(SymbolType t)
        {
            switch (t)
            {
                case SymbolType.RuneWater:
                    //治疗寒毒
                    break;
                case SymbolType.Burning:
                    //TODO:燃烧特效
                    //点燃一个区域,造成伤害+点燃场景可点燃的物品
                    var collides = Physics.OverlapSphere(Player.transform.position, SymbolEffectRadius);
                    foreach (var coll in collides)
                    {
                        var enemyController = coll.gameObject.GetComponent<Role>();
                        if (enemyController)
                            //对所有敌人造成伤害
                            enemyController.ApplyDamage(20);
                        //点燃场景可点燃的物品(目前是销毁)
                        Debug.Log(coll.gameObject.name + "燃烧起来了(被销毁)");

                        var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
                        if (otherThingController)
                        {
                            if (otherThingController.otherType == OtherThingType.CanBurn)
                            {
                                //点燃场景可点燃的物品
                                Debug.Log(coll.gameObject.name + "燃烧起来了(被销毁)");
                            }
                        }
                    }

                    break;
                case SymbolType.Swallow:
                    //获得道器:水火
                    //BagManager.Instance.AddItem(1006);
                    break;
                case SymbolType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(t), t, null);
            }
        }

        /// <summary>
        ///     土河车
        /// </summary>
        public void TuHeChe(SymbolType t)
        {
            switch (t)
            {
                case SymbolType.RuneWater:
                    //TODO:特效 洒在地面,打开地道
                    Collider[] colliders = Physics.OverlapSphere(Player.transform.position, SymbolEffectRadius);
                    foreach (var coll in colliders)
                    {
                        var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
                        if (otherThingController)
                        {
                            if (otherThingController.otherType == OtherThingType.Havetunnel)
                            {
                                Debug.Log("销毁地道");
                            }
                        }

                        //敌人听见玩家
                        var enemyAI = coll.GetComponent<AIBase>();
                        if (enemyAI)
                        {
                            enemyAI.AISense[AIStimulator.Hear] = true;
                            enemyAI.HearPos = Player.transform.position;
                        }
                    }

                    break;
                case SymbolType.Burning:
                    //TODO:升起土墙(可放入对象池)
                    var wall = Object.Instantiate(Player.fuluPrefab[0], Player.transform.position + Vector3.forward * 10, Quaternion.identity);
                    break;
                case SymbolType.Swallow:
                    NowBuffStates.Add(1);
                    break;
                case SymbolType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(t), t, null);
            }
        }

        /// <summary>
        ///     长生
        /// </summary>
        public void ChangSheng(SymbolType t)
        {
            switch (t)
            {
                case SymbolType.RuneWater:
                    //TODO:洒在地面,使植物快速生长
                    var collides = Physics.OverlapSphere(Player.transform.position, SymbolEffectRadius);
                    foreach (var coll in collides)
                    {
                        var otherThingController = coll.gameObject.GetComponent<OtherThingController>();
                        if (!otherThingController) continue;
                        //植物生长（目前只是普通的把Scale变大两倍）
                        if (otherThingController.otherType != OtherThingType.Nature) continue;
                        var tempScale = otherThingController.gameObject.transform.localScale;
                        otherThingController.transform.DOScale(tempScale * 2, 2);

                        //敌人听见玩家
                        var enemyAI = coll.GetComponent<AIBase>();
                        if (enemyAI)
                        {
                            enemyAI.AISense[AIStimulator.Hear] = true;
                            enemyAI.HearPos = Player.transform.position;
                        }
                    }

                    break;
                case SymbolType.Burning:
                    //TODO:化出浓雾,敌人进入迷雾后会失明,直到受到攻击为止(敌人失明效果没做)
                    var smoke = Object.Instantiate(Player.fuluPrefab[1], Player.transform.position + Vector3.forward * 30, Quaternion.identity);
                    smoke.transform.DOScale(smoke.transform.localScale * 3, 2f);
                    break;
                case SymbolType.Swallow:
                    NowDeBuffStates.Clear();
                    break;
                case SymbolType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(t), t, null);
            }
        }

        #endregion

        #region Magic

        /// <summary>
        ///     五雷掌
        /// </summary>
        public void ThunderPalm()
        {
            SkillManager.Instance.UseSkill(0);
        }

        /// <summary>
        ///     雷环
        /// </summary>
        public void ThunderRing()
        {
            SkillManager.Instance.UseSkill(1);
        }

        /// <summary>
        ///     落雷
        /// </summary>
        public void ThunderFall()
        {
            SkillManager.Instance.UseSkill(2);
        }

        /// <summary>
        ///     木幻珠
        /// </summary>
        public void WoodBead()
        {
            SkillManager.Instance.UseSkill(5);
        }

        /// <summary>
        ///     铁幻珠
        /// </summary>
        public void IronBead()
        {
            SkillManager.Instance.UseSkill(6);
        }

        /// <summary>
        ///     葫芦幻珠
        /// </summary>
        public void GourdBead()
        {
            SkillManager.Instance.UseSkill(7);
        }

        #endregion
    }
}