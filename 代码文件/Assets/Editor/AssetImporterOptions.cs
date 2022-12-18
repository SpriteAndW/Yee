using System;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Editor
{
    [CreateAssetMenu(fileName = "AssetImporterOptions", menuName = "Asset Importer Option")]
    public class AssetImporterOptions : ScriptableObject
    {
        public ImportOption[] ImportOptions;

        [Serializable]
        public class ImportOption
        {
            public string NameFilter;
            public Preset Preset;
            public bool PresetEnabled;
        }
    }


    [CustomEditor(typeof(AssetImporterOptions))]
    public class AssetImporterOptionsEditor : UnityEditor.Editor
    {
        public ModelImporter DefaultMeshImporter;
        public TextureImporter DefaultTextureImport;
        public bool[] MInspectorsFade;
        public AssetImporterOptions Opts;
        public GenericMenu ImporterMenu = new();

        public void OnEnable()
        {
            Opts = target as AssetImporterOptions;
            if (Opts != null && Opts.ImportOptions != null)
            {
                MInspectorsFade = new bool[Opts.ImportOptions.Length];
                for (var i = 0; i < Opts.ImportOptions.Length; ++i) MInspectorsFade[i] = false;
            }

            var meshasset = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("__importermeshdummy__")[0]);
            var textureasset = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("__importertexturedummy__")[0]);
            DefaultMeshImporter = AssetImporter.GetAtPath(meshasset) as ModelImporter;
            DefaultTextureImport = AssetImporter.GetAtPath(textureasset) as TextureImporter;
            ImporterMenu.AddItem(new GUIContent("Texture"), false, AddNewTypeofPreset, DefaultTextureImport);
            ImporterMenu.AddItem(new GUIContent("Mesh"), false, AddNewTypeofPreset, DefaultMeshImporter);
        }

        public void AddNewPreset(Preset p)
        {
            var option = new AssetImporterOptions.ImportOption
            {
                NameFilter = "",
                PresetEnabled = true,
                Preset = p
            };
            if (Opts.ImportOptions == null)
            {
                Opts.ImportOptions = Array.Empty<AssetImporterOptions.ImportOption>();
                MInspectorsFade = Array.Empty<bool>();
            }

            ArrayUtility.Add(ref Opts.ImportOptions, option);
            ArrayUtility.Add(ref MInspectorsFade, false);
            AssetDatabase.AddObjectToAsset(p, Opts);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(p));
            AssetDatabase.Refresh();
        }

        public void AddNewTypeofPreset(object obj)
        {
            var unityObj = obj as Object;
            var newPreset = new Preset(unityObj);
            AddNewPreset(newPreset);
            EditorUtility.SetDirty(Opts);
        }

        public void RemovePreset(int index)
        {
            var opt = Opts.ImportOptions[index];
            ArrayUtility.RemoveAt(ref Opts.ImportOptions, index);
            ArrayUtility.RemoveAt(ref MInspectorsFade, index);
            var assetpath = AssetDatabase.GetAssetPath(opt.Preset);
            DestroyImmediate(opt.Preset, true);
            AssetDatabase.ImportAsset(assetpath);
            AssetDatabase.Refresh();
        }

        public override void OnInspectorGUI()
        {
            if (EditorGUILayout.DropdownButton(new GUIContent("New Preset"), FocusType.Passive, GUILayout.Width(100)))
                ImporterMenu.ShowAsContext();
            if (Opts.ImportOptions == null) return;
            UnityEditor.Editor ed = null;
            for (var i = 0; i < Opts.ImportOptions.Length; ++i)
            {
                var deletionHappened = false;
                EditorGUILayout.BeginHorizontal();
                MInspectorsFade[i] = EditorGUILayout.Foldout(MInspectorsFade[i],
                    "Preset : " + Opts.ImportOptions[i].Preset.GetTargetTypeName() + " on " +
                    Opts.ImportOptions[i].NameFilter);
                if (GUILayout.Button("Delete", GUILayout.Width(100)))
                    if (EditorUtility.DisplayDialog("Confirm", "Are you sure you want to delete that preset rule?",
                            "Delete", "Cancel"))
                    {
                        RemovePreset(i);
                        i--;
                        deletionHappened = true;
                    }

                EditorGUILayout.EndHorizontal();
                EditorGUI.BeginChangeCheck();
                if (!deletionHappened && MInspectorsFade[i])
                {
                    Opts.ImportOptions[i].NameFilter =
                        EditorGUILayout.TextField("Filter", Opts.ImportOptions[i].NameFilter);
                    Opts.ImportOptions[i].PresetEnabled = EditorGUILayout.Toggle("Preset is enabled",
                        Opts.ImportOptions[i].PresetEnabled);
                    EditorGUILayout.BeginVertical("box");
                    CreateCachedEditor(Opts.ImportOptions[i].Preset,
                        Type.GetType("UnityEditor.Presets.PresetEditor, UnityEditor"), ref ed);
                    ed.OnInspectorGUI();
                    EditorGUILayout.EndVertical();
                }

                if (EditorGUI.EndChangeCheck())
                    EditorUtility.SetDirty(Opts);
                EditorGUILayout.EndFadeGroup();
            }

            if (ed != null) DestroyImmediate(ed);
        }
    }
}