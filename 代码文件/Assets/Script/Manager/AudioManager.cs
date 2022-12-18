using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class AudioManager : ConfigActor<AudioManager>
    {
        //音效数组 
        public AudioClip[] AudioClipArray => DataManager.Instance.AudioClipArray;
        [Header("环境")] public AudioSource BackSource;
        [Header("效果")] public AudioSource EffectSource;
        [Header("场景")] public AudioSource SceneSource;
        [Header("音频源字典")] public Dictionary<int, AudioSource> SourceDic = new();

        [Header("UI")] public AudioSource UISource;

        //音效字典
        public Dictionary<int, AudioClip> AudioClioDic => DataManager.Instance.AudioClioDic;

        public override void OnStart()
        {
            base.OnStart();
            DontDestroyOnLoad(gameObject);
            SourceInit();
        }

        /// <summary>
        ///     按名字播放
        /// </summary>
        public void PlayByName(int sourceId, string nam)
        {
            if (!SourceDic.ContainsKey(sourceId)) return;
            foreach (var t in AudioClipArray)
                if (t.name == nam)
                {
                    SourceDic[sourceId].PlaySfx(t);
                    break;
                }
        }

        /// <summary>
        ///     静音或取消静音
        /// </summary>
        public void MuteInOrOut(int sourceId)
        {
            if (SourceDic.ContainsKey(sourceId)) SourceDic[sourceId].MuteInOrOut();
        }

        /// <summary>
        ///     设置音量
        /// </summary>
        public void SetVolume(int sourceId, float v)
        {
            if (SourceDic.ContainsKey(sourceId)) SourceDic[sourceId].volume = v;
        }

        /// <summary>
        ///     停止
        /// </summary>
        public void Stop(int sourceId)
        {
            if (SourceDic.ContainsKey(sourceId)) SourceDic[sourceId].StopPlay();
        }

        /// <summary>
        ///     暂停
        /// </summary>
        public void Pause(int sourceId)
        {
            if (SourceDic.ContainsKey(sourceId)) SourceDic[sourceId].Pause();
        }

        /// <summary>
        ///     播放一次
        /// </summary>
        public void PlayClip(int sourceId, int clipId)
        {
            if (SourceDic.ContainsKey(sourceId) && AudioClioDic.ContainsKey(clipId))
                SourceDic[sourceId].PlaySfx(AudioClioDic[clipId]);
        }

        /// <summary>
        ///     播放一次
        /// </summary>
        public void PlayClipAtPoint(int sourceId, int clipId)
        {
            if (SourceDic.ContainsKey(sourceId) && AudioClioDic.ContainsKey(clipId))
                AudioSource.PlayClipAtPoint(AudioClioDic[clipId], transform.position);
        }

        /// <summary>
        ///     循环播放
        /// </summary>
        public void PlayBgm(int sourceId, int clipId)
        {
            if (SourceDic.ContainsKey(sourceId) && AudioClioDic.ContainsKey(clipId))
                SourceDic[sourceId].PlaySound(AudioClioDic[clipId]);
        }

        /// <summary>
        ///     音频源初始化
        /// </summary>
        public void SourceInit()
        {
            for (var i = 0; i < 4; i++) gameObject.AddComponent<AudioSource>();
            var t = gameObject.GetComponents<AudioSource>();
            BackSource = t[0];
            SourceDic.Add(0, BackSource);
            SceneSource = t[1];
            SourceDic.Add(1, SceneSource);
            EffectSource = t[2];
            SourceDic.Add(2, EffectSource);
            UISource = t[3];
            SourceDic.Add(3, UISource);
        }

        /// <summary>
        ///     随机播放
        /// </summary>
        public void NextPlay(int sourceId, List<int> list)
        {
            if (SourceDic.ContainsKey(sourceId)) SourceDic[sourceId].PlaySfx(AudioClipArray[list.NextItem()]);
        }
    }
}