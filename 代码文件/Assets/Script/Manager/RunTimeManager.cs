using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class RunTimeManager : ConfigActor<RunTimeManager>
    {
        public void Save()
        {
            MessageManager.Instance.ShowMessage("保存成功");
            SaveManager.Instance.Save(0);
        }

        public void Load()
        {
            MessageManager.Instance.ShowMessage("读取成功");
            SaveManager.Instance.Load(0);
        }

        public void Start()
        {
            RunTimeSystem.Instance.RunTimeOnStart();
        }

        public void Update()
        {
            RunTimeSystem.Instance.RunTimeOnUpdate();
        }

        public void FixedUpdate()
        {
            RunTimeSystem.Instance.RunTimeOnFixedUpdate();
            TimeLineV.RunDeltaTimer();
        }

        public void LateUpdate()
        {
            RunTimeSystem.Instance.RunTimeOnLateUpdate();
        }
    }
}