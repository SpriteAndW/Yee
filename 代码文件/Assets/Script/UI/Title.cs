using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Script.Manager;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Assets.Script.UI
{
    public class Title : ConfigActor<Title>
    {
        protected override void Awake()
        {
            EnterAnim();
            base.Awake();
        }

        public void Update()
        {
            
        }

        public void EnterAnim()
        {
            transform.Find("Title").GetComponent<Image>().DOFade(1, 0.5f);
            transform.Find("TitleBG").GetComponent<Image>().DOFade(0.9f, 1);
            transform.Find("TitleBG").DOMoveY(900,15);
            transform.Find("Menu").Find("Start").DOScale(new Vector3(1,1),1);
            transform.Find("Menu").Find("Start").GetComponent<Image>().DOFade(1,1);
            transform.Find("Menu").Find("Load").DOScale(new Vector3(1, 1), 1);
            transform.Find("Menu").Find("Load").GetComponent<Image>().DOFade(1, 1);
            transform.Find("Menu").Find("Exit").DOScale(new Vector3(1, 1), 1);
            transform.Find("Menu").Find("Exit").GetComponent<Image>().DOFade(1, 1);
            transform.Find("Directional Light").DORotate(new Vector3(100,360),15);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadGame()
        {
            RunTimeManager.Instance.Load();
        }

        public void Exit()
        {
            Application.Quit();
        }

    }

}
