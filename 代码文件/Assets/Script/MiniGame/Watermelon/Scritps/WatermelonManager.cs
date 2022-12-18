using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using UnityEngine;
using Assets.Plugins.System;
using Assets.Script.Manager;
using Random = UnityEngine.Random;

namespace MiniGame
{
    public class WatermelonManager : MonoBehaviour
    {
        public static WatermelonManager instance; //静态的实例，可以直接在别的类中调用
        [Header("需要先把摄像机位置提前设置")] public Vector3 MainVector3;
        public float CameraSize;
        public GameObject[] FruitList;
        public GameObject BornFruitPosition;
        public Transform LeftWall;
        public Transform RightWall;
        public WatermelonGameState GameState = WatermelonGameState.Ready;
        public Transform FruitParent;
        public int currentID;
        private Camera mainCamara;
        private Vector3 QuitCamaraPos;
        private Quaternion QuitCamaraRat;
        private float _beforeCameraSize;
        private void Awake()
        {
            instance = this;
            mainCamara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PlayerManager.Instance.Player.isMiniGame)
            {
                CloseMiniGameObj();
            }
        }

        public void CloseMiniGameObj()
        {
            PlayerManager.Instance.Player.isMiniGame = false;
            
            //将摄像机返回之前位置嗯好角度
            mainCamara.gameObject.transform.position = QuitCamaraPos;
            mainCamara.gameObject.transform.rotation = QuitCamaraRat;
            mainCamara.GetComponent<Camera>().orthographicSize = _beforeCameraSize;
            gameObject.SetActive(false);
        }
        

        public void OpenMiniGameObj(int ID)
        {
            
            PlayerManager.Instance.Player.isMiniGame = true;
            gameObject.SetActive(true);
            currentID = ID;
            StartGame();
        }

        private void StartGame()
        {
            //记录之前摄像机位置角度
            QuitCamaraPos = mainCamara.transform.position;
            QuitCamaraRat = mainCamara.gameObject.transform.rotation;
            _beforeCameraSize = mainCamara.GetComponent<Camera>().orthographicSize;
            //将摄像机对准小游戏
            mainCamara.gameObject.transform.position = MainVector3;
            mainCamara.gameObject.transform.rotation = Quaternion.identity;
            
            Init();
            
            CreateFruit();
            GameState = WatermelonGameState.StanBy;
        }

        private void Init()
        {
            foreach (var o in FruitParent.GetComponentsInChildren<Fruit>())
            {
                Destroy(o.gameObject);
            }
        }

        public void InvoleCreateFruit(float invokeTime)
        {
            Invoke("CreateFruit", invokeTime);
        }

        public void CreateFruit()
        {
            int index = Random.Range(0, 4);
            if (FruitList.Length >= index && FruitList[index] != null)
            {
                GameObject fruitObj = FruitList[index];

                var CurrentFruit = Instantiate(fruitObj, BornFruitPosition.transform.position,
                    fruitObj.transform.rotation, FruitParent);
                CurrentFruit.GetComponent<Fruit>().FruitState = FruitState.StanBy;
            }
        }

        public void CobineNewFruit(FruitType currenFruitType, Vector3 currentPos, Vector3 collisinPos)
        {
            //合成成功，添加物品，切关闭界面
            if (currenFruitType == FruitType.Eight)
            {
                BagManager.Instance.AddItem(currentID);
                gameObject.SetActive(false);
            }

            int index = (int)currenFruitType;
            GameObject combineFruitObj = FruitList[index];
            GameObject combineFruit;

            if (collisinPos.y > currentPos.y)
            {
                combineFruit = Instantiate(combineFruitObj, currentPos, combineFruitObj.transform.rotation,
                    FruitParent);
            }
            else
            {
                combineFruit = Instantiate(combineFruitObj, collisinPos, combineFruitObj.transform.rotation,
                    FruitParent);
            }

            combineFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
            combineFruit.GetComponent<Fruit>().FruitState = FruitState.Collision;
        }
    }
}