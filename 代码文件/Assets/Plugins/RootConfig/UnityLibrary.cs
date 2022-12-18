#region 作者

//===================================================||
//作者：溫柔可愛柠檬草  (b站)
//===================================================||

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Plugins.System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace RootLibrary
{
    public static class InventoryControl
    {
        /// <summary>
        ///     交换
        /// </summary>
        public static Dictionary<T, T> Swap<T>(this Dictionary<T, T> dic, T a, T b)
        {
            if (!dic.ContainsKey(a) || !dic.ContainsKey(b)) return dic;
            (dic[a], dic[b]) = (dic[b], dic[a]);
            return dic;
        }

        /// <summary>
        ///     交换
        /// </summary>
        public static IDictionary<T, T> Swap<T>(this IDictionary<T, T> dic, T a, T b)
        {
            if (!dic.ContainsKey(a) || !dic.ContainsKey(b)) return dic;
            (dic[a], dic[b]) = (dic[b], dic[a]);
            return dic;
        }

        /// <summary>
        ///     添加
        /// </summary>
        public static void AddItem<T>(this Dictionary<T, int> dic, T t)
        {
            if (!dic.ContainsKey(t))
                dic.Add(t, 1);
            else
                dic[t] += 1;
        }

        /// <summary>
        ///     添加
        /// </summary>
        public static void AddItem<T>(this IDictionary<T, int> dic, T t)
        {
            if (!dic.ContainsKey(t))
                dic.Add(t, 1);
            else
                dic[t] += 1;
        }

        /// <summary>
        ///     移除
        /// </summary>
        public static void RemoveItem<T>(this Dictionary<T, int> dic, T t)
        {
            if (!dic.ContainsKey(t)) return;
            if (dic[t] > 1)
                dic[t] -= 1;
            else
                dic.Remove(t);
        }

        /// <summary>
        ///     移除
        /// </summary>
        public static void RemoveItem<T>(this IDictionary<T, int> dic, T t)
        {
            if (!dic.ContainsKey(t)) return;
            if (dic[t] > 1)
                dic[t] -= 1;
            else
                dic.Remove(t);
        }

        /// <summary>
        ///     获取数量
        /// </summary>
        public static int GetItemNum<T>(this Dictionary<T, int> dic, T t)
        {
            return dic[t];
        }

        /// <summary>
        ///     按键排序
        /// </summary>
        public static Dictionary<T, T> AutoSortByKey<T>(this Dictionary<T, T> dic)
        {
            return dic.OrderByDescending(r => r.Key).Reverse().ToDictionary(r => r.Key, r => r.Value);
        }

        /// <summary>
        ///     按键排序
        /// </summary>
        public static IDictionary<T, T> AutoSortByKey<T>(this IDictionary<T, T> dic)
        {
            return dic.OrderByDescending(r => r.Key).Reverse().ToDictionary(r => r.Key, r => r.Value);
        }

        /// <summary>
        ///     按值排序
        /// </summary>
        public static Dictionary<T, T> AutoSortByValue<T>(this Dictionary<T, T> dic)
        {
            return dic.OrderByDescending(r => r.Value).Reverse().ToDictionary(r => r.Key, r => r.Value);
        }

        /// <summary>
        ///     按值排序
        /// </summary>
        public static IDictionary<T, T> AutoSortByValue<T>(this IDictionary<T, T> dic)
        {
            return dic.OrderByDescending(r => r.Value).Reverse().ToDictionary(r => r.Key, r => r.Value);
        }
    }

    public static class SceneControl
    {
        /// <summary>
        ///     退出游戏
        /// </summary>
        public static void QuitGame()
        {
            Application.Quit();
        }

        /// <summary>
        ///     按名字打开场景
        /// </summary>
        public static void LoadSceneByString(string mapName)
        {
            SceneManager.LoadScene(mapName);
        }

        /// <summary>
        ///     按Id打开场景
        /// </summary>
        public static void LoadSceneById(int id)
        {
            if (id >= SceneManager.sceneCountInBuildSettings) return;
            SceneManager.LoadScene(id);
        }

        /// <summary>
        ///     打开上一个场景
        /// </summary>
        public static void LoadLastScene()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        /// <summary>
        ///     打开下一个场景
        /// </summary>
        public static void LoadNextScene()
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public static class SoundControl
    {
        /// <summary>
        ///     音量設爲0
        /// </summary>
        public static void Close(this AudioSource t)
        {
            t.volume = 0;
        }

        /// <summary>
        ///     音量設爲1
        /// </summary>
        public static void Open(this AudioSource t)
        {
            t.volume = 1;
        }

        /// <summary>
        ///     屏蔽或打开
        /// </summary>
        public static void MuteInOrOut(this AudioSource t)
        {
            t.mute = !t.mute;
        }

        /// <summary>
        ///     屏蔽或打开
        /// </summary>
        public static void MuteInOrOut(this IEnumerable<AudioSource> t)
        {
            foreach (var t1 in t)
                t1.mute = !t1.mute;
        }

        /// <summary>
        ///     屏蔽
        /// </summary>
        public static void MuteIn(this AudioSource t)
        {
            t.mute = true;
        }

        /// <summary>
        ///     取消屏蔽
        /// </summary>
        public static void MuteOut(this AudioSource t)
        {
            t.mute = false;
        }

        /// <summary>
        ///     開啓循環
        /// </summary>
        public static void LoopIn(this AudioSource t)
        {
            t.loop = true;
        }

        /// <summary>
        ///     關閉循環
        /// </summary>
        public static void LoopOut(this AudioSource t)
        {
            t.loop = false;
        }

        /// <summary>
        ///     按顺序循环全部
        /// </summary>
        public static void ContinuePlayAll(this AudioSource t, List<AudioClip> list)
        {
            if (t.isPlaying || list.IsEmpty()) return;
            if (t.clip != null || !t.clip.In(list))
                t.clip = list[0];
            else
                t.clip = t.clip.NextOne(list);
            t.Play();
        }

        /// <summary>
        ///     随机播放全部
        /// </summary>
        public static void RandomPlayAll(this AudioSource t, List<AudioClip> list)
        {
            if (t.isPlaying || list.IsEmpty()) return;
            t.clip = list[MathV.Next(0, list.Count)];
            t.Play();
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public static void PlaySfx(this AudioSource t, IEnumerable<AudioClip> list, string clipName)
        {
            foreach (var t1 in list.Where(t1 => t1.name.Equals(clipName)))
                t.PlayOneShot(t1);
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public static void PlaySfx(this AudioSource t, List<AudioClip> list, string clipName, float volume)
        {
            foreach (var t1 in list.Where(t1 => t1.name.Equals(clipName)))
                t.PlayOneShot(t1, volume);
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public static void PlaySfx(this AudioSource t, AudioClip clip)
        {
            t.PlayOneShot(clip);
        }

        /// <summary>
        ///     播放音效
        /// </summary>
        public static void PlaySfx(this AudioSource t, AudioClip clip, float volume)
        {
            t.PlayOneShot(clip, volume);
        }

        /// <summary>
        ///     bool播放音效
        /// </summary>
        public static bool IfPlaySfx(this AudioSource t, AudioClip clip, bool condition)
        {
            if (!condition) return false;
            t.PlayOneShot(clip);
            return false;
        }

        /// <summary>
        ///     bool播放音效
        /// </summary>
        public static bool IfPlaySfx(this AudioSource t, AudioClip clip, bool condition, float volume)
        {
            if (!condition) return false;
            t.PlayOneShot(clip, volume);
            return false;
        }

        /// <summary>
        ///     停止
        /// </summary>
        public static void StopPlay(this AudioSource t)
        {
            t.Stop();
            t.loop = false;
            t.clip = null;
        }

        /// <summary>
        ///     播放音乐
        /// </summary>
        public static void PlaySound(this AudioSource t, AudioClip clip)
        {
            t.clip = clip;
            t.Play();
        }

        /// <summary>
        ///     循环播放音乐
        /// </summary>
        public static void LoopPlaySound(this AudioSource t, AudioClip clip)
        {
            t.clip = clip;
            t.loop = true;
            t.Play();
        }

        /// <summary>
        ///     播放音乐
        /// </summary>
        public static void PlaySound(this AudioSource t, AudioClip clip, float volume)
        {
            t.clip = clip;
            t.volume = volume;
            t.Play();
        }

        /// <summary>
        ///     循环播放音乐
        /// </summary>
        public static void LoopPlaySound(this AudioSource t, AudioClip clip, float volume)
        {
            t.clip = clip;
            t.volume = volume;
            t.loop = true;
            t.Play();
        }
    }

    public static class LibV
    {
        #region Camera

        /// <summary>
        ///     用角度计算圆的XY
        /// </summary>
        public static Vector2 CalcAbsolutePoint(float angle, float dist)
        {
            var radian = -angle * (MathV.Pi / 180);
            var x = dist * MathV.Cos(radian);
            var y = dist * MathV.Sin(radian);
            return new Vector2(x, y);
        }

        /// <summary>
        ///     Vector3_Lerp
        /// </summary>
        public static Vector3 Vector3Lerp(Vector3 current, Vector3 target, float speed)
        {
            var newX = MathV.Lerp(current.x, target.x, speed);
            var newY = MathV.Lerp(current.y, target.y, speed);
            var newZ = MathV.Lerp(current.z, target.z, speed);
            return new Vector3(newX, newY, newZ);
        }

        /// <summary>
        ///     Vector3_Lerp跟随
        /// </summary>
        public static void LerpFollow(this Transform t, Vector3 target, float speed)
        {
            t.transform.position = Vector3Lerp(t.position, target, speed);
        }

        /// <summary>
        ///     Vector3_Lerp跟随
        /// </summary>
        public static void LerpFollow(this Transform t, Vector3 target, Vector3 offset, float speed)
        {
            t.transform.position = Vector3Lerp(t.position, target - offset, speed);
        }

        /// <summary>
        ///     摄像机层次跟随
        /// </summary>
        public static void HierarchyView(this Transform t, Transform target, float scaleOffset)
        {
            var targetPos = target.position;
            var pos = t.localPosition;
            var offsetX = (target.localPosition.x - targetPos.x) * scaleOffset;
            pos.x += offsetX;
            t.localPosition = pos;
        }

        /// <summary>
        ///     摄像机缩放焦距
        /// </summary>
        public static void CameraZoom(float t) //鼠标滚轮缩放镜头
        {
            Camera.main!.orthographicSize += t;
        }

        #endregion

        #region Variable

        /// <summary>
        ///     重力
        /// </summary>
        public const float Gravity = 9.78f;

        #endregion

        #region GameObject & Transfom

        /// <summary>
        ///     切换状态
        /// </summary>
        public static void SwitchActive(this GameObject t)
        {
            t.SetActive(!t.activeSelf);
        }

        /// <summary>
        ///     切换显示状态
        /// </summary>
        public static void SwitchEnabled(this Canvas t)
        {
            t.enabled = !t.enabled;
        }

        /// <summary>
        ///     刪除
        /// </summary>
        public static void Destroy(this GameObject t)
        {
            Object.Destroy(t);
        }

        /// <summary>
        ///     刪除
        /// </summary>
        public static void Destroy(this Transform t)
        {
            Object.Destroy(t.gameObject);
        }

        /// <summary>
        ///     隱藏
        /// </summary>
        public static void Hide(this GameObject t)
        {
            t.SetActive(false);
        }

        /// <summary>
        ///     隱藏
        /// </summary>
        public static void Hide(this Transform t)
        {
            t.gameObject.SetActive(false);
        }

        /// <summary>
        ///     隱藏
        /// </summary>
        public static void Hide(this MonoBehaviour t)
        {
            t.gameObject.SetActive(false);
        }

        /// <summary>
        ///     顯示
        /// </summary>
        public static void Show(this GameObject t)
        {
            t.SetActive(true);
        }

        /// <summary>
        ///     顯示
        /// </summary>
        public static void Show(this Transform t)
        {
            t.gameObject.SetActive(true);
        }

        /// <summary>
        ///     顯示
        /// </summary>
        public static void Show(this MonoBehaviour t)
        {
            t.gameObject.SetActive(true);
        }

        /// <summary>
        ///     獲取第一個Monobehavior
        /// </summary>
        public static T GetClass<T>(this GameObject t) where T : class
        {
            return t.GetComponent(typeof(T)) as T;
        }

        /// <summary>
        ///     獲取第一個Monobehavior
        /// </summary>
        public static T GetClass<T>(this Transform t) where T : class
        {
            return t.GetComponent(typeof(T)) as T;
        }

        /// <summary>
        ///     獲取所有Monobehavior
        /// </summary>
        public static T[] GetClasses<T>(this GameObject t) where T : class
        {
            var ts = t.GetComponents(typeof(T));
            var ret = new T[ts.Length];
            for (var i = 0; i < ts.Length; i++) ret[i] = ts[i] as T;
            return ret;
        }

        /// <summary>
        ///     獲取所有Monobehavior
        /// </summary>
        public static T[] GetClasses<T>(this Transform t) where T : class
        {
            var ts = t.GetComponents(typeof(T));
            var ret = new T[ts.Length];
            for (var i = 0; i < ts.Length; i++) ret[i] = ts[i] as T;
            return ret;
        }

        /// <summary>
        ///     獲取所有自身和子物體的Mono
        /// </summary>
        public static T[] GetClassesInChildren<T>(this GameObject t) where T : class
        {
            var ts = t.GetComponentsInChildren(typeof(T));
            var ret = new T[ts.Length];
            for (var i = 0; i < ts.Length; i++) ret[i] = ts[i] as T;
            return ret;
        }

        /// <summary>
        ///     獲取所有自身和子物體的Mono
        /// </summary>
        public static T[] GetClassesInChildren<T>(this Transform t) where T : class
        {
            var ts = t.GetComponentsInChildren(typeof(T));
            var ret = new T[ts.Length];
            for (var i = 0; i < ts.Length; i++) ret[i] = ts[i] as T;
            return ret;
        }

        /// <summary>
        ///     檢查是否在指定圖層裏
        /// </summary>
        public static bool IsInLayerMask(this GameObject t, LayerMask mask)
        {
            return (mask.value & (1 << t.layer)) > 0;
        }

        /// <summary>
        ///     檢查是否在指定圖層裏
        /// </summary>
        public static bool IsInLayerMask(this Transform t, LayerMask mask)
        {
            return (mask.value & (1 << t.gameObject.layer)) > 0;
        }

        /// <summary>
        ///     添加組件
        /// </summary>
        public static T AddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.AddComponent<T>();
        }

        /// <summary>
        ///     獲取或添加組件
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject t) where T : Component
        {
            return t.GetComponent<T>() ?? t.AddComponent<T>();
        }

        /// <summary>
        ///     獲取或添加組件
        /// </summary>
        public static T GetOrAddComponent<T>(this Transform t) where T : Component
        {
            return t.GetComponent<T>() ?? t.gameObject.AddComponent<T>();
        }

        /// <summary>
        ///     獲取或添加組件
        /// </summary>
        public static T GetOrAddComponent<T>(this Component t) where T : Component
        {
            return t.GetComponent<T>() ?? t.AddComponent<T>();
        }

        /// <summary>
        ///     是否擁有組件
        /// </summary>
        public static bool HasComponent<T>(this GameObject t) where T : Component
        {
            return t.GetComponent<T>() != null;
        }

        /// <summary>
        ///     是否擁有組件
        /// </summary>
        public static bool HasComponent<T>(this Transform t) where T : Component
        {
            return t.GetComponent<T>() != null;
        }

        /// <summary>
        ///     是否擁有組件
        /// </summary>
        public static bool HasComponent<T>(this Component t) where T : Component
        {
            return t.GetComponent<T>() != null;
        }

        /// <summary>
        ///     添加子物体
        /// </summary>
        public static void AddChildren(this Transform transform, GameObject[] children)
        {
            Array.ForEach(children, child => child.transform.parent = transform);
        }

        /// <summary>
        ///     添加子組件
        /// </summary>
        public static void AddChildren(this Transform transform, Component[] children)
        {
            Array.ForEach(children, child => child.transform.parent = transform);
        }

        /// <summary>
        ///     重設子物體位置為0
        /// </summary>
        public static void ResetChildPositions(this Transform t)
        {
            var ts = t.GetAllTComponents<Transform>();
            ts = ts.Remove(t);
            foreach (var t1 in ts)
                t1.position = Vector3.zero;
        }

        /// <summary>
        ///     重設子物體圖層
        /// </summary>
        public static void ResetChildLayers(this Transform t, int layer)
        {
            var ts = t.GetAllTComponents<Transform>();
            ts = ts.Remove(t);
            foreach (var t1 in ts)
                t1.gameObject.layer = layer;
        }

        /// <summary>
        ///     獲取物體和子物體的指定所有組件
        /// </summary>
        public static T[] GetAllTComponents<T>(this GameObject t) where T : Component
        {
            return t.GetComponentsInChildren<T>();
        }

        /// <summary>
        ///     獲取物體和子物體的指定所有組件
        /// </summary>
        public static T[] GetAllTComponents<T>(this Transform t) where T : Component
        {
            return t.GetComponentsInChildren<T>();
        }

        /// <summary>
        ///     獲取根物體
        /// </summary>
        public static GameObject FindRoot(this GameObject t)
        {
            var target = t;
            while (target.transform.parent != null) target = target.transform.parent.gameObject;
            return target;
        }

        /// <summary>
        ///     獲取根物體
        /// </summary>
        public static Transform FindRoot(this Transform t)
        {
            var target = t;
            while (target.transform.parent != null) target = target.transform.parent;
            return target;
        }

        #endregion

        #region RayCast

        /// <summary>
        ///     获取摄像机中心射线检测获得
        /// </summary>
        public static RaycastHit CameraCenterRayCast(this Camera t)
        {
            var ray = t.ScreenPointToRay(new Vector2(t.pixelWidth / 2f,
                t.pixelHeight / 2f));
            return Physics.Raycast(ray, out var hit) ? hit : default;
        }

        /// <summary>
        ///     获取摄像机中心射线检测获得
        /// </summary>
        public static RaycastHit CameraCenterRayCast(this Camera t, float range)
        {
            var ray = t.ScreenPointToRay(new Vector2(t.pixelWidth / 2f,
                t.pixelHeight / 2f));
            return Physics.Raycast(ray, out var hit, range) ? hit : default;
        }

        /// <summary>
        ///     获取点击处射线检测获得
        /// </summary>
        public static RaycastHit ClickRay(this Transform t, float range)
        {
            return Physics.Raycast(t.position,
                new Vector3(GetMouseRayPosition().x - t.position.x, t.position.y,
                    GetMouseRayPosition().z - t.position.z), out var hit, range)
                ? hit
                : default;
        }

        /// <summary>
        ///     获取鼠标世界位置
        /// </summary>
        public static Vector2 MouseWorldPos2()
        {
            return Camera.main!.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }

        /// <summary>
        ///     获取鼠标世界位置
        /// </summary>
        public static Vector3 MouseWorldPos3()
        {
            return Camera.main!.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Input.mousePosition.z));
        }

        /// <summary>
        ///     射线检测2D
        /// </summary>
        public static RaycastHit2D RayCast2D(Vector2 position, Vector2 direction, float length, LayerMask layer)
        {
            return Physics2D.Raycast(position, direction, length, layer);
        }

        /// <summary>
        ///     射线检测2D
        /// </summary>
        public static bool IsRayCast2D(Vector2 position, Vector2 direction, float length, LayerMask layer)
        {
            return Physics2D.Raycast(position, direction, length, layer);
        }

        #endregion

        #region Math

        /// <summary>
        ///     标准化到1
        /// </summary>
        public static int NormalizeToOne(this int t)
        {
            return t switch
            {
                > 0 => 1,
                0 => 0,
                _ => -1
            };
        }

        /// <summary>
        ///     标准化到1
        /// </summary>
        public static int NormalizeToOne(this float t)
        {
            return t switch
            {
                > 0f => 1,
                0f => 0,
                _ => -1
            };
        }

        /// <summary>
        ///     标准化到1
        /// </summary>
        public static int NormalizeToOne(this double t)
        {
            return t switch
            {
                > 0.0 => 1,
                0.0 => 0,
                _ => -1
            };
        }

        /// <summary>
        ///     随机概率（t分之i）
        /// </summary>
        public static bool NextChance(int i, int t)
        {
            return MathV.Next(0, t) < i;
        }

        /// <summary>
        ///     随机概率（i分之一）
        /// </summary>
        public static bool NextChance(int i)
        {
            return MathV.Next(0, i) == 0;
        }

        /// <summary>
        ///     反比例
        /// </summary>
        public static float InverseScale(this float t, float k)
        {
            return t == 0 ? 0 : k / t;
        }

        /// <summary>
        ///     反比例
        /// </summary>
        public static float InverseScale1(this float t)
        {
            return t == 0 ? 0 : 1 / t;
        }

        /// <summary>
        ///     和等于目标的子数组个数
        /// </summary>
        public static int NumOfSubArraysWithSum(int[] arr, int s)
        {
            var sum = 0;
            var cnt = new Dictionary<int, int>();
            var ret = 0;
            foreach (var num in arr)
            {
                cnt[sum] = cnt.GetOrDefault(sum, 0) + 1;
                sum += num;
                ret += cnt.GetOrDefault(sum - s, 0);
            }

            return ret;
        }

        /// <summary>
        ///     计票最多并且字典序最前的选举
        /// </summary>
        public static string CandidateWithTheMostVotes(List<string> votes)
        {
            var result = "";
            var count = 0;
            var dic = new Dictionary<string, int>();
            foreach (var word in votes)
            {
                if (dic.ContainsKey(word))
                    dic[word] += 1;
                else
                    dic[word] = 1;
                var cnt = dic[word];
                if (cnt <= count &&
                    (cnt != count || string.Compare(word, result, StringComparison.Ordinal) >= 0)) continue;
                result = word;
                count = cnt;
            }

            return result;
        }

        /// <summary>
        ///     查询超过其他元素的百分比
        /// </summary>
        public static List<int> QueryRanking(int max, List<int> score, List<int> ask)
        {
            var sc = new int[max + 1];
            foreach (var s in score) sc[s]++;
            for (var i = 1; i < sc.Length; i++) sc[i] += sc[i - 1];
            return ask.Select(index => (sc[score[index - 1]] - 1) * 100 / score.Count).ToList();
        }

        /// <summary>
        ///     Arduino转化Bits
        /// </summary>
        public static int ToBits(int[] led, int len)
        {
            var leds = 0;
            for (var i = 0; i < len; ++i) leds += 1 << (led[i] - 1);
            return leds;
        }

        /// <summary>
        ///     Arduino转化Binary
        /// </summary>
        public static int ArduinoToBinary(int[] led, int len)
        {
            var leds = 0;
            for (var i = 0; i < len; ++i) leds += (int)Math.Pow(10, led[i]);
            return leds;
        }

        /// <summary>
        ///     Arduino转化Bits
        /// </summary>
        public static int ToBits(IEnumerable<int> led)
        {
            return led.Sum(t => 1 << (t - 1));
        }

        /// <summary>
        ///     找到出现次数最多的元素
        /// </summary>
        public static T MostOccurrences<T>(this T[] arr)
        {
            var len = arr.Length;
            var max = 0;
            T num = default;
            var temps = new List<T>();
            for (var i = 0; i < len; i++)
            {
                if (temps.Contains(arr[i])) continue;
                var count = 0;
                for (var j = 0; j < len; j++)
                    if (arr[i].Equals(arr[j]))
                        count++;
                if (count > max)
                {
                    max = count;
                    num = arr[i];
                }

                temps.Add(arr[i]);
            }

            return num;
        }

        /// <summary>
        ///     找到出现次数最少的元素
        /// </summary>
        public static T MinOccurrences<T>(this T[] arr)
        {
            var len = arr.Length;
            var max = 0;
            T num = default;
            var temps = new List<T>();
            for (var i = 0; i < len; i++)
            {
                if (temps.Contains(arr[i])) continue;
                var count = 0;
                for (var j = 0; j < len; j++)
                    if (arr[i].Equals(arr[j]))
                        count++;
                if (count < max)
                {
                    max = count;
                    num = arr[i];
                }

                temps.Add(arr[i]);
            }

            return num;
        }

        /// <summary>
        ///     找到出现次数最多的元素
        /// </summary>
        public static T MostOccurrences<T>(this List<T> arr)
        {
            var len = arr.Count;
            var max = 0;
            T num = default;
            var temps = new List<T>();
            for (var i = 0; i < len; i++)
            {
                if (temps.Contains(arr[i])) continue;
                var count = 0;
                for (var j = 0; j < len; j++)
                    if (arr[i].Equals(arr[j]))
                        count++;
                if (count > max)
                {
                    max = count;
                    num = arr[i];
                }

                temps.Add(arr[i]);
            }

            return num;
        }

        /// <summary>
        ///     找到出现次数最少的元素
        /// </summary>
        public static T MinOccurrences<T>(this List<T> arr)
        {
            var len = arr.Count;
            var max = 0;
            T num = default;
            var temps = new List<T>();
            for (var i = 0; i < len; i++)
            {
                if (temps.Contains(arr[i])) continue;
                var count = 0;
                for (var j = 0; j < len; j++)
                    if (arr[i].Equals(arr[j]))
                        count++;
                if (count < max)
                {
                    max = count;
                    num = arr[i];
                }

                temps.Add(arr[i]);
            }

            return num;
        }

        /// <summary>
        ///     上一个
        /// </summary>
        public static T LastOne<T>(this T one, T[] list)
        {
            if (list.IsEmpty() || !one.In(list)) return default;
            var id = one.GetId(list);
            return id == 0 ? list[^1] : list[id - 1];
        }

        /// <summary>
        ///     上一个
        /// </summary>
        public static T LastOne<T>(this T one, List<T> list)
        {
            if (list.IsEmpty() || !one.In(list)) return default;
            var id = one.GetId(list);
            return id == 0 ? list[^1] : list[id - 1];
        }

        /// <summary>
        ///     下一个
        /// </summary>
        public static T NextOne<T>(this T one, List<T> list)
        {
            if (list.IsEmpty() || !one.In(list)) return default;
            var id = one.GetId(list);
            return id == list.Count - 1 ? list[0] : list[id + 1];
        }

        /// <summary>
        ///     下一个
        /// </summary>
        public static T NextOne<T>(this T one, T[] list)
        {
            if (list.IsEmpty() || !one.In(list)) return default;
            var id = one.GetId(list);
            return id == list.Length - 1 ? list[0] : list[id + 1];
        }

        /// <summary>
        ///     获取
        /// </summary>
        public static T Get<T>(this T[] t, int i)
        {
            return t[i];
        }

        /// <summary>
        ///     获取
        /// </summary>
        public static T Get<T>(this List<T> t, int i)
        {
            return t[i];
        }

        /// <summary>
        ///     获取
        /// </summary>
        public static T Get<T>(this IList<T> t, int i)
        {
            return t[i];
        }

        /// <summary>
        ///     获取
        /// </summary>
        public static T Get<T>(this Dictionary<T, T> t, T i)
        {
            return t[i];
        }

        /// <summary>
        ///     获取
        /// </summary>
        public static T Get<T>(this IDictionary<T, T> t, T i)
        {
            return t[i];
        }

        /// <summary>
        ///     sin插值
        /// </summary>
        public static float Sinerp(float start, float end, float value)
        {
            return MathV.Lerp(start, end, MathV.Sin(value * MathV.Pi * 0.5f));
        }

        /// <summary>
        ///     cos插值
        /// </summary>
        public static float Coserp(float start, float end, float value)
        {
            return MathV.Lerp(start, end, 1.0f - MathV.Cos(value * MathV.Pi * 0.5f));
        }

        /// <summary>
        ///     CoSin插值
        /// </summary>
        public static float CoSinLerp(float start, float end, float value)
        {
            return MathV.Lerp(start, end, value * value * (3.0f - 2.0f * value));
        }

        /// <summary>
        ///     随机正负
        /// </summary>
        public static int NextPoNe()
        {
            return MathV.RandomV.NextDouble() > 0.5 ? -1 : 1;
        }

        /// <summary>
        ///     按值分割
        /// </summary>
        public static List<double> LinSpaceByValue(double min, double end, double t)
        {
            if (t == 0 || end < min) return default;
            var temp = new List<double>();
            var cp = min;
            while (cp < end)
            {
                temp.Add(cp);
                cp += t;
            }

            return temp;
        }

        /// <summary>
        ///     按点分割
        /// </summary>
        public static double[] LinSpaceByCount(double min, double end, int t)
        {
            var temp = new double[t];
            var delta = (end - min) / t;
            for (var i = 0; i < t; i++) temp[i] = min + delta * i;
            return temp;
        }

        /// <summary>
        ///     首项a，第n项b，公差d
        /// </summary>
        public static double GetSumOfArithmeticSequence(double a, double b, double d)
        {
            return ((b - a) / d + 1) * (a + b) / 2;
        }

        /// <summary>
        ///     首项a，第n项，公比q
        /// </summary>
        public static double GetSumOfProportionalSequence(double a, double q, double n)
        {
            return a * (1 - Math.Pow(q, n) / (1 - q));
        }

        /// <summary>
        ///     二项式阵列
        /// </summary>
        public static List<int> GetBinomialArrayRow(int rowIndex)
        {
            var row = new List<int> { 1 };
            for (var i = 1; i <= rowIndex; ++i) row.Add((int)((long)row[i - 1] * (rowIndex - i + 1) / i));
            return row;
        }

        #endregion

        #region Vector

        #region Vector2

        /// <summary>
        ///     获取位置
        /// </summary>
        public static Vector2 Postion(this GameObject t)
        {
            return t.transform.position;
        }

        /// <summary>
        ///     获取位置
        /// </summary>
        public static Vector2 Postion(this Transform t)
        {
            return t.position;
        }

        /// <summary>
        ///     获取位置
        /// </summary>
        public static Vector2 Postion(this MonoBehaviour t)
        {
            return t.transform.position;
        }

        /// <summary>
        ///     拖拽
        /// </summary>
        public static void OnAxisDrag(this Transform t, float x, float y)
        {
            var initial = t.position - Time.timeScale * x * t.transform.right;
            t.position = initial - Time.timeScale * y * t.up;
        }

        /// <summary>
        ///     拖拽
        /// </summary>
        public static void OnMouseAxisDrag(this Transform t)
        {
            var initial = t.position - Time.timeScale * MouseWorldPos2().x * t.transform.right;
            t.position = initial - Time.timeScale * MouseWorldPos2().y * t.up;
        }

        /// <summary>
        ///     鼠标拖拽
        /// </summary>
        public static void OnMouseDrag(this RectTransform t, PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    t.parent.GetComponent<RectTransform>(),
                    eventData.position,
                    eventData.pressEventCamera,
                    out var pos))
                t.anchoredPosition = pos;
        }

        /// <summary>
        ///     缓慢移动
        /// </summary>
        public static void SlowTranslateUp(this Transform t, float speed)
        {
            t.Translate(speed * Time.deltaTime * Vector3.up);
        }

        /// <summary>
        ///     缓慢移动
        /// </summary>
        public static void SlowTranslateDown(this Transform t, float speed)
        {
            t.Translate(speed * Time.deltaTime * Vector3.down);
        }

        /// <summary>
        ///     缓慢移动
        /// </summary>
        public static void SlowTranslateLeft(this Transform t, float speed)
        {
            t.Translate(speed * Time.deltaTime * Vector3.left);
        }

        /// <summary>
        ///     缓慢移动
        /// </summary>
        public static void SlowTranslateRight(this Transform t, float speed)
        {
            t.Translate(speed * Time.deltaTime * Vector3.right);
        }

        /// <summary>
        ///     范围插值
        /// </summary>
        public static float RangeLerp(this Vector2 v, float t)
        {
            return MathV.Lerp(v.x, v.y, t);
        }

        /// <summary>
        ///     范围Inverse插值
        /// </summary>
        public static float RangeInverseLerp(this Vector2 v, float value)
        {
            return MathV.InverseLerp(v.x, v.y, value);
        }

        /// <summary>
        ///     范围随机Vector
        /// </summary>
        public static float RangeRandom(this Vector2 v)
        {
            return MathV.Next(v.x, v.y);
        }

        /// <summary>
        ///     Vector最小
        /// </summary>
        public static float ComponentMin(this Vector2 v)
        {
            return MathV.Min(v.x, v.y);
        }

        /// <summary>
        ///     Vector最大
        /// </summary>
        public static float ComponentMax(this Vector2 v)
        {
            return MathV.Max(v.x, v.y);
        }

        /// <summary>
        ///     Vector绝对值
        /// </summary>
        public static Vector2 ComponentAbs(this Vector2 v)
        {
            return new Vector2(MathV.Abs(v.x), MathV.Abs(v.y));
        }

        /// <summary>
        ///     Vector乘
        /// </summary>
        public static Vector2 ComponentMultiply(this Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }

        /// <summary>
        ///     Vector取整
        /// </summary>
        public static Vector2 Round(this Vector2 v)
        {
            return new Vector2(MathV.Round(v.x), MathV.Round(v.y));
        }

        /// <summary>
        ///     Vector按小数点取整
        /// </summary>
        public static Vector2 Round(this Vector2 v, int digits)
        {
            return new Vector2((float)Math.Round(v.x, digits), (float)Math.Round(v.y, digits));
        }

        /// <summary>
        ///     Vector取整到int
        /// </summary>
        public static Vector2Int RoundToInt(this Vector2 v)
        {
            return new Vector2Int(MathV.RoundToInt(v.x), MathV.RoundToInt(v.y));
        }

        /// <summary>
        ///     范围插值
        /// </summary>
        public static float RangeLerp(this Vector2Int v, float t)
        {
            return MathV.Lerp(v.x, v.y, t);
        }

        /// <summary>
        ///     范围Inverse插值
        /// </summary>
        public static float RangeInverseLerp(this Vector2Int v, float value)
        {
            return MathV.InverseLerp(v.x, v.y, value);
        }

        /// <summary>
        ///     范围随机
        /// </summary>
        public static int RangeRandom(this Vector2Int v)
        {
            return MathV.Next(v.x, v.y);
        }

        /// <summary>
        ///     Vector最大
        /// </summary>
        public static int ComponentMax(this Vector2Int v)
        {
            return MathV.Max(v.x, v.y);
        }

        /// <summary>
        ///     Vector最小
        /// </summary>
        public static int ComponentMin(this Vector2Int v)
        {
            return MathV.Min(v.x, v.y);
        }

        /// <summary>
        ///     Vector绝对值
        /// </summary>
        public static Vector2Int ComponentAbs(this Vector2Int v)
        {
            return new Vector2Int(MathV.Abs(v.x), MathV.Abs(v.y));
        }

        /// <summary>
        ///     Vector乘
        /// </summary>
        public static Vector2Int ComponentMultiply(this Vector2Int v1, Vector2Int v2)
        {
            return new Vector2Int(v1.x * v2.x, v1.y * v2.y);
        }

        #endregion

        #region Vector3

        /// <summary>
        ///     追踪弹
        /// </summary>
        public static IEnumerator BulletFollowing(Transform t, Transform target, float minAngle, float maxAngle)
        {
            var nextAngle = MathV.Next(minAngle, maxAngle);
            while (Distance3(t.position, target.position) >= 0.25f)
            {
                var targetDir = target.position - t.position;
                t.rotation = Quaternion.AngleAxis(MathV.Atan2(targetDir.z, target.position.x) * 57.29578f,
                    Vector3.forward);
                t.rotation *= Quaternion.Euler(0f, 0f, nextAngle);
                t.position = Vector3Lerp(t.position, target.position, 0.01f);
                yield return null;
            }
        }

        /// <summary>
        ///     获取鼠标的坐标位置
        /// </summary>
        public static Vector3 GetMouseRayPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out var hit) ? hit.point : default;
        }

        /// <summary>
        ///     标准化到1
        /// </summary>
        public static Vector3 NormalizeToOne(this Vector3 t)
        {
            return new Vector3(t.x.NormalizeToOne(), t.y.NormalizeToOne(), t.z.NormalizeToOne());
        }

        /// <summary>
        ///     欧拉角标准化
        /// </summary>
        public static Vector3 EulerNormalize(this Vector3 angles)
        {
            for (var i = 0; i < 3; i++)
                angles[i] = angles[i] switch
                {
                    < -180 => angles[i] + 360,
                    > 180 => angles[i] - 360,
                    _ => angles[i]
                };
            return angles;
        }

        /// <summary>
        ///     Vector最大
        /// </summary>
        public static float ComponentMax(this Vector3 v)
        {
            return MathV.Max(v.x, MathV.Max(v.y, v.z));
        }

        /// <summary>
        ///     Vector最小
        /// </summary>
        public static float ComponentMin(this Vector3 v)
        {
            return MathV.Min(v.x, MathV.Min(v.y, v.z));
        }

        /// <summary>
        ///     Vector绝对值
        /// </summary>
        public static Vector3 ComponentAbs(this Vector3 v)
        {
            return new Vector3(MathV.Abs(v.x), MathV.Abs(v.y), MathV.Abs(v.z));
        }

        /// <summary>
        ///     Vector乘
        /// </summary>
        public static Vector3 ComponentMultiply(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        /// <summary>
        ///     Vector取整
        /// </summary>
        public static Vector3 Round(this Vector3 v)
        {
            return new Vector3(MathV.Round(v.x), MathV.Round(v.y), MathV.Round(v.z));
        }

        /// <summary>
        ///     Vector按小数点取整
        /// </summary>
        public static Vector3 Round(this Vector3 v, int digits)
        {
            return new Vector3((float)Math.Round(v.x, digits), (float)Math.Round(v.y, digits),
                (float)Math.Round(v.z, digits));
        }

        /// <summary>
        ///     Vector取整到int
        /// </summary>
        public static Vector3Int RoundToInt(this Vector3 v)
        {
            return new Vector3Int(MathV.RoundToInt(v.x), MathV.RoundToInt(v.y), MathV.RoundToInt(v.z));
        }

        /// <summary>
        ///     Vector转color
        /// </summary>
        public static Color ToColor(this Vector3 v)
        {
            return new Color(v.x, v.y, v.z);
        }

        /// <summary>
        ///     Vector转color256
        /// </summary>
        public static Color ToColor256(this Vector3 v)
        {
            return new Color(v.x / 255f, v.y / 255f, v.z / 255f);
        }

        /// <summary>
        ///     欧拉角标准化
        /// </summary>
        public static Vector3Int EulerNormalize(this Vector3Int angles)
        {
            for (var i = 0; i < 3; i++)
                angles[i] = angles[i] switch
                {
                    < -180 => angles[i] + 360,
                    > 180 => angles[i] - 360,
                    _ => angles[i]
                };
            return angles;
        }

        /// <summary>
        ///     Vector最大
        /// </summary>
        public static int ComponentMax(this Vector3Int v)
        {
            return MathV.Max(v.x, MathV.Max(v.y, v.z));
        }

        /// <summary>
        ///     Vector最小
        /// </summary>
        public static int ComponentMin(this Vector3Int v)
        {
            return MathV.Min(v.x, MathV.Min(v.y, v.z));
        }

        /// <summary>
        ///     Vector绝对值
        /// </summary>
        public static Vector3Int ComponentAbs(this Vector3Int v)
        {
            return new Vector3Int(MathV.Abs(v.x), MathV.Abs(v.y), MathV.Abs(v.z));
        }

        /// <summary>
        ///     Vector乘
        /// </summary>
        public static Vector3Int ComponentMultiply(this Vector3Int v1, Vector3Int v2)
        {
            return new Vector3Int(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        #endregion

        #region Common

        /// <summary>
        ///     Vector3圆内随机点
        /// </summary>
        public static Vector3 NextCircularPoint3(this Vector3 center, float radius)
        {
            var num1 = MathV.Next(-radius, radius);
            var num2 = Math.Sqrt(radius * radius - num1 * num1);
            return new Vector3(center.x + num1, center.y, (float)(center.z + MathV.Next(-num2, num2)));
        }

        /// <summary>
        ///     鏡像對稱
        /// </summary>
        public static Vector3 MirrorSymmetry(this Vector3 t, Vector3 center)
        {
            return new Vector3(2.0f * center.x - t.x,
                2.0f * center.y - t.y,
                2.0f * center.z - t.z);
        }

        /// <summary>
        ///     获取距离最近的物体
        /// </summary>
        public static GameObject GetNearestGameObject(this GameObject source, GameObject[] destObjects)
        {
            var nearest = destObjects[0];
            var shortestDistance = Distance3(source.transform.position, destObjects[0].transform.position);
            foreach (var obj in destObjects)
            {
                var distance = Distance3(source.transform.position, obj.transform.position);
                if (!(distance < shortestDistance)) continue;
                nearest = obj;
                shortestDistance = distance;
            }

            return nearest;
        }

        /// <summary>
        ///     調整剛體方向
        /// </summary>
        public static void ChangeDirection2(this Rigidbody t, Vector2 direction)
        {
            t.velocity = direction * t.velocity.magnitude;
        }

        /// <summary>
        ///     調整剛體方向
        /// </summary>
        public static void ChangeDirection3(this Rigidbody t, Vector3 direction)
        {
            t.velocity = direction * t.velocity.magnitude;
        }

        /// <summary>
        ///     Vector2夹角
        /// </summary>
        public static float GetAngle2(this Vector2 start, Vector2 end)
        {
            var dir = (end - start).normalized;
            return MathV.Atan2(dir.y, dir.x) * 57.29578f;
        }

        /// <summary>
        ///     Vector3夹角
        /// </summary>
        public static float GetAngle3(this Vector3 start, Vector3 end)
        {
            var dir = (end - start).normalized;
            return MathV.Atan2(dir.y, dir.x) * 57.29578f;
        }

        /// <summary>
        ///     Vector2圆内随机点
        /// </summary>
        public static Vector2 NextCircularPoint(this Vector2 center, float radius)
        {
            var num1 = MathV.Next(-radius, radius);
            var num2 = Math.Sqrt(radius * radius - num1 * num1);
            return new Vector2(center.x + num1, (float)(center.y + MathV.Next(-num2, num2)));
        }

        /// <summary>
        ///     Vector2圆上随机点
        /// </summary>
        public static Vector2 NextOnCircularPoint(this Vector2 center, float radius)
        {
            var num1 = MathV.Next(-radius, radius);
            var num2 = Math.Sqrt(radius * radius - num1 * num1) * NextPoNe();
            return new Vector2(center.x + num1, (float)(center.y + num2));
        }

        /// <summary>
        ///     Vector2正方形内随机点
        /// </summary>
        public static Vector2 NextSquarePoint(this Vector2 center, float square)
        {
            var num1 = MathV.Next(-square, square);
            var num2 = MathV.Next(-square, square);
            return new Vector2(center.x + num1, center.y + num2);
        }

        /// <summary>
        ///     Vector2两点距离
        /// </summary>
        public static float Distance2(this Vector2 a, Vector2 b)
        {
            var num1 = (double)(a.x - b.x);
            var num2 = (double)(a.y - b.y);
            return (float)Math.Sqrt(num1 * num1 + num2 * num2);
        }

        /// <summary>
        ///     Vector3两点距离
        /// </summary>
        public static float Distance3(this Vector3 a, Vector3 b)
        {
            var num1 = (double)(a.x - b.x);
            var num2 = (double)(a.y - b.y);
            var num3 = (double)(a.z - b.z);
            return (float)Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3);
        }

        /// <summary>
        ///     Vector2两点中点
        /// </summary>
        public static Vector2 Middle2(this Vector2 a, Vector2 b)
        {
            return new Vector2((a.x + b.x) / 2, (a.y + b.y) / 2);
        }

        /// <summary>
        ///     Vector2中点
        /// </summary>
        public static Vector2 Middle2(this Vector2[] t)
        {
            var length = t.Length;
            var num1 = 0f;
            var num2 = 0f;
            for (var i = 0; i < length; i++)
            {
                num1 += t[i].x;
                num2 += t[i].y;
            }

            return new Vector2(num1 / length, num2 / length);
        }

        /// <summary>
        ///     Vector3两点中点
        /// </summary>
        public static Vector3 Middle3(this Vector3 a, Vector3 b)
        {
            return new Vector3((a.x + b.x) / 2, (a.y + b.y) / 2, (a.z + b.z) / 2);
        }

        /// <summary>
        ///     Vector2中点
        /// </summary>
        public static Vector3 Middle3(this Vector3[] t)
        {
            var length = t.Length;
            var num1 = 0f;
            var num2 = 0f;
            var num3 = 0f;
            for (var i = 0; i < length; i++)
            {
                num1 += t[i].x;
                num2 += t[i].y;
                num3 += t[i].z;
            }

            return new Vector3(num1 / length, num2 / length, num3 / length);
        }

        /// <summary>
        ///     Vector3二阶贝塞尔点
        /// </summary>
        public static Vector3 Bezier(Vector3 start, Vector3 mid, Vector3 end, float t)
        {
            return (1.0f - t) * (1.0f - t) * start + 2.0f * t * (1.0f - t) * mid + t * t * end;
        }

        /// <summary>
        ///     Vector3—t阶贝塞尔点
        /// </summary>
        public static Vector3 BezierMethod(float t, List<Vector3> forceList)
        {
            while (true)
            {
                if (forceList.Count < 2) return forceList[0];
                var temp = new List<Vector3>();
                for (var i = 0; i < forceList.Count - 1; i++)
                {
                    Debug.DrawLine(forceList[i], forceList[i + 1], Color.yellow);
                    var proportion = (1 - t) * forceList[i] + t * forceList[i + 1];
                    temp.Add(proportion);
                }

                forceList = temp;
            }
        }

        #endregion

        #endregion

        #region Delay

        /// <summary>
        ///     获取现在具体時間
        /// </summary>
        public static string GetCurrentTime()
        {
            var dateTime = DateTime.Now;
            var strNowTime =
                $"{dateTime.Year:D}-{dateTime.Month:D}-{dateTime.Day:D}-{dateTime.Hour:D}-{dateTime.Minute:D}-{dateTime.Second:D}";
            return strNowTime;
        }

        /// <summary>
        ///     获取现在時間
        /// </summary>
        public static string CurrentTime()
        {
            var dateTime = DateTime.Now;
            var strNowTime =
                $"{dateTime.Hour:D}-{dateTime.Minute:D}";
            return strNowTime;
        }

        /// <summary>
        ///     時間差值
        /// </summary>
        public static double GetTimeDelta(this DateTime t)
        {
            var startSpan = new TimeSpan(t.Ticks);
            var nowSpan = new TimeSpan(DateTime.Now.Ticks);
            var subTimer = nowSpan.Subtract(startSpan).Duration();
            return subTimer.TotalSeconds;
        }

        /// <summary>
        ///     协程延迟
        /// </summary>
        public static IEnumerator IteratorDelay(float t, Action action)
        {
            yield return new WaitForSeconds(t);
            action();
        }

        /// <summary>
        ///     异步延迟
        /// </summary>
        public static async void AsyncDelay(float t, Action action)
        {
            await Task.Delay((int)(t * 1000));
            action?.Invoke();
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void Delay(int t, Action action)
        {
            AsyncDelay(t, action);
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void Delay(float t, Action action)
        {
            AsyncDelay(t, action);
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void Delay(double t, Action action)
        {
            AsyncDelay((float)t, action);
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void DelayFunc(int t, Action action)
        {
            AsyncDelay(t, action);
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void DelayFunc(float t, Action action)
        {
            AsyncDelay(t, action);
        }

        /// <summary>
        ///     延迟
        /// </summary>
        public static void DelayFunc(double t, Action action)
        {
            AsyncDelay((float)t, action);
        }

        #endregion
    }

    public static class AnimationControl
    {
        /// <summary>
        ///     清除片段
        /// </summary>
        public static void Clear(this AnimationCurve curve)
        {
            Array.Clear(curve.keys, 0, curve.length);
        }

        /// <summary>
        ///     合并片段
        /// </summary>
        public static void Merge(this AnimationCurve curve, AnimationCurve other)
        {
            for (var i = 0; i < other.length; i++) curve.AddKey(other[i]);
        }

        /// <summary>
        ///     替換片段
        /// </summary>
        public static void Replace(this AnimationCurve curve, AnimationCurve other)
        {
            if (other.length == 0) return;
            if (other[0].time > other[other.length - 1].time)
            {
                Debug.LogErrorFormat("無效的替換範圍： {0} - {1}", other[0].time, other[other.length - 1].time);
                return;
            }

            if (curve.length == 0)
            {
                curve.Merge(other);
            }
            else
            {
                var frameRange = new Vector2(curve[0].time, curve[curve.length - 1].time);
                var mergeRange = new Vector2(other[0].time, other[other.length - 1].time);
                if (mergeRange[1] < frameRange[0] || mergeRange[0] > frameRange[1])
                {
                    curve.Merge(other);
                }
                else
                {
                    var startIndex = GetIndex(mergeRange.x, curve.keys);
                    var endIndex = GetIndex(mergeRange.y, curve.keys);
                    if (mergeRange.x.Equals(curve[startIndex].time)) startIndex -= 1;
                    for (var i = startIndex; i < endIndex; i++) curve.RemoveKey(startIndex + 1);
                    curve.Merge(other);
                }
            }
        }

        /// <summary>
        ///     获取时间跨度
        /// </summary>
        public static float GetTimeSpan(this AnimationCurve curve)
        {
            if (curve.length <= 1) return 0;
            return curve.keys[curve.length - 1].time - curve.keys[0].time;
        }

        /// <summary>
        ///     获取最後一幀
        /// </summary>
        public static bool GetLastFrame(this AnimationCurve curve, out Keyframe keyframe)
        {
            if (curve.length > 0)
            {
                keyframe = curve.keys[curve.length - 1];
                return true;
            }

            keyframe = new Keyframe();
            return false;
        }

        /// <summary>
        ///     添加關鍵幀
        /// </summary>
        public static void AppendKey(this AnimationCurve curve, float time, float value)
        {
            var key = new Keyframe(time, value);
            var lastIndex = curve.length - 1;
            if (curve.length > 1 && curve.keys[lastIndex].value.Equals(value) &&
                curve.keys[lastIndex - 1].value.Equals(value))
                curve.RemoveKey(lastIndex);
            curve.AddKey(key);
        }

        /// <summary>
        ///     獲取Id
        /// </summary>
        public static int GetIndex(float time, IReadOnlyList<Keyframe> frames)
        {
            if (frames.Count == 0 || time < frames[0].time) return 0;
            var last = frames.Count - 1;
            return time >= frames[last].time ? last : GetIndex(time, frames, 0, last);
        }

        /// <summary>
        ///     獲取Id
        /// </summary>
        public static int GetIndex(float time, IReadOnlyList<Keyframe> frames, int min, int max)
        {
            while (true)
            {
                var mid = (min + max) / 2;
                if (mid == min) return min;
                if (time < frames[mid].time)
                {
                    max = mid;
                    continue;
                }

                if (!(time > frames[mid].time)) return mid;
                min = mid;
            }
        }
    }

    #region FootStep

    public static class FootStepRay
    {
        /// <summary>
        ///     获得ITrap
        /// </summary>
        public static ITrap GetITrap(this Transform t, float height)
        {
            var ray = new Ray(t.position, -t.up);
            if (!Physics.Raycast(ray, out var hit, height)) return null;
            var footStep = hit.transform.GetComponent<ITrap>();
            return footStep;
        }

        /// <summary>
        ///     获得ITrap
        /// </summary>
        public static IPortal GetIPortal(this Transform t, float height)
        {
            var ray = new Ray(new Vector3(t.position.x, t.position.y + height, t.position.z), -t.up);
            if (!Physics.Raycast(ray, out var hit, height)) return null;
            var footStep = hit.transform.GetComponent<IPortal>();
            return footStep;
        }

        /// <summary>
        ///     获得Id
        /// </summary>
        public static int GetIdInFootSteps(this Transform t, float height)
        {
            var ray = new Ray(t.position, -t.up);
            if (!Physics.Raycast(ray, out var hit, height)) return -1;
            if (hit.transform.GetComponent<IFootStep>() == null) return -1;
            var footStep = hit.transform.GetComponent<IFootStep>();
            return footStep.GetFootStepId();
        }

        /// <summary>
        ///     获得类型
        /// </summary>
        public static GroundType GetTypeInFootSteps(this Transform t, float height)
        {
            var ray = new Ray(t.position, -t.up);
            if (!Physics.Raycast(ray, out var hit, height)) return default;
            if (hit.transform.GetComponent<IFootStep>() == null) return default;
            var footStep = hit.transform.GetComponent<IFootStep>();
            return footStep.GetFootStepType();
        }


    }

    #endregion

    #region

    public static class ItemRay
    {

    }

    #endregion


    #region pHash

    public static class PHash
    {
        /// <summary>
        ///     压缩图片为8x8px
        /// </summary>
        public static Texture2D ReduceSize(Texture2D tex, int size)
        {
            if (tex == null || size <= 0) return null;
            var newTex = new Texture2D(size, size, TextureFormat.RGBA64, false);
            //比率
            var ratioW = (float)tex.width / size;
            var ratioH = (float)tex.height / size;
            for (var h = 0; h < newTex.height; h++)
                for (var w = 0; w < newTex.width; w++)
                {
                    var color = tex.GetPixel(MathV.RoundToInt(w * ratioW), MathV.RoundToInt(h * ratioH));
                    newTex.SetPixel(w, h, color);
                }

            newTex.Apply();
            return newTex;
        }

        /// <summary>
        ///     将8x8px的图片转换为灰度图
        /// </summary>
        public static Texture2D Tex2Gray(Texture2D tex)
        {
            var newTex = new Texture2D(tex.width, tex.height, TextureFormat.RGBA64, false);
            for (var h = 0; h < tex.height; h++)
                for (var w = 0; w < tex.width; w++)
                {
                    var color = tex.GetPixel(w, h);
                    var gray = (color.r * 29.9f + color.g * 58.7f + color.b * 11.4f) / 100;
                    newTex.SetPixel(w, h, new Color(gray, gray, gray));
                }

            newTex.Apply();
            return newTex;
        }

        /// <summary>
        ///     返回两张图片的相似度
        /// </summary>
        public static float PicSimilarity(Texture2D eTexture, Texture2D eTexture1)
        {
            if (eTexture == null || eTexture1 == null) return 0f;
            var tex64 = ReduceSize(eTexture, 16);
            var texGray = Tex2Gray(tex64);
            var texFloat = Dct.Image2F(texGray);
            var dctMatrix = Matrix.Multiply(Matrix.Multiply(Dct.DctMatrix, texFloat), Dct.DctMatrixT);
            var aver = Dct.AverageDct(dctMatrix);
            var hash = Dct.GetHash(dctMatrix, aver);
            var tex641 = ReduceSize(eTexture1, 16);
            var texGray1 = Tex2Gray(tex641);
            var texFloat1 = Dct.Image2F(texGray1);
            var dctMatrix1 = Matrix.Multiply(Matrix.Multiply(Dct.DctMatrix, texFloat1), Dct.DctMatrixT);
            var aver1 = Dct.AverageDct(dctMatrix1);
            var hash1 = Dct.GetHash(dctMatrix1, aver1);
            var dis = Dct.ComputeDistance(hash, hash1);
            return dis;
        }

        /// <summary>
        ///     最相似的图片Id
        /// </summary>
        public static int MaxSimilarityId(Texture2D input, Texture2D[] inputArray)
        {
            var similars = new List<float>();
            var length = inputArray.Length;
            for (var i = 0; i < length; i++) similars.Add(PicSimilarity(input, inputArray[i]));
            var maxSimilar = MathV.Max(similars);
            return maxSimilar.GetId(similars);
        }

        /// <summary>
        ///     最相似的图片
        /// </summary>
        public static Texture2D MaxSimilarityPic(Texture2D input, Texture2D[] inputArray)
        {
            var similars = new List<float>();
            var length = inputArray.Length;
            for (var i = 0; i < length; i++) similars.Add(PicSimilarity(input, inputArray[i]));
            var maxSimilar = MathV.Max(similars);
            var id = maxSimilar.GetId(similars);
            return inputArray[id];
        }
    }

    public class Dct
    {
        //8二维矩阵
        public static float[,] DctMatrix => CreateDctMatrix(8);

        //转置矩阵
        public static float[,] DctMatrixT => Matrix.Transpose(DctMatrix);

        //图片转矩阵
        public static float[,] Image2F(Texture2D tex)
        {
            var size = tex.width;
            var f = new float[size, size];
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    f[i, j] = tex.GetPixel(i, j).r;
            return f;
        }

        //计算DCT矩阵
        public static float[,] CreateDctMatrix(int size)
        {
            var ret = new float[size, size];
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                {
                    var angle = (y + 0.5f) * MathV.Pi * x / size;
                    ret[x, y] = CreateFunc(x, size) * MathV.Cos(angle);
                }

            return ret;
        }

        //创建DCT矩阵
        public static float CreateFunc(int n, int size)
        {
            return n == 0 ? MathV.Sqrt(1f / size) : MathV.Sqrt(2f / size);
        }

        //DCT均值
        public static float AverageDct(float[,] dct)
        {
            var size = dct.GetLength(0);
            float aver = 0;
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    aver += dct[i, j];
            return aver / (size * size);
        }

        //获取当前图片pHash值
        public static string GetHash(float[,] dct, float aver)
        {
            var hash = string.Empty;
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    hash += dct[i, j] >= aver ? "1" : "0";
            return hash;
        }

        //计算两图片哈希值的汉明距离
        public static float ComputeDistance(string hash1, string hash2)
        {
            var dis = 0f;
            for (var i = 0; i < hash1.Length; i++)
                if (hash1[i].Equals(hash2[i]))
                    dis++;

            return dis / hash1.Length;
        }
    }

    public static class Matrix
    {
        //矩阵转置
        public static float[,] Transpose(float[,] c)
        {
            var size = c.GetLength(0);
            var ret = new float[size, size];
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                    ret[y, x] = c[x, y];
            return ret;
        }

        //矩阵相乘
        public static float[,] Multiply(float[,] c1, float[,] c2)
        {
            var size = c1.GetLength(0);
            var ret = new float[size, size];
            for (var y = 0; y < size; y++)
                for (var x = 0; x < size; x++)
                {
                    var sum1 = 0f;
                    for (var k = 0; k < size; k++) sum1 += c1[x, k] * c2[k, y];
                    ret[x, y] = sum1;
                }

            return ret;
        }
    }

    #endregion
}