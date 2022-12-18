using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Editor
{
    public class FindMissingScripts : EditorWindow
    {
        public List<GameObject> ObjectWithMissingScripts;
        public Vector2 ScrollPosition;

        public void OnEnable()
        {
            ObjectWithMissingScripts = new List<GameObject>();
            ScrollPosition = Vector2.zero;
        }

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("在资源里查找"))
                FindInAssets();
            if (GUILayout.Button("在当前场景中查找"))
                FindInScenes();
            EditorGUILayout.EndHorizontal();
            ScrollPosition = EditorGUILayout.BeginScrollView(ScrollPosition);
            foreach (var t in ObjectWithMissingScripts.Where(t => GUILayout.Button(t.name)))
                EditorGUIUtility.PingObject(t);
            EditorGUILayout.EndScrollView();
        }

        [MenuItem("基本工具/查找缺失脚本的物体")]
        public static void FindMissing()
        {
            GetWindow<FindMissingScripts>();
        }

        public void FindInAssets()
        {
            var assetGuiDs = AssetDatabase.FindAssets("t:GameObject");
            ObjectWithMissingScripts.Clear();
            Debug.Log("测试 " + assetGuiDs.Length + " 个物体在资源里");
            foreach (var assetGuiD in assetGuiDs)
            {
                var obj = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(assetGuiD));
                RecursiveDepthSearch(obj);
            }
        }

        public void RecursiveDepthSearch(GameObject root)
        {
            var components = root.GetComponents<Component>();
            foreach (var c in components)
                if (c == null)
                    if (!ObjectWithMissingScripts.Contains(root))
                        ObjectWithMissingScripts.Add(root);
            foreach (Transform t in root.transform) RecursiveDepthSearch(t.gameObject);
        }

        public void FindInScenes()
        {
            ObjectWithMissingScripts.Clear();

            for (var i = 0; i < SceneManager.sceneCount; ++i)
            {
                var rootGOs = SceneManager.GetSceneAt(i).GetRootGameObjects();
                Debug.Log("测试 " + rootGOs.Length + " 个物体在当前场景 " + i);
                foreach (var obj in rootGOs) RecursiveDepthSearch(obj);
            }
        }
    }
}