using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using UnityEngine;
using UnityEngine.UI;
using MiniGame;

namespace Assets.Script.Manager
{
    public class CreateFuLuManager : ConfigActor<CreateFuLuManager>
    {
        public GameObject FuLuOne;
        public GameObject FuLuTwo;
        public GameObject FuLuThree;
        public GameObject FuLuFour;

        public GameObject HuanZhuOne;
        public GameObject HuanZhuTwo;
        public GameObject HuanZhuThree;

        public GameObject WaterMelon;
        public PaintView paintView;
        private int _nowId;
        private int _nowHuanZhuID;

        public void OpenCloseWindow()
        {
            GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
        }

        private GameObject _nowButton;
        public void ChangeID(GameObject button)
        {
            //if (_nowButton != null) _nowButton.GetComponent<Button>().;
            int.TryParse(button.name,out _nowId);
            button.GetComponent<Button>().Select();

            //_nowButton=button;
        }

        public void ChangeHuanZhuID(GameObject button)
        {
            //if (_nowButton != null) _nowButton.GetComponent<Button>().;
            int.TryParse(button.name, out _nowHuanZhuID);
            button.GetComponent<Button>().Select();

            //_nowButton=button;
        }

        public void StartPaint()
        {
            paintView.OpenFuluComparePanle(_nowId);
        }

        public void StartCreate()
        {
            MessageManager.Instance.ShowMessage("按ESC退出键退出当前小游戏");
            WaterMelon.GetComponent<WatermelonManager>().OpenMiniGameObj(_nowHuanZhuID);
        }



    }
}
