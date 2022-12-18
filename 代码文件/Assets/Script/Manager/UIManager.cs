using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.UI;
using RootLibrary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Manager
{
    public sealed class UIManager : ConfigActor<UIManager>
    {
        public delegate void UpdateUI();

        [Header("句间隔")] public float NextTalkDeltaTime;
        [Header("背包格子")] public List<GameObject> Slots = new();
        [Header("对话UI")] public TextMeshProUGUI TalkUI;
        [Header("时间UI")] public TextMeshProUGUI TimeUI;
        [Header("字间隔")] public float TypeWriteDeltaTime;
        [Header("UI基类字典")] public Dictionary<int, UIBase> UIBaseDic = new();
        [Header("UI基类")] public List<UIBase> UIBases = new();
        [Header("格子")] public List<Text> UISlots = new();
        [Header("UI更新委托")] public UpdateUI UpdateUICallBack;

        private GameObject _nowUI;
        private GameObject _nowClickUI;

        private GameObject _nowRayUI;
        /// <summary>
        ///     翻页
        /// </summary>
        public void TurnPage(int t)
        {
            var str = UISlots.Select(t1 => t1.text).ToList();
            str.RotateMove(t);
            for (var i = 0; i < UISlots.Count; i++) UISlots[i].text = str[i];
        }

        /// <summary>
        ///     翻页
        /// </summary>
        public void TurnPages(GameObject[] pages, int t)
        {
            pages.RotateMove(t);
        }

        /// <summary>
        ///     打字机
        /// </summary>
        public IEnumerator TypeWriter(List<int> talkIds)
        {
            //获取对话Strings
            var str = talkIds.Select(t => DataManager.Instance.GetTalkById(t)).ToList();
            //当前字数
            var textCount = 0;
            //持续打字
            var keepWriting = true;
            //当前对话在Strings中的Id
            var idInStrings = 0;
            //当前对话内容
            var show = str[idInStrings];
            while (keepWriting) //当在打字
                switch (textCount - show.Length) //判断当前字数是否小于这句话的长度
                {
                    case < 0: //小于
                        textCount++; //下一个字
                        TalkUI.text = show[..textCount]; //逐字打印
                        yield return new WaitForSecondsRealtime(TypeWriteDeltaTime); //等待单个字间隔时间
                        break;
                    default: //等于（大于）
                        switch (idInStrings - (str.Count - 1)) //判断已打完的话数量是否小于所有话的数量
                        {
                            case < 0: //小于
                                yield return new WaitForSecondsRealtime(NextTalkDeltaTime); //等待单句话间隔时间
                                textCount = 0; //字数清零
                                idInStrings++; //Id++，下句话
                                TalkUI.text = string.Empty;
                                yield return null; //等待一帧
                                show = str[idInStrings]; //设置下句话的内容
                                break;
                            default: //等于（大于）
                                yield return new WaitForSecondsRealtime(NextTalkDeltaTime); //等待单句话间隔时间
                                yield return null; //等待一帧
                                textCount = 0; //字数清零
                                yield return null; //等待一帧
                                keepWriting = false; //停止打字
                                break;
                        }

                        break;
                }
        }

        /// <summary>
        ///     Start
        /// </summary>
        public override void OnStart()
        {
            base.OnStart();
            StartCoroutine(TypeWriter(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 }));
            UpdateUICallBack = null;
            if (TimeUI != null) UpdateUICallBack += UpdateTime;
        }

        /// <summary>
        ///     Update
        /// </summary>
        public override void OnUpdate()
        {
            base.OnUpdate();
            UpdateUICallBack?.Invoke();
        }

        /// <summary>
        ///     更新时间
        /// </summary>
        public void UpdateTime()
        {
            TimeUI.text = LibV.GetCurrentTime();
        }

        /// <summary>
        ///     显示UI
        /// </summary>
        public void ShowUI(int id)
        {
            if (UIBaseDic.ContainsKey(id)) UIBaseDic[id].Show();
        }

        /// <summary>
        ///     关闭UI
        /// </summary>
        public void CloseUI(int id)
        {
            if (!UIBaseDic.ContainsKey(id)) return;
            Destroy(UIBaseDic[id].gameObject);
            UIBaseDic.Remove(id);
        }

        /// <summary>
        ///     清除UI
        /// </summary>
        public void ClearAll()
        {
            UIBaseDic.Clear();
            UIBases.Clear();
        }

        /// <summary>
        ///     隐藏UI
        /// </summary>
        public void HideUI(int id)
        {
            if (UIBaseDic.ContainsKey(id)) UIBaseDic[id].Hide();
        }

        

        /// <summary>
        /// 设置当前UI
        /// </summary>
        public void SetNowUI(GameObject ui)
        {
            _nowUI = ui;
        }

        public void SetNowClickUI(GameObject ui)
        {
            _nowClickUI = ui;
        }


        public void SetNowRayName(GameObject ui)
        {
            _nowRayUI = ui;
        }


        public void Register(UIBase t)
        {
            if (t.In(Instance.UIBases)) return;
            t.Id = Instance.UIBases.Count;
            Instance.UIBases.Add(t);
            Instance.UIBaseDic.Add(t.Id, t);
            switch (t.Type)
            {
                case UIType.Button:
                    t.OnClick += t.SwitchActive;
                    break;
                case UIType.FuLu:
                    t.OnClick += Item_FuluOnClick;
                    t.OnEnter += ShowItemInfor;
                    t.OnExit += CloseItemInfor;
                    t.Drag += Item_FuluOnDrag;
                    t.DragBegin += Item_FuluDragBegin;
                    t.DragEnd += Item_FuluDragEnd;
                    break;
                case UIType.BlankFuLu:
                    t.OnClick += BlankFuLuOnClick;
                    t.OnEnter += ShowItemInfor;
                    t.OnExit += CloseItemInfor;
                    break;
                case UIType.HuaFaShui:
                    t.OnClick += HuaFaShuiOnClick;
                    break;
                case UIType.RanShao:
                    t.OnClick += RanShaoOnClick;
                    break;
                case UIType.NeiFu:
                    t.OnClick += NeiFuOnClick;
                    break;
                case UIType.DaoQi:
                    t.OnClick += Item_DaoQiOnClick;
                    t.OnEnter += ShowItemInfor;
                    t.OnExit += CloseItemInfor;
                    break;
                case UIType.Equip:

                    break;
                case UIType.Out:

                    break;
                case UIType.Skill:
                    t.OnClick += SkillOnClick;
                    t.OnEnter += ShowSkillInfor;
                    t.OnExit += CloseSkillInfor;
                    t.Drag += SkillDrag;
                    t.DragBegin += SkillDragBegin;
                    t.DragEnd += SkillDragEnd;
                    break;
                case UIType.BookOneCatalogue:
                    t.OnClick += BookOneCatalogueOnClick;
                    break;
                case UIType.BookLabel:
                    t.OnClick += BookLabelOnClick;
                    break;
                case UIType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region Bag

        public void ShowItemInfor()
        {
            int id = 1001;
            int.TryParse(_nowUI.name,out id);
            BagManager.Instance.ItemInfor.transform.parent.position = Input.mousePosition;
            BagManager.Instance.SetNowInfor(BagManager.Instance.FuluItemData.GetFuluDetail(id).name,
                BagManager.Instance.FuluItemData.GetFuluDetail(id).introduction);
            BagManager.Instance.ItemInfor.SetActive(true);

            BagManager.Instance.DaoQiButton.SetActive(false);
            BagManager.Instance.FuluButton.SetActive(false);
        }

        public void CloseItemInfor()
        {
            BagManager.Instance.ItemInfor.SetActive(false);
        }

        #endregion

        #region Item

        public void Item_FuluOnClick()
        {
            BagManager.Instance.FuluButton.SetActive(true);
        }

        public void Item_DaoQiOnClick()
        {

        }

        public void HuaFaShuiOnClick()
        {
            int id = 0;
            int.TryParse(_nowUI.name, out id);
            PlayerManager.Instance.ApplySymbol(id, SymbolType.RuneWater);
            MessageManager.Instance.ShowMessage("使用了化法水用法");
        }

        public void RanShaoOnClick()
        {
            int id = 0;
            int.TryParse(_nowUI.name, out id);
            PlayerManager.Instance.ApplySymbol(id, SymbolType.Burning);
            MessageManager.Instance.ShowMessage("使用了燃烧用法");
        }

        public void NeiFuOnClick()
        {
            int id = 0;
            int.TryParse(_nowUI.name, out id);
            PlayerManager.Instance.ApplySymbol(id, SymbolType.Swallow);
            MessageManager.Instance.ShowMessage("使用了内服用法");
        }

        public void BlankFuLuOnClick()
        {
            CreateFuLuManager.Instance.OpenCloseWindow();
        }

        public void Item_FuluOnDrag()
        {

        }

        public void Item_FuluDragBegin()
        {
        }

        public void Item_FuluDragEnd()
        {
            int id = 1001;
            int.TryParse(_nowUI.name, out id);
            switch (_nowRayUI.name)
            {
                case "WhiteUp":
                case "WhiteDown":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    //ShortCutKeyManager.Instance.SetItemDown(id);
                    break;
                case "WhiteLeft":
                case "WhiteRight":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    //ShortCutKeyManager.Instance.SetItemRight(id);
                    break;
                default:
                    break;

            }
            BagManager.Instance.FuluButton.SetActive(false);
        }


        #endregion

        #region Book
        public void BookOneCatalogueOnClick()
        {

        }

        public void BookLabelOnClick()
        {
            BookManager.Instance.UpdateContent(_nowClickUI.name);
        }
        #endregion

        #region Skill
        public void SkillOnClick()
        {

        }

        public void ShowSkillInfor()
        {
            int id = 1001;
            int.TryParse(_nowUI.name, out id);

            SkillBoxManager.Instance.SkillInfor.transform.parent.position = Input.mousePosition;
            SkillBoxManager.Instance.SetNowInfor(SkillBoxManager.Instance.SkillData.GetSkillData(id).name,
                SkillBoxManager.Instance.SkillData.GetSkillData(id).introduction);
            SkillBoxManager.Instance.SkillInfor.SetActive(true);
        }

        public void CloseSkillInfor()
        {
            SkillBoxManager.Instance.SkillInfor.SetActive(false);
        }

        public void SkillDrag()
        {

        }

        public void SkillDragBegin()
        {

        }

        public void SkillDragEnd()
        {
            int id = 1001;
            int.TryParse(_nowUI.name, out id);
            Debug.Log(_nowUI.name);
            switch (_nowRayUI.name)
            {
                case "BlackUp":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    ShortCutKeyManager.Instance.SetSkillUp(id);
                    break;
                case "BlackDown":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    ShortCutKeyManager.Instance.SetSkillDown(id);
                    break;
                case "BlackLeft":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    ShortCutKeyManager.Instance.SetSkillLeft(id);
                    break;
                case "BlackRight":
                    _nowRayUI.GetComponent<Image>().sprite = _nowUI.GetComponent<Image>().sprite;
                    ShortCutKeyManager.Instance.SetSkillRight(id);
                    break;
                default:
                    break;
            }
        }


        #endregion
    }
}