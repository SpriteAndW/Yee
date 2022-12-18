using System.IO;
using RootLibrary;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class BuildAssetsPackage : UnityEditor.Editor
    {
        [MenuItem("基本工具/AB包加密")]
        public static void BuildAssetBundles()
        {
            var allAbs = BuildPipeline.BuildAssetBundles("./AssetsBundles", BuildAssetBundleOptions.None,
                BuildTarget.StandaloneWindows64);
            foreach (var abName in allAbs.GetAllAssetBundles())
            {
                var fileName = Path.Combine(Application.dataPath, "../AssetsBundles", abName);
                var fileData = File.ReadAllBytes(fileName);
                EncyptAssets.EncyptAssetData(fileData);
                var encyptFileName = Path.Combine(Application.dataPath, "../AssetsBundles", "encypt" + abName);
                File.WriteAllBytes(encyptFileName, fileData);
            }
        }
    }

    public class EncyptAssets
    {
        public static byte[] Mask =
        {
            (byte)MathV.Next(100, 200), (byte)MathV.Next(100, 200), (byte)MathV.Next(0, 100), (byte)MathV.Next(0, 100)
        };

        public static void EncyptAssetData(byte[] fileData)
        {
            var maskIndex = 0;
            for (var i = 0; i < fileData.Length; i++)
            {
                fileData[i] = (byte)(fileData[i] ^ Mask[maskIndex]);
                maskIndex++;
                maskIndex %= 4;
            }
        }
    }
}