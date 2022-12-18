using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.Characters;
using Assets.Script.Data;
using Assets.Script.Skill;
using Assets.Script.AI;
using Werewolf.SpellIndicators;
using RootLibrary;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Object = UnityEngine.Object;

namespace Assets.Script.Manager
{
    public sealed class SkillManager : HideActor<SkillManager>
    {
        public delegate void Cast();

        public SkillDatas Datas;

        public Dictionary<int, Cast> ActionDic = new();
        public Dictionary<int, Cast> SkillStopActionDic = new();
        public Dictionary<int, SkillData> DataDic = new();

        public Dictionary<int, bool> CanUseSKill = new();
        
        public Dictionary<int, GameObject> DebuffSkillDic = new();
        public Dictionary<int, GameObject> SkillPre = new();
        public Dictionary<int, List<GameObject>> SkillRangeElement = new();

        public Dictionary<int, Dictionary<int, int>> SkillObjNeeded = new();//存放什么技能需要id为多少的多少物品
        public Dictionary<int, Dictionary<int, int>> SkillUseNeeded = new();//存放什么技能需要使用id为多少的物品才能解锁
        public Dictionary<int, Dictionary<int, int>> SkillStateNeeded = new();//存放什么技能需要id为多少的状态才能解锁
        public Dictionary<int, bool[]> CanUnlockSkill=new();//存放id为多少的技能是否需要获得物品，需要使用物品，状态，都满足了
        public Dictionary<int, Dictionary<int, int>> ExistingItems = new();//跟技能解锁相关物体字典，前面是技能id，后面是物品的id和已有数量
        public Dictionary<int, Dictionary<int, int>> UsedItems = new();//跟技能解锁相关物体字典，前面是技能id，后面是使用物品的id和已有数量
        public Dictionary<int, Dictionary<int, int>> ExistingStates = new();//跟技能解锁相关物体字典，前面是技能id，后面是状态的id和已有数量


        public SkillManager()
        {
            Init();
        }

        public YiChingPlayer Player => PlayerManager.Instance.Player;

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            Datas = ResourceManager.Instance.LoadResource<SkillDatas>("Data/ScriptableObjectData/SkillDatas");
            if (!Datas) return;
            for (var i = 0; i < Datas.SkillsDatas.Count; i++)
            {
                DataDic.Add(i, Datas.SkillsDatas[i]);
                SkillPre.Add(DataDic[i].Id, DataDic[i].SkillPrefab);

                var _t = new int[2];
                CanUnlockSkill.Add(DataDic[i].Id, new bool[3]);
                SkillObjNeeded.Add(DataDic[i].Id, new());
                SkillUseNeeded.Add(DataDic[i].Id, new());
                SkillStateNeeded.Add(DataDic[i].Id, new());
                foreach (var item in DataDic[i].NeededObjId)
                {
                    _t = GetSkillNeeded(item);
                    SkillObjNeeded[DataDic[i].Id].Add(_t[0], _t[1]);
                }
                CanUnlockSkill[DataDic[i].Id][0] = SkillObjNeeded[DataDic[i].Id].Count < 1;
                for (int j = 0; j < DataDic[i].NeededUseId.Length; j++)
                {
                    _t = GetSkillNeeded(DataDic[i].NeededUseId[j]);
                    SkillUseNeeded[DataDic[i].Id].Add(_t[0], _t[1]);
                }
                /*foreach (var item in DataDic[i].NeededUseId)
                {
                    _t = GetSkillNeeded(item);
                    SkillUseNeeded[DataDic[i].Id].Add(_t[0], _t[1]);
                }*/
                CanUnlockSkill[DataDic[i].Id][1] = SkillUseNeeded[DataDic[i].Id].Count < 1;
                foreach (var item in DataDic[i].NeededStateId)
                {
                    _t = GetSkillNeeded(item);
                    SkillStateNeeded[DataDic[i].Id].Add(_t[0], _t[1]);
                }

                CanUnlockSkill[DataDic[i].Id][2] = SkillStateNeeded[DataDic[i].Id].Count < 1;

                CanUseSKill.Add(DataDic[i].Id, CanUnlockSkill[DataDic[i].Id][0] && CanUnlockSkill[DataDic[i].Id][1] && CanUnlockSkill[DataDic[i].Id][2]);
            }

