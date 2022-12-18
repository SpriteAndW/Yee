using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using DG.Tweening;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Skill
{
    public class SkillBase : Actor, IObjectPool
    {
        public SkillData Data;
        public int Id;
        public ObjectType Type = ObjectType.Skill;
        public Dictionary<int,List<GameObject>> ExistEffect=new();

        /// <summary>
        ///     回收
        /// </summary>
        public virtual void Recovery()
        {
            foreach (var item in ExistEffect)
            {
                foreach (var j in item.Value)
                {
                    j.transform.SetParent(null);
                    ObjectPoolManager.Instance.AddToPool(ObjectType.Effect, item.Key, j);
                }
            }
            ExistEffect.Clear();
            gameObject.transform.SetParent(null);
            ObjectPoolManager.Instance.AddToPool(Type, Id, gameObject);
        }

        public virtual void OnEnable()
        {
            Data = SkillManager.Instance.DataDic[Id];
            DoSkill();
            Invoke(nameof(Recovery), Data.Duration);
            CreateEffect(Id * 10);
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public virtual void PlayClip(int id)
        {
            AudioManager.Instance.PlayClip(2, id);
        }

        /// <summary>
        ///     随机播放一次音效
        /// </summary>
        public virtual void PlayRandomClip(List<int> id)
        {
            AudioManager.Instance.PlayClip(2, id.NextItem());
        }

        /// <summary>
        ///     向前移动
        /// </summary>
        public virtual void ForwardMove()
        {
            transform.DOMove(transform.position + transform.forward, Data.Speed);
        }

        /// <summary>
        ///     播放多个音效
        /// </summary>
        public virtual void PlayClips(List<int> id)
        {
            foreach (var i in id) AudioManager.Instance.PlayClip(2, i);
        }

        /// <summary>
        ///     造成伤害
        /// </summary>
        public void CauseDamage(IFight t, float damage, float force)
        {
            t.ApplyDamage(damage);
            if (force > 0) t.ApplyForce(gameObject, force);
        }

        /// <summary>
        ///     使用
        /// </summary>
        public virtual void DoSkill() 
        {
            SkillManager.Instance.Casting(Id);
        }

        /// <summary>
        ///     造成持续伤害
        /// </summary>
        public virtual void CauseContinuousDamage(IFight t, float damage, float force, int doTime, float startTime,
            float deltaTime)
        {
            StartCoroutine(
                SkillManager.Instance.ContinuousDamage(this, t, damage, force, doTime, startTime, deltaTime));
        }

        /// <summary>
        ///     放特效
        /// </summary>
        public virtual void CreateEffect(int id)
        {
            if (Data.Effects.Length < 1) return;
            var t = ObjectPoolManager.Instance.GetByPool(ObjectType.Effect, id);
            if (t != null)
            {               
                t.SetActive(true);
            }
            else
            {
                t = Instantiate(Data.Effects[id%10]);
            }
            t.transform.position = transform.position;
            t.transform.SetParent(transform);

            if (!ExistEffect.ContainsKey(id)) ExistEffect.Add(id, new());        
            ExistEffect[id].Add(t);
        }
    }
}