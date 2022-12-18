using System.Collections;
using System.Collections.Generic;
using RootLibrary;
using UnityEngine;

namespace Assets.Plugins.System
{
    public class TimerV //定时器
    {
        public bool IsPause; //是否暂停
        public float NowTime; //现在时间
        public float TargetTime; //目标时间
    }

    public static class TimeLineV
    {
        [Header("字典")] public static Dictionary<int, TimerV> TimerVDic = new();
        [Header("列表")] public static List<TimerV> TimerVList = new();

        /// <summary>
        ///     清除
        /// </summary>
        public static void ClearAll()
        {
            TimerVList.Clear();
            TimerVList.Clear();
        }

        /// <summary>
        ///     时间轴(就是插值)
        /// </summary>
        public static IEnumerator TimeLine(float t, float speed)
        {
            while (t > 0) t = MathV.Lerp(t, 0, speed);
            yield return null;
        }

        /// <summary>
        ///     Time.deltaTime
        /// </summary>
        public static void RunDeltaTimer()
        {
            if (TimerVDic.Count > 0)
                foreach (var t in TimerVDic)
                {
                    if (t.Value.IsPause) continue;
                    t.Value.NowTime += Time.deltaTime;
                }

            if (TimerVList.Count > 0)
                for (var i = 0; i < TimerVList.Count; ++i)
                {
                    if (TimerVList[i].IsPause) continue;
                    TimerVList[i].NowTime += Time.deltaTime;
                }
        }

        #region m_List

        /// <summary>
        ///     注册
        /// </summary>
        public static TimerV Register(float targetTime)
        {
            var timer = new TimerV { IsPause = false, NowTime = 0f, TargetTime = targetTime };
            TimerVList.Add(timer);
            return timer;
        }

        /// <summary>
        ///     移除
        /// </summary>
        public static void Remove(TimerV t)
        {
            if (TimerVList.Contains(t)) TimerVList.Remove(t);
        }

        #endregion

        #region m_Dictionary

        /// <summary>
        ///     获取现在时间
        /// </summary>
        public static float GetNowTime(int id)
        {
            return TimerVDic.ContainsKey(id) ? TimerVDic[id].NowTime : 0f;
        }

        /// <summary>
        ///     移除
        /// </summary>
        public static void Remove(int id)
        {
            if (TimerVDic.ContainsKey(id)) TimerVDic.Remove(id);
        }

        /// <summary>
        ///     注册
        /// </summary>
        public static TimerV Register(int id, float targetTime)
        {
            var timer = new TimerV { IsPause = false, NowTime = 0f, TargetTime = targetTime };
            TimerVDic.Add(id, timer);
            return timer;
        }

        /// <summary>
        ///     重设
        /// </summary>
        public static void ReSet(int id)
        {
            if (TimerVDic.ContainsKey(id)) TimerVDic[id].NowTime = 0;
        }

        /// <summary>
        ///     暂停
        /// </summary>
        public static void Pause(int id)
        {
            if (TimerVDic.ContainsKey(id)) TimerVDic[id].IsPause = true;
        }

        /// <summary>
        ///     继续
        /// </summary>
        public static void Continue(int id)
        {
            if (TimerVDic.ContainsKey(id)) TimerVDic[id].IsPause = false;
        }

        /// <summary>
        ///     暂停
        /// </summary>
        public static void PauseOrContinue(int id)
        {
            if (TimerVDic.ContainsKey(id)) TimerVDic[id].IsPause = !TimerVDic[id].IsPause;
        }

        #endregion
    }
}