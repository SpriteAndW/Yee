using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Manager
{
    public sealed class BookManager : ConfigActor<BookManager>
    {
        public BookDatas BookData;
        public GameObject Label;
        public float MoveValue = 0.5f;

        public Image NowImage;
        public TextMeshProUGUI NowIntroduction;
        public Text NowLabelName;

        public Scrollbar OneCatalogueScrollB;
        public GameObject SecondCatalogueContent;
        public Scrollbar TwoCatalogueScrollB;

        public override void OnStart()
        {
            //设置对象池获取ID数组
            for (var i = 0; i < 10; i++)
            {
                var obj = Instantiate(Label, SecondCatalogueContent.transform);
                obj.SetActive(false);
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 10, obj);
            }

            base.OnStart();
        }

        /// <summary>
        ///     生成二级标签页
        /// </summary>
        public void CreateLabels(int id)
        {
            ClearLabels();
            ClearContent();
            switch (id)
            {
                case 0:
                    {
                        foreach (var i in BookData.BookMapDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.MapID;
                            g.GetComponent<Text>().text = i.MapName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 1:
                    {
                        foreach (var i in BookData.BookCharmDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.CharmID;
                            g.GetComponent<Text>().text = i.CharmName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 2:
                    {
                        foreach (var i in BookData.BookZhenDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.ZhenID;
                            g.GetComponent<Text>().text = i.ZhenName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 3:
                    {
                        foreach (var i in BookData.BookMagicDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.MagicID;
                            g.GetComponent<Text>().text = i.MagicName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 4:
                    {
                        foreach (var i in BookData.BookThunderDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.ThunderID;
                            g.GetComponent<Text>().text = i.ThunderName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 5:
                    {
                        foreach (var i in BookData.BookScreenedDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.ScreenedID;
                            g.GetComponent<Text>().text = i.ScreenedName;
                            g.SetActive(true);
                        }

                        break;
                    }
                case 6:
                    {
                        foreach (var i in BookData.BookEnemyDatas)
                        {
                            var g = ObjectPoolManager.Instance.GetByPool(ObjectType.UI, 10);
                            g.name = i.EnemyID;
                            g.GetComponent<Text>().text = i.EnemyName;
                            g.SetActive(true);
                        }

                        break;
                    }
            }
        }

        public void OneCatalogueLastPage()
        {
            if (OneCatalogueScrollB.value <= 0) return;
            OneCatalogueScrollB.value -= MoveValue;
        }

        public void OneCatalogueNextPage()
        {
            if (OneCatalogueScrollB.value >= 1) return;
            OneCatalogueScrollB.value += MoveValue;
        }

        /// <summary>
        ///     更新内容
        /// </summary>
        public void UpdateContent(string gName)
        {
            var id = gName;
            string screenedName = null;
            string introduction = null;
            Sprite image = null;

            switch (id[0])
            {
                case 'C':
                    {
                        screenedName = BookData.GetCharmDetail(id).CharmName;
                        introduction = BookData.GetCharmDetail(id).CharmIntroduction;
                        image = BookData.GetCharmDetail(id).CharmImage;
                        break;
                    }
                case 'E':
                    {
                        screenedName = BookData.GetEnemyDetail(id).EnemyName;
                        introduction = BookData.GetEnemyDetail(id).EnemyIntroduction;
                        image = BookData.GetEnemyDetail(id).EnemyImage;
                        break;
                    }
                case 'K':
                    {
                        screenedName = BookData.GetMagicDetail(id).MagicName;
                        introduction = BookData.GetMagicDetail(id).MagicIntroduction;
                        image = BookData.GetMagicDetail(id).MagicImage;
                        break;
                    }
                case 'M':
                    {
                        screenedName = BookData.GetMapDetail(id).MapName;
                        //image = BookData.GetMapDetail(id).Ma;
                        break;
                    }
                case 'S':
                    {
                        screenedName = BookData.GetScreenedDetail(id).ScreenedName;
                        introduction = BookData.GetScreenedDetail(id).ScreenedIntroduction;
                        image = BookData.GetScreenedDetail(id).ScreenedImage;
                        break;
                    }
                case 'T':
                    {
                        screenedName = BookData.GetThunderDetail(id).ThunderName;
                        introduction = BookData.GetThunderDetail(id).ThunderIntroduction;
                        image = BookData.GetThunderDetail(id).ThunderImage;
                        break;
                    }
                case 'Z':
                    {
                        screenedName = BookData.GetZhenDetail(id).ZhenName;
                        introduction = BookData.GetZhenDetail(id).ZhenIntroduction;
                        image = BookData.GetZhenDetail(id).ZhenImage;
                        break;
                    }
            }

            NowLabelName.text = screenedName;
            NowIntroduction.text = introduction;
            NowImage.sprite = image;
        }

        /// <summary>
        ///     清除二级标签页
        /// </summary>
        public void ClearLabels()
        {
            if (SecondCatalogueContent.transform.childCount <= 0) return;
            for (var i = 0; i <= SecondCatalogueContent.transform.childCount - 1; i++)
                ObjectPoolManager.Instance.AddToPool(ObjectType.UI, 10,
                    SecondCatalogueContent.transform.GetChild(i).gameObject);
        }

        /// <summary>
        ///     清除内容
        /// </summary>
        public void ClearContent()
        {
            NowLabelName.text = null;
            NowIntroduction.text = null;
            NowImage.sprite = null;
        }
    }
}