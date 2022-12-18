using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class AssetPackage : ScriptableObject
    {
        public string[] DependenciesId = Array.Empty<string>();
        public string[] OutputPath = Array.Empty<string>();
        public string PackageName = "Package";

        public string[] Dependencies
        {
            get
            {
                var dep = new string[DependenciesId.Length];
                for (var i = 0; i < dep.Length; ++i)
                    dep[i] = AssetDatabase.GUIDToAssetPath(DependenciesId[i]);
                return dep;
            }
        }
    }
}