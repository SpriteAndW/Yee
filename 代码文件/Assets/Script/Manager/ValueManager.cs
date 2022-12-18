using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Manager
{
    public class ValueManager : ConfigActor<ValueManager>
    {
        public Transform ValueContent;
        public GameObject NumGO;

        public override void OnStart()
        {
            for(var i=0;i<30;i++)
            {
                var obj = Instantiate(NumGO,ValueContent);
                obj.SetActive(false);
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI,9,obj);
            }
            base.OnStart();
        }

        /*public IEnumerator Fade()
        {
            //NumGO.GetComponent<>
            *//*
            while (img.color.a > 0)
            {
                float a = img.color.a;
                if (isImg)
                {
                    item.color = new Vector4(0, 0, 0, a - 0.005f);
                }
                img.color = new Vector4(0, 0, 0, a - 0.005f);
                mesText.color = new Vector4(0, 0, 0, a - 0.005f);
                yield return null;
            }
            _canvas.enabled = false;*//*
        }*/


    }
}
