using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class DefaultAssetProcessor : AssetPostprocessor
    {
        public void OnPreprocessModel()
        {
            var importer = assetImporter as ModelImporter;
            var importerOptions = AssetDatabase.FindAssets("t:AssetImporterOptions");
            if (importerOptions.Length == 0)
                return;
            var opts = AssetDatabase.LoadAssetAtPath<AssetImporterOptions>(
                AssetDatabase.GUIDToAssetPath(importerOptions[0]));
            foreach (var t in opts.ImportOptions)
                if (t.PresetEnabled && t.Preset.CanBeAppliedTo(importer) &&
                    Regex.Match(Path.GetFileName(assetPath), WildcardToRegex(t.NameFilter)).Success)
                    t.Preset.ApplyTo(importer);
        }

        public void OnPreprocessTexture()
        {
            var importer = assetImporter as TextureImporter;
            if (File.Exists(AssetDatabase.GetTextMetaFilePathFromAssetPath(importer.assetPath)))
                return;
            Debug.Log("新导入");
            var importerOptions = AssetDatabase.FindAssets("t:AssetImporterOptions");
            if (importerOptions.Length == 0)
                return;
            var opts = AssetDatabase.LoadAssetAtPath<AssetImporterOptions>(
                AssetDatabase.GUIDToAssetPath(importerOptions[0]));
            foreach (var t in opts.ImportOptions)
            {
                Debug.Log(Regex.Match(Path.GetFileName(assetPath) ?? string.Empty, WildcardToRegex(t.NameFilter))
                    .Success);
                if (!t.PresetEnabled || !t.Preset.CanBeAppliedTo(importer) ||
                    !Regex.Match(Path.GetFileName(assetPath) ?? string.Empty, WildcardToRegex(t.NameFilter))
                        .Success) continue;
                var obj = new SerializedObject(importer);
                var widthProp = obj.FindProperty("m_Output.sourceTextureInformation.width");
                var heightProp = obj.FindProperty("m_Output.sourceTextureInformation.height");
                var prevW = widthProp.intValue;
                var prevH = heightProp.intValue;
                t.Preset.ApplyTo(importer);
                obj.Update();
                widthProp.intValue = prevW;
                heightProp.intValue = prevH;
                obj.ApplyModifiedProperties();
            }
        }

        public static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern)
                           .Replace(@"\*", ".*")
                           .Replace(@"\?", ".")
                       + "$";
        }
    }
}