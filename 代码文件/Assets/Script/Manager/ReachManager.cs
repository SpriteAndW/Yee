using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Script.Manager
{
    public class ReachManager : ConfigActor<ReachManager>
    {
        public Text Next;
        public Canvas ReachCanvas;
        public Transform Player;
        public Transform LevelTwo;
        private int num = 3;
        public int level = 1;
        public void JudgeNum()
        {
            num--;
            if (num == 0)
            {
                ReachCanvas.enabled = true;
                if (level == 2) Next.text = "退出";
            }
        }

        public void Over()
        {
            if (level == 1)
            {
                num = 3;
                level = 2;
                ReachCanvas.enabled = false;
                Player = LevelTwo;
            }
            else if (level == 2) SceneManager.LoadScene(0);
        }

        public void Exit()
        {
            SceneManager.LoadScene(0);
        }
    }
}