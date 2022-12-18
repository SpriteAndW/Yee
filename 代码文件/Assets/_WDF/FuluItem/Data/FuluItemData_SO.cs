using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuluItemData_SO", menuName = "Fulu/FuluItemData_SO")]
public class FuluItemData_SO : ScriptableObject
{
    public List<FuluDetail> FuluList;


    /// <summary>
    /// 根据ID获取详细信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public FuluDetail GetFuluDetail(int id)
    {
        return FuluList.Find(i => i.ID == id);
    }
}

[System.Serializable]
public struct FuluDetail
{
    public int ID;
    public Sprite image;
    public string name;
    public string introduction;
    public int durability;

    [Header("目标符箓")] public Texture2D targetFulu;
    [Header("镂空符箓背景")] public Texture targetFuluBG;
}