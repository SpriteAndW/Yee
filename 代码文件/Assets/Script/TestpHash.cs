using System.Collections;
using System.Collections.Generic;
using RootLibrary;
using UnityEngine;

public class TestpHash : MonoBehaviour
{
    public Texture2D a;
    public Texture2D[] b;
    public List<float> c = new();
    public Texture2D output;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            c.Clear();
            for (int i = 0; i < b.Length; i++)
            {
                c.Add(PHash.PicSimilarity(a, b[i]));
            }
            float maxf = MathV.Max(c);
            int id = maxf.GetId(c);
            output = b[id];
        }
    }
}