using RootLibrary;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PaintView : MonoBehaviour
{
    public FuluItemData_SO FuluItemData;
    private int currentFuluID;
    public int compareNum;
    public Texture2D target;
    public GameObject RedPen;
    public Text CompareRateText;


    #region 属性

    //绘图shader&material
    [SerializeField] private Shader _paintBrushShader;

    private Material _paintBrushMat;

    //清理renderTexture的shader&material
    [SerializeField] private Shader _clearBrushShader;

    private Material _clearBrushMat;

    //默认笔刷RawImage
    [SerializeField] private RawImage _defaultBrushRawImage;

    //默认笔刷&笔刷合集
    [SerializeField] private Texture _defaultBrushTex;

    //renderTexture
    private RenderTexture _renderTex;

    //默认笔刷RawImage
    [SerializeField] private Image _defaultColorImage;

    //绘画的画布
    [SerializeField] private RawImage _paintCanvas;

    [SerializeField] private RawImage _targetBG;

    //笔刷的默认颜色&颜色合集
    [SerializeField] private Color _defaultColor;

    //笔刷大小的slider
    private Text _brushSizeText;

    //笔刷的大小
    private float _brushSize;

    //屏幕的宽高
    private int _screenWidth;

    private int _screenHeight;

    //笔刷的间隔大小
    private float _brushLerpSize;

    //默认上一次点的位置
    private Vector2 _lastPoint;

    #endregion

    void Start()
    {
        InitData();
    }

    private void Update()
    {
        Color clearColor = new Color(0, 0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
            _paintBrushMat.SetColor("_Color", clearColor);

        if (Input.GetKeyDown(KeyCode.A))
        {
            OpenFuluComparePanle(1001);
        }
    }

    /// <summary>
    ///     根据符箓ID打开对应的符箓背景和对比符箓
    /// </summary>
    /// <param name="fuliID">符箓ID</param>
    public void OpenFuluComparePanle(int fuluID)
    {
        if (fuluID != 0)
        {
            _renderTex = RenderTexture.GetTemporary(Screen.width, Screen.height, 24);
            _paintCanvas.texture = _renderTex;
            
            InitData();

            transform.GetChild(0).gameObject.SetActive(true);
            currentFuluID = fuluID;
            var fuluDetail = FuluItemData.GetFuluDetail(fuluID);

            target = fuluDetail.targetFulu;
            _targetBG.texture = fuluDetail.targetFuluBG;
        }
    }

    public void ClearFUluPanleBtn()
    {
        OpenFuluComparePanle(currentFuluID);
    }



    /// <summary>
    ///     按钮按下对比,相似度大于80%关闭面板，添加符箓到背包
    /// </summary>
    public void GetCompareRate()
    {
        var curTexture = TextureToTexture2D((_paintCanvas.texture));
        float temp = CompareTexture2D(curTexture, target);

        CompareRateText.text = (int)(temp * 100) + "%";

        //符箓对比后超过80%，完成画符，关闭面板和添加符箓到背包
        if (temp > 0.8f)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            BagManager.Instance.AddItem(currentFuluID);
            BagManager.Instance.RemoveItem(0);
        }
        else
            MessageManager.Instance.ShowMessage("需要80%以上才可成功");
    }


    private float CompareTexture2D(Texture2D cur, Texture2D tar)
    {
        compareNum = 0;
        Color[] curPix = cur.GetPixels(0, 0, _screenWidth, _screenHeight);
        Color[] tarPis = tar.GetPixels(0, 0, _screenWidth, _screenHeight);

        int a = 0;
        for (int i = 0; i < curPix.Length; i++)
        {
            if (curPix[i] == Color.black && tarPis[i] == Color.black ||
                tarPis[i] == Color.clear && curPix[i] == Color.clear)
            {
                continue;
            }
            else
            {
                a++;
            }

            if (Difference(curPix[i], tarPis[i]) < 0.45f)
            {
                // Debug.Log(Difference(curPix[i], tarPis[i]));
                compareNum++;
            }
            else if (Difference(curPix[i], tarPis[i]) > 0.7)
            {
                compareNum--;
            }
        }

        return Mathf.Max(0, (float)compareNum / a);
    }

    /// <summary>
    /// 将Texture类型转换问Texture2D类型
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    private Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);

        return texture2D;
    }


    /// <summary>
    /// 根据颜色判断相似度
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    /// <returns>返回值越低相似度越高</returns>
    public static float Difference(Color c1, Color c2)
    {
        c1 *= 255;
        c2 *= 255;
        var averageR = (c1.r + c2.r) * 0.5f;

        return Mathf.Sqrt((2 + averageR / 255f) * Mathf.Pow(c1.r - c2.r, 2) + 4 * Mathf.Pow(c1.g - c2.g, 2) +
                          (2 + (255 - averageR) / 255f) * Mathf.Pow(c1.b - c2.b, 2)) / (3 * 255f);
    }


    #region 外部接口

    public void SetBrushSize(float size)
    {
        _brushSize = size;
        _paintBrushMat.SetFloat("_Size", _brushSize);
    }

    // public void SetBrushTexture(Texture texture)
    // {
    //     _defaultBrushTex = texture;
    //     _paintBrushMat.SetTexture("_BrushTex", _defaultBrushTex);
    //     _defaultBrushRawImage.texture = _defaultBrushTex;
    // }
    //
    // public void SetBrushColor(Color color)
    // {
    //     _defaultColor = color;
    //     _paintBrushMat.SetColor("_Color", _defaultColor);
    //     _defaultColorImage.color = _defaultColor;
    // }

    // /// <summary>
    // /// 选择颜色
    // /// </summary>
    // /// <param name="image"></param>
    // public void SelectColor(Image image)
    // {
    //     SetBrushColor(image.color);
    // }

    // /// <summary>
    // /// 选择笔刷
    // /// </summary>
    // /// <param name="rawImage"></param>
    // public void SelectBrush(RawImage rawImage)
    // {
    //     SetBrushTexture(rawImage.texture);
    // }

    /// <summary>
    /// 设置笔刷大小
    /// </summary>
    /// <param name="value"></param>
    public void BrushSizeChanged(Slider slider)
    {
        //  float value = slider.maxValue + slider.minValue - slider.value;
        SetBrushSize(Remap(slider.value, 300.0f, 30.0f));
        if (_brushSizeText == null)
        {
            _brushSizeText = slider.transform.Find("Background/Text").GetComponent<Text>();
        }

        _brushSizeText.text = slider.value.ToString("f2");
    }

    /// <summary>
    /// 拖拽
    /// </summary>
    public void DragUpdate()
    {
        if (_renderTex && _paintBrushMat)
        {
            if (Input.GetMouseButton(0))
            {
                LerpPaint(Input.mousePosition);

                //画笔坐标跟随鼠标坐标
                RedPen.SetActive(true);
                RedPen.transform.position = Input.mousePosition;
            }
        }
    }

    /// <summary>
    /// 拖拽结束
    /// </summary>
    public void DragEnd()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _lastPoint = Vector2.zero;

            RedPen.SetActive(false);
        }
    }

    #endregion

    #region 内部函数

    //初始化数据
    void InitData()
    {
        _brushSize = 300.0f;
        _brushLerpSize = (_defaultBrushTex.width + _defaultBrushTex.height) / 2.0f / _brushSize;
        _lastPoint = Vector2.zero;

        if (_paintBrushMat == null)
        {
            UpdateBrushMaterial();
        }

        if (_clearBrushMat == null)
            _clearBrushMat = new Material(_clearBrushShader);
        if (_renderTex == null)
        {
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;

            _renderTex = RenderTexture.GetTemporary(_screenWidth, _screenHeight, 24);
            _paintCanvas.texture = _renderTex;
        }

        Graphics.Blit(null, _renderTex, _clearBrushMat);
    }

    //更新笔刷材质
    private void UpdateBrushMaterial()
    {
        _paintBrushMat = new Material(_paintBrushShader);
        _paintBrushMat.SetTexture("_BrushTex", _defaultBrushTex);
        _paintBrushMat.SetColor("_Color", _defaultColor);
        _paintBrushMat.SetFloat("_Size", _brushSize);
    }

    //插点
    private void LerpPaint(Vector2 point)
    {
        Paint(point);

        if (_lastPoint == Vector2.zero)
        {
            _lastPoint = point;
            return;
        }

        float dis = Vector2.Distance(point, _lastPoint);
        if (dis > _brushLerpSize)
        {
            Vector2 dir = (point - _lastPoint).normalized;
            int num = (int)(dis / _brushLerpSize);
            for (int i = 0; i < num; i++)
            {
                Vector2 newPoint = _lastPoint + dir * (i + 1) * _brushLerpSize;
                Paint(newPoint);
            }
        }

        _lastPoint = point;
    }

    //画点
    private void Paint(Vector2 point)
    {
        if (point.x < 0 || point.x > _screenWidth || point.y < 0 || point.y > _screenHeight)
            return;

        Vector2 uv = new Vector2(point.x / (float)_screenWidth,
            point.y / (float)_screenHeight);
        _paintBrushMat.SetVector("_UV", uv);
        Graphics.Blit(_renderTex, _renderTex, _paintBrushMat);
    }

    /// <summary>
    /// 重映射  默认  value 为1-100
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    private float Remap(float value, float startValue, float enValue)
    {
        float returnValue = (value - 1.0f) / (100.0f - 1.0f);
        returnValue = (enValue - startValue) * returnValue + startValue;
        return returnValue;
    }

    #endregion
}