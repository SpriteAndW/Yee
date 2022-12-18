using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using RootLibrary;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script.UI
{
    public class UIBase : Actor, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public delegate void PointerHandler();

        public Canvas Canvas;
        public int Id;
        public PointerHandler OnClick;
        public PointerHandler OnEnter;
        public PointerHandler OnExit;
        public PointerHandler Drag;
        public PointerHandler DragBegin;
        public PointerHandler DragEnd;
        public RectTransform Rect;
        public UIType Type;
        private Vector2 beforePos;
        public void OnStart()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            AudioManager.Instance.PlayByName(0, "1打开罗盘");
            UIManager.Instance.SetNowClickUI(gameObject);
            OnClick?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.Instance.SetNowUI(gameObject);
            OnEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnExit?.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Type != UIType.Skill) return;
            beforePos = transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            DragBegin?.Invoke();
        }
        public void OnDrag(PointerEventData eventData)
        {

            if (Type != UIType.Skill) return;
            UIManager.Instance.SetNowUI(gameObject);
            UIManager.Instance.SetNowRayName(eventData.pointerCurrentRaycast.gameObject);
            if (Input.GetMouseButton(0))
            {
                transform.position = eventData.position;
            }
            Drag?.Invoke();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Type != UIType.Skill) return;
            UIManager.Instance.SetNowRayName(eventData.pointerCurrentRaycast.gameObject);
            transform.position = beforePos;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            DragEnd?.Invoke();
        }



        /// <summary>
        ///     切换Active
        /// </summary>
        public void SwitchActive()
        {
            Canvas.SwitchEnabled();
        }

        public void Start()
        {
            Register();
            Rect = GetComponent<RectTransform>();
        }

        public void Register()
        {
            UIManager.Instance.Register(this);
        }

    }
}