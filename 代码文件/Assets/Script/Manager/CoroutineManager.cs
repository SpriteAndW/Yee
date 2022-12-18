using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class CoroutineManager : ConfigActor<CoroutineManager>
    {
        public Dictionary<int, Coroutine> DicCoroutines = new();
        public List<Coroutine> ListCoroutines = new();

        /// <summary>
        ///     清除不使用的协程
        /// </summary>
        public void ClearUnUsedCoroutines()
        {
            for (var i = ListCoroutines.Count - 1; i > 0; i--)
            {
                if (ListCoroutines[i] == null)
                {
                    ListCoroutines.RemoveAt(i);
                }
            }
        }

        /// <summary>
        ///     开启协程
        /// </summary>
        /// <param name="id">协程id</param>
        /// <param name="enumerator">具体协程方法</param>
        /// <param name="restart">如果协程存在是否重新开启</param>
        /// <returns></returns>
        public Coroutine Create(int id, IEnumerator enumerator, bool restart = false)
        {
            if (DicCoroutines.ContainsKey(id) && !restart) return null;
            if (DicCoroutines.ContainsKey(id) && restart) Kill(id);

            var coroutine = StartCoroutine(enumerator);
            DicCoroutines.Add(id, coroutine);
            return coroutine;
        }

        /// <summary>
        ///     给不好占用id的协程使用，不推荐，必须确保协程不会重复开启并且能够自己停止
        /// </summary>
        /// <param name="enumerator">需要开启的协程</param>
        /// 如果该协程已经存在，是否停止
        /// <returns></returns>
        public Coroutine Create(IEnumerator enumerator)
        {
            var coroutine = StartCoroutine(enumerator);
            ListCoroutines.Add(coroutine);
            return coroutine;
        }

        /// <summary>
        ///     根据id关闭协程
        /// </summary>
        /// <param name="id">需要关闭的协程id</param>
        public void Kill(int id)
        {
            if (DicCoroutines.ContainsKey(id))
            {
                StopCoroutine(DicCoroutines[id]);
                DicCoroutines.Remove(id);
            }
        }

        /// <summary>
        ///     通过调用此类中方法开启的协程必须在结束时写上这个或者kill方法并且传入id
        /// </summary>
        /// <param name="id">此协程的id</param>
        public void CoroutineStopped(int id)
        {
            if (DicCoroutines.ContainsKey(id)) DicCoroutines.Remove(id);
        }
    }
}