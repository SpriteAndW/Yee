using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Script.Manager
{
    public sealed class MessageManager : ConfigActor<MessageManager>
    {
        public TextMeshProUGUI mesText;
        public Image img;
        public Image item;


        private Canvas _canvas;
        public override void OnStart()
        {
            _canvas = GetComponent<Canvas>();
            base.OnStart();
        }

        public void ShowMessage(string text)
        {
            img.color = new Vector4(1, 1,1, 1);
            mesText.color = new Vector4(0,0,0,1);

            _canvas.enabled = true;
            mesText.text = text;

            img.color = Color.white;
            mesText.color = Color.black;
            StartCoroutine(Fade(true));
        }
        public void ShowMessage(string text, Sprite itemImg)
        {
            img.color = new Vector4(1, 1, 1, 1);
            mesText.color = new Vector4(0, 0, 0, 1);
            item.color = new Vector4(0,0,0,1);
            _canvas.enabled = true;
            mesText.text = text;
            img.sprite = itemImg;
            img.color = Color.white;
            item.color = Color.white;
            mesText.color = Color.black;
            StartCoroutine(Fade(true));
        }

        public IEnumerator Fade(bool isImg)
        {
            while (img.color.a > 0)
            {
                float a = img.color.a;
                if (isImg)
                {
                    item.color = new Vector4(0, 0, 0, a - 0.005f);
                }
                img.color = new Vector4(1 , 1, 1, a-0.005f);
                mesText.color = new Vector4(0, 0, 0, a - 0.005f);
                yield return null;
            }
            _canvas.enabled = false;
        }


    }
}