            InitSkillDele();
        }

        private void InitSkillDele()
        {
            ActionDic.Add(3, IllusionBlinding);
            ActionDic.Add(6, Unseen);
            ActionDic.Add(8, QingDao);
            SkillStopActionDic.Add(3, EndIllusionBlinding);
            SkillStopActionDic.Add(4, StopBeFused);
            SkillStopActionDic.Add(8, EndQingDao);
        }

        private int[] GetSkillNeeded(string info)
        {
            int[] temp = new int[2];

            string[] t = info.Split(':');
            temp[0] = int.Parse(t[0]);
            temp[2] = int.Parse(t[1]);

            return temp;
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public void PlayClip(int id)
        {
            AudioManager.Instance.PlayClip(1, id);
        }

        /// <summary>
        ///     释放
        /// </summary>
        public void Casting(int id)
        {
            CastCommon(id);
            if(ActionDic.ContainsKey(id)) ActionDic[id]?.Invoke();
            CanUseSKill[id] = false;
            CoroutineManager.Instance.Create(WaitCdTimer(id));
        }

        /// <summary>
        ///     耗蓝
        /// </summary>
        public void CastCommon(int id)
        {
            Player.ApplyMp(DataDic[id].Drain);
        }

        /// <summary>
        ///     将技能实物加入Debuff字典的方法
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <param name="pre">技能</param>
        public void AddObj(int id, GameObject obj)
        {
            if (DebuffSkillDic.ContainsKey(id))
            {
                if (DebuffSkillDic[id] == null) DebuffSkillDic[id] = obj;
                return;
            }

            DebuffSkillDic.Add(id, obj);
        }

        /// <summary>
        ///     造成持续伤害
        /// </summary>
        public IEnumerator ContinuousDamage(SkillBase skill, IFight t, float damage, float force, int doTime,
            float startTime,
            float deltaTime)
        {
            yield return new WaitForSeconds(startTime);
            for (var i = 0; i < doTime; i++)
            {
                skill.CauseDamage(t, damage, force);
                yield return new WaitForSeconds(deltaTime);
            }

            yield return null;
        }

        #region 技能指示器
        /// <summary>
        ///    技能指引器
        /// </summary>
        /// <param name="id"></param>
        public void SkillIndicator(int id)
        {
            switch (DataDic[id].SkillIndictortype)
            {
                case SkillIndictorType.Default: break;

                case SkillIndictorType.Direction:
                    SplatManager.Instance.Direction.Select();
                    SplatManager.Instance.Direction.Scale = 5f;
                    break;
                case SkillIndictorType.Cone:
                    SplatManager.Instance.Cone.Select();
                    SplatManager.Instance.Cone.Scale = 5f;
                    break;

                case SkillIndictorType.Point:
                    SplatManager.Instance.Point.Select();
                    SplatManager.Instance.Point.Scale = 5f;
                    SplatManager.Instance.Point.Range = 15f;
                    break;

                case SkillIndictorType.Range:
                    
                    break;
            }
        }

        public void StopIndicator()
        {
            SplatManager.Instance.Cancel();
        }
        #endregion

        #region 判断技能是否可以使用
        /// <summary>
        ///     判断物品id是否存在某些技能的需求表里
        /// </summary>
        /// <param name="id"></param>

        public List<int> GetItem(int id)
        {
            List<int> t = new();//存储已满足需要id为多少的物品的技能的id
            for (int i = 0; i < DataDic.Count; i++)
            {
                if (SkillObjNeeded[DataDic[i].Id].ContainsKey(id)) {
                    ExistingItems[DataDic[i].Id][id]++;                   
                    t.Add(DataDic[i].Id);
                    CanUnlockSkill[DataDic[i].Id][0] = true;
                    foreach (var item in SkillObjNeeded[DataDic[i].Id])
                    {
                        if (item.Value > ExistingItems[DataDic[i].Id][item.Key])
                        {
                            t.Remove(DataDic[i].Id);
                            CanUnlockSkill[DataDic[i].Id][0] =false;
                            break;
                        }
                    }
                }             
            }

            return t;
        }

        public void RemoveItem(int id)
        {
            for (int i = 0; i < DataDic.Count; i++)
            {
                if (SkillObjNeeded[DataDic[i].Id].ContainsKey(id))
                {
                    ExistingItems[DataDic[i].Id][id]--;
                    if (ExistingItems[DataDic[i].Id][id] < SkillObjNeeded[DataDic[i].Id][id])
                    {
                        CanUnlockSkill[DataDic[i].Id][0] = false;
                        CanUseSKill[DataDic[i].Id] = false;
                    }
                }
            }
        }

        public List<int> UseItem(int id)
        {
            List<int> t = new();

            for (int i = 0; i < DataDic.Count; i++)
            {
                if (SkillUseNeeded[DataDic[i].Id].ContainsKey(id))
                {
                    UsedItems[DataDic[i].Id][id]++;
                    t.Add(DataDic[i].Id);
                    CanUnlockSkill[DataDic[i].Id][1] = true;
                    foreach (var item in SkillUseNeeded[DataDic[i].Id])
                    {
                        if (item.Value > UsedItems[DataDic[i].Id][item.Key])
                        {
                            t.Remove(DataDic[i].Id);
                            CanUnlockSkill[DataDic[i].Id][1] = false;
                            break;
                        }
                    }
                }
            }

            return t;
        }

        public List<int> GetState(int id)
        {
            List<int> t = new();
            for (int i = 0; i < DataDic.Count; i++)
            {
                if (SkillStateNeeded[DataDic[i].Id].ContainsKey(id))
                {
                    ExistingStates[DataDic[i].Id][id]++;
                    t.Add(DataDic[i].Id);
                    CanUnlockSkill[DataDic[i].Id][2] = true;
                    foreach (var item in SkillStateNeeded[DataDic[i].Id])
                    {
                        if (item.Value > ExistingStates[DataDic[i].Id][item.Key])
                        {
                            t.Remove(DataDic[i].Id);
                            CanUnlockSkill[DataDic[i].Id][2] = false;
                            break;
                        }
                    }
                }
            }

            return t;
        }

        public void RemoveState(int id)
        {
            for (int i = 0; i < DataDic.Count; i++)
            {
                if (SkillStateNeeded[DataDic[i].Id].ContainsKey(id))
                {
                    ExistingStates[DataDic[i].Id][id]--;
                    if (ExistingStates[DataDic[i].Id][id] < SkillStateNeeded[DataDic[i].Id][id])
                    {
                        CanUnlockSkill[DataDic[i].Id][2] = false;
                        CanUseSKill[DataDic[i].Id] = false;
                    }
                }
            }
        }

        /// <summary>
        ///     判断解锁或者锁定技能
        /// </summary>
        /// <param name="id">物品/效果ID</param>
        public void SkillLock(int id,SkillLockEventType type)
        {
            List<int> t = new();
            switch (type)
            {
                case SkillLockEventType.GetItem:
                    t = GetItem(id);
                    break;
                case SkillLockEventType.RemoveItem:
                    RemoveItem(id);
                    break;
                case SkillLockEventType.UseItem:
                    t = UseItem(id);
                    break;
                case SkillLockEventType.GetState:
                    t = GetState(id);
                    break;
                case SkillLockEventType.RemoveState:
                    RemoveState(id);
                    break;
            }
            
            if (t.Count < 1) return;

            foreach (var _id in t)
            {
                CanUseSKill[_id] = CanUnlockSkill[_id][0] && CanUnlockSkill[_id][1] && CanUnlockSkill[_id][2];
            }
        }

        /// <summary>
        ///     使用技能冷却间隔
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerator WaitCdTimer(int id)
        {
            yield return new WaitForSeconds(DataDic[id].SkillCD);
            CanUseSKill[id] = true;
        }

        #endregion

        #region 使用与停止技能
        /// <summary>
        ///     使用技能
        /// </summary>
        /// <param name="id"></param>
        public void UseSkill(int id)
        {
            if (!DataDic.ContainsKey(id)||!CanUseSKill[id]||Player.MP<DataDic[id].Drain) return;
            if (DebuffSkillDic.ContainsKey(id)) return;

            if (SkillPre[id] == null) //抽象技能
            {
                Casting(id);
            }
            else
            {
                var t = ObjectPoolManager.Instance.GetByPool(ObjectType.Skill, id);
                if (t == null) t = Object.Instantiate(SkillPre[id]);

                switch (DataDic[id].InstantType)
                {
                    case SkillInstateType.WithoutParent:
                        t.transform.position = Player.transform.position;
                        t.transform.rotation = Player.transform.rotation;
                        break;
                    case SkillInstateType.WithParent:
                        t.transform.position = Player.transform.position;
                        t.transform.position = Player.transform.position;
                        t.transform.SetParent(Player.transform);
                        break;
                    case SkillInstateType.InMousePos:
                        var tVec = GetMousePosition();
                        if (tVec == Vector3.zero) return;
                        t.transform.position = tVec;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
                t.SetActive(true);
            } //有实物技能
        }

        /// <summary>
        ///     停止技能（DebuffSkill专用（需要手动终止））
        /// </summary>
        /// <param name="id"></param>
        public void StopSkill(int id)
        {
            if (DebuffSkillDic.ContainsKey(id) && DebuffSkillDic[id] != null)
            {
                ObjectPoolManager.Instance.AddToPool(ObjectType.Skill, id, DebuffSkillDic[id]);
            }
            if (SkillStopActionDic.ContainsKey(id)) SkillStopActionDic[id]?.Invoke();
            CanUseSKill[id] = true;
        }

        /// <summary>
        ///     给用一次立刻消失的技能用
        /// </summary>
        /// <param name="obj"></param>
        public void FinishSkill(int id , GameObject obj)
        {
            ObjectPoolManager.Instance.AddToPool(ObjectType.Skill, id, obj);
        }


        public Vector3 GetMousePosition()
        {
            return LibV.GetMouseRayPosition();
        }

        #endregion

        #region 幻术
        #region 障眼法实现
        public void IllusionBlinding()
        {
            if (DebuffSkillDic.ContainsKey(3)) return;
            CoroutineManager.Instance.Create(3, DoIllusionBlinding(3));
        }

        public IEnumerator DoIllusionBlinding(int id)
        {            
            int _timer=0;
            int _radius = 5;
            float _ds = 120f;
            DebuffSkillDic.Add(3, null);
            LayerMask _wallMask = 1<<7;
            Dictionary<string, float> disSpeed = new();

            if (SkillRangeElement.ContainsKey(id)) SkillRangeElement[id] = new();
            else SkillRangeElement.Add(id, new());

            while (_timer<DataDic[id].Duration)
            {
                Collider[] hits = Physics.OverlapSphere(Player.transform.position, _radius,_wallMask);
                if (_ds > 2) _ds -= 2f;
                if (hits.Length > 0)
                {
                    foreach (var item in hits)
                    {
                        if (!disSpeed.ContainsKey(item.name))
                        {
                            _ds = _ds > 2 ? _ds : 2;
                            disSpeed.Add(item.name, _ds);
                            SkillRangeElement[id].Add(item.gameObject);
                            if (disSpeed.Count == 1) CoroutineManager.Instance.Create(WallDisappear(id, disSpeed));
                        }
                    }
                }
                _timer+=2;
                yield return new WaitForSeconds(2f);
            }
        }

        public IEnumerator WallDisappear(int id,Dictionary<string,float> speed)
        {
            while (SkillRangeElement[id].Count > 0)
            {
                foreach (var item in SkillRangeElement[id])
                {
                    speed[item.name] -= Time.deltaTime;

                    if (item.GetComponent<Renderer>().material.color.a > 0)
                    {
                        item.gameObject.GetComponent<Renderer>().material.color = new Color(
                        item.GetComponent<Renderer>().material.color.r,
                        item.GetComponent<Renderer>().material.color.g,
                        item.GetComponent<Renderer>().material.color.b,
                        item.GetComponent<Renderer>().material.color.a - Time.deltaTime / speed[item.name]);
                    }
                    else item.GetComponent<Renderer>().enabled = false;
                }
                yield return null;
            }
        }
        public void EndIllusionBlinding()
        {
            CoroutineManager.Instance.Kill(3);
            CoroutineManager.Instance.Create(3, WallAppear(3));
        }
        public IEnumerator WallAppear(int id)
        {
            float _appearSpeed = 5f;
            if (!SkillRangeElement.ContainsKey(id))
            {
                CoroutineManager.Instance.CoroutineStopped(id);
                yield break;
            }
            while (SkillRangeElement[id].Count > 0)
            {
                for(int i = 0; i < SkillRangeElement[id].Count; i++)
                {
                    SkillRangeElement[id][i].GetComponent<Renderer>().enabled = true;
                    if (SkillRangeElement[id][i].GetComponent<Renderer>().material.color.a < 1)
                    {
                        SkillRangeElement[id][i].gameObject.GetComponent<Renderer>().material.color = new Color(
                        SkillRangeElement[id][i].GetComponent<Renderer>().material.color.r,
                        SkillRangeElement[id][i].GetComponent<Renderer>().material.color.g,
                        SkillRangeElement[id][i].GetComponent<Renderer>().material.color.b,
                        SkillRangeElement[id][i].GetComponent<Renderer>().material.color.a + Time.deltaTime / _appearSpeed);
                    }
                    else SkillRangeElement[id].Remove(SkillRangeElement[id][i]);
                }
                yield return null;
            }
            DebuffSkillDic.Remove(3);
            CoroutineManager.Instance.Kill(id);
        }
        #endregion

        #region 迷魂实现
        /// <summary>
        ///     迷魂
        /// </summary>
        public IEnumerator BeConfused(GameObject obj)
        {
            float _initSpeed = 3f;
            var _volumn = obj.GetComponent<PostProcessVolume>();
            var _vBloom = _volumn.profile.GetSetting<Bloom>();
            var _vVignette = _volumn.profile.GetSetting<Vignette>();

            while (_vBloom.intensity.value < 4f || _vVignette.intensity.value < 0.55f)
            {
                _vBloom.intensity.value += Time.deltaTime / _initSpeed;
                _vBloom.intensity.value = _vBloom.intensity.value > 4f ? 4 : _vBloom.intensity.value;
                _vVignette.intensity.value += Time.deltaTime / _initSpeed;
                _vVignette.intensity.value = _vVignette.intensity.value > 0.55f ? 0.55f : _vVignette.intensity.value;

                yield return null;
            }
        }

        public void StopBeFused()
        {
            CoroutineManager.Instance.Create(4, BackNormal());
        }

        public IEnumerator BackNormal()
        {
            if (!DebuffSkillDic.ContainsKey(4))
            {
                CoroutineManager.Instance.CoroutineStopped(4);
                yield break;
            }
            var _volumn = DebuffSkillDic[4].GetComponent<PostProcessVolume>();
            var _vBloom = _volumn.profile.GetSetting<Bloom>();
            var _vVignette = _volumn.profile.GetSetting<Vignette>();
            var _vLens = _volumn.GetComponent<PostProcessVolume>().profile.GetSetting<LensDistortion>();

            float resetSpeed = 3f;
            float _bloomSp = _vBloom.intensity.value / resetSpeed;
            float _vigSp = _vVignette.intensity.value / resetSpeed;
            float _lensSp = _vLens.intensity.value / resetSpeed;

            while (_vBloom.intensity.value > 0 || _vVignette.intensity.value > 0 || _vLens.intensity.value > 0)
            {
                _vBloom.intensity.value -= Time.deltaTime * _bloomSp;
                _vVignette.intensity.value -= Time.deltaTime * _vigSp;
                _vLens.intensity.value -= Time.deltaTime * _lensSp;

                yield return null;
            }
            DebuffSkillDic.Remove(4);
            StopSkill(4);
        }
        #endregion

        #region 倾倒
        public void QingDao()
        {
            DebuffSkillDic.Add(8, null);
            CoroutineManager.Instance.Create(8, RandomMove());
        }
        public IEnumerator RandomMove()
        {
            float timer = 0;
            while (timer < DataDic[8].Duration)
            {
                timer += 10;
                var tVec = new Vector3(MathV.Next(-2f, 2f), 0, MathV.Next(-2f, 2f));
                Player.ApplyMove(tVec, 1f);
                yield return new WaitForSeconds(10f);
            }
            CoroutineManager.Instance.CoroutineStopped(8);
        }

        public void EndQingDao()
        {
            DebuffSkillDic.Remove(8);
            CoroutineManager.Instance.Kill(8);
        }

        #endregion

        #region 幻珠
        /// <summary>
        ///     木幻珠（让敌人转为友好）
        /// </summary>
        public void WoodBead(GameObject obj)
        {
            var t = obj.GetComponent<Characters.EnemyBase> ();
            if (t == null) return;

            if (!SkillRangeElement.ContainsKey(5)) SkillRangeElement.Add(5, new());
            else if (SkillRangeElement[5].Contains(obj)) return;

            SkillRangeElement[5].Add(obj);
            CoroutineManager.Instance.Create(Ecstasy(obj));
        }
        public IEnumerator Ecstasy(GameObject obj)
        {
            var t= obj.GetComponent<Characters.EnemyBase>();
            var _orginType = t.RoleOfType;
            t.RoleOfType = RoleType.Friendly;
            yield return new WaitForSeconds(180f);
            t.RoleOfType = _orginType;
            SkillRangeElement[5].Remove(obj);
        }

        /// <summary>
        ///     铁钉幻珠（让敌人看不见玩家）
        /// </summary>
        public void Unseen()
        {
            CoroutineManager.Instance.Create(6, Invisible(), true);
        }
        public IEnumerator Invisible()
        {
            PlayerManager.Instance.AdduffState(0);
            yield return new WaitForSeconds(10f);
            if(PlayerManager.Instance.NowBuffStates.Contains(0)) PlayerManager.Instance.NowBuffStates.Remove(0); 
        }

        /// <summary>
        ///     葫芦幻珠（吐真，转变敌人）
        /// </summary>
        public void GourdBead(GameObject obj)
        {
            var t = obj.GetComponent<AIBase>();
            if (t == null) return;

            if (!SkillRangeElement.ContainsKey(7)) SkillRangeElement.Add(7, new());
            else if (SkillRangeElement[7].Contains(obj)) return;

            SkillRangeElement[7].Add(obj);
            CoroutineManager.Instance.Create(Ecstasy(obj));
        }
        public IEnumerator VomitTruthTurn(GameObject obj)
        {         
            var t = obj.GetComponent<AIBase>();
            var _orginType = t.MoveType;
            t.AIBuffState = AIBuffState.Puzzle;
            yield return new WaitForSeconds(180f);
            t.MoveType = _orginType;
            SkillRangeElement[7].Remove(obj);
        }

        #endregion

        /// <summary>
        ///     琵琶
        /// </summary>
        public IEnumerator Pipa(int id, float delta, float keepTime)
        {
            while (keepTime > 0)
            {
                PlayClip(id);
                yield return new WaitForSeconds(delta);
                keepTime -= delta;
            }
        }
        #endregion

        #region 雷法
        /// <summary>
        ///     护身雷
        /// </summary>
        public IEnumerator ThunderRing(int id)
        {
            while (SkillRangeElement[id].Count > 0)
            {
                foreach(var item in SkillRangeElement[id])
                {
                    var t = item.GetComponent<IFight>();
                    t.ApplyDamage(20);
                }
                yield return new WaitForSeconds(1.5f);
            }
        }

        #endregion
    }
}