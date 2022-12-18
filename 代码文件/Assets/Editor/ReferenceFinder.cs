using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using RootLibrary;
using Unity.VisualScripting.YamlDotNet.RepresentationModel;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class ReferenceFinder : EditorWindow
    {
        private const string GameObjectIdString = "m_GameObject: {fileID: ";
        private const string GameObjectNameString = "m_Name: ";
        private const string GameObjectParentString = "m_Father: {fileID: ";
        private int _currentParseFile;
        private List<string> _filesList = new();

        private Vector2 _scrollViewPosition;
        private string _searchedFunction;
        private string _searchResult = "";

        private string _tempSearchResult = "";

        private Type _typeSearched;

        private string _valueToSearch = "";

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            _searchedFunction = EditorGUILayout.TextField(_searchedFunction);
            if (GUILayout.Button("Search", GUILayout.Width(50))) Search();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginScrollView(_scrollViewPosition);
            GUILayout.Label(_searchResult);
            EditorGUILayout.EndScrollView();
        }

        [MenuItem("基本工具/找到函数引用")]
        public static void OpenWindow()
        {
            GetWindow<ReferenceFinder>();
        }

        public void OnUpdate()
        {
            if (_filesList.Count > _currentParseFile)
            {
                var purcentage = MathV.FloorToInt(_currentParseFile / (float)_filesList.Count * 100.0f);
                _searchResult = "Searching " + purcentage + "%";


                NewHandleFile(_filesList[_currentParseFile]);

                _currentParseFile += 1;

                if (_currentParseFile == _filesList.Count)

                    _searchResult = _tempSearchResult;
            }

            Repaint();
        }

        private void Search()
        {
            _searchResult = "";
            _tempSearchResult = "";
            _scrollViewPosition = Vector2.zero;

            var pointPosition = _searchedFunction.LastIndexOf('.');

            if (pointPosition < 0)
            {
                _searchResult = "Malformed search query";
                return;
            }

            var objectPath = _searchedFunction[..pointPosition];
            var functionName = _searchedFunction[(pointPosition + 1)..];

            var types = FindType(objectPath);

            var enumerable = types as Type[] ?? types.ToArray();
            switch (enumerable.Count())
            {
                case > 1:
                {
                    _searchResult = "Ambiguous object name, could be : \n";
                    foreach (var t in enumerable)
                        _searchResult += "\t" + t.FullName + "\n";
                    return;
                }
                case 0:
                    _searchResult = "Could not find object " + objectPath;
                    return;
            }

            var type = enumerable.First();

            var func = type.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public,
                (info, obj) => info.Name == (string)obj, functionName);

            if (func.Length == 0)
            {
                _searchResult = $"Couldn't find function {functionName} in object {objectPath}";
                return;
            }

            if (func[0].MemberType == MemberTypes.Property)
            {
                var info = func[0] as PropertyInfo;

                if (info != null) _valueToSearch = info.GetSetMethod().Name;
            }
            else
            {
                _valueToSearch = func[0].Name;
            }

            _typeSearched = type;
            _filesList = new List<string>();
            _filesList.AddRange(Directory.GetFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories));
            _filesList.AddRange(Directory.GetFiles(Application.dataPath, "*.prefab", SearchOption.AllDirectories));

            _currentParseFile = 0;
        }

        private void NewHandleFile(string file)
        {
            var filenameWrote = false;

            var fileContent = File.ReadAllText(file);
            fileContent = fileContent.Replace("stripped", "");
            var input = new StringReader(fileContent);

            var yaml = new YamlStream();
            yaml.Load(input);

            var visitor = new YamlVisitorEvent
            {
                ReferenceFinder = this
            };

            var gameobjectToIdToCheck = new Dictionary<string, HashSet<string>>();

            var parsedNodes = new Dictionary<string, YamlMappingNode>();

            foreach (var doc in yaml.Documents)
            {
                var root = (YamlMappingNode)doc.RootNode;

                parsedNodes[root.Anchor] = root;

                foreach (var node in root.Children)
                {
                    var scalarNode = (YamlScalarNode)node.Key;
                    if (scalarNode.Value != "MonoBehaviour") continue;
                    var sequenceNode = node.Value as YamlMappingNode;

                    visitor.HavePersistentCall = false;
                    visitor.IdToCheck.Clear();
                    sequenceNode?.Accept(visitor);

                    if (!visitor.HavePersistentCall) continue;
                    var gameobjectId = ((YamlScalarNode)node.Value["m_GameObject"]["fileID"]).Value;

                    if (!gameobjectToIdToCheck.ContainsKey(gameobjectId))
                        gameobjectToIdToCheck[gameobjectId] = new HashSet<string>();

                    gameobjectToIdToCheck[gameobjectId].UnionWith(visitor.IdToCheck);
                }
            }

            foreach (var pair in gameobjectToIdToCheck)
            {
                var haveOneValidCall = false;
                if (!parsedNodes.ContainsKey(pair.Key))
                {
                    Debug.LogError("Tried to check an object id that don't exist : " + pair.Key);
                    continue;
                }

                foreach (var _ in pair.Value.Select(id => parsedNodes[id])
                             .Select(targetNode =>
                                 ((YamlScalarNode)targetNode["MonoBehaviour"]["m_Script"]["guid"]).Value)
                             .Select(guid =>
                                 AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guid)))
                             .Where(script => script.GetClass() == _typeSearched)) haveOneValidCall = true;

                if (!haveOneValidCall) continue;
                if (!filenameWrote)
                {
                    filenameWrote = true;
                    _tempSearchResult += Path.GetFileName(file) + "\n";
                }

                if (((YamlScalarNode)parsedNodes[pair.Key]["GameObject"]["m_PrefabParentObject"]["fileID"]).Value !=
                    "0")
                {
                    _tempSearchResult += "\t" + "A Prefab \n";
                }
                else
                {
                    var fullPath = "";
                    var currentGoId = pair.Key;
                    while (currentGoId != "0")
                    {
                        fullPath = parsedNodes[currentGoId]["GameObject"]["m_Name"] +
                                   (fullPath == "" ? "" : "/" + fullPath);

                        var transformId =
                            parsedNodes[currentGoId]["GameObject"]["m_Component"][0]["component"]["fileID"].ToString();

                        Debug.Log("TransformID " + transformId);

                        var parentTransformId =
                            parsedNodes[transformId].Children.Values.ElementAt(0)["m_Father"]["fileID"].ToString();
                        Debug.Log("Parent transform ID " + parentTransformId);
                        if (parentTransformId != "0")
                            currentGoId =
                                parsedNodes[parentTransformId].Children.Values.ElementAt(0)["m_GameObject"]["fileID"]
                                    .ToString();
                        else
                            currentGoId = "0";

                        Debug.Log("currentGO-ID " + currentGoId);
                    }

                    _tempSearchResult += "\t" + fullPath + "\n";
                }
            }
        }

        public void HandleFile(string file)
        {
            var nameWritten = false;

            var relativePath = file.Replace(Application.dataPath, "Assets");
            Debug.Log(relativePath);
            Debug.Log(AssetDatabase.AssetPathToGUID(relativePath));

            var content = File.ReadAllText(file);
            var index = content.IndexOf(_valueToSearch, StringComparison.Ordinal);
            do
            {
                var gameobjectIndex = content.LastIndexOf(GameObjectIdString, index, StringComparison.Ordinal);
                if (gameobjectIndex == -1)
                    gameobjectIndex = content.LastIndexOf(GameObjectIdString, index, StringComparison.Ordinal);

                if (gameobjectIndex != -1)
                {
                    gameobjectIndex += GameObjectIdString.Length;
                    var id = content[gameobjectIndex..(
                        content.IndexOf('}', gameobjectIndex) - gameobjectIndex)];

                    var foundName = GetObjectName(content, id, gameobjectIndex);

                    if (!nameWritten)
                    {
                        _tempSearchResult += Path.GetFileName(file) + ":\n";
                        nameWritten = true;
                    }

                    _tempSearchResult += "\t" + foundName + "\n";
                }

                index = content.IndexOf(_valueToSearch, index + 10, StringComparison.Ordinal);
            } while (index != -1);

            //TODO : handle prefab override in scene, as it is saved in a different place!
        }

        private static string GetObjectName(string content, string gameobjectId, int startIndex)
        {
            try
            {
                var fatherName = "";
                var parentGoIndex = content.LastIndexOf("&" + gameobjectId, startIndex, StringComparison.Ordinal);
                if (parentGoIndex == -1)
                    parentGoIndex = content.IndexOf("&" + gameobjectId, startIndex, StringComparison.Ordinal);
                var fatherIdPlaceIndex =
                    content.IndexOf(GameObjectParentString, parentGoIndex, StringComparison.Ordinal);
                if (fatherIdPlaceIndex != -1)
                {
                    fatherIdPlaceIndex += GameObjectParentString.Length;
                    var id = content[fatherIdPlaceIndex..(
                        content.IndexOf('}', fatherIdPlaceIndex) - fatherIdPlaceIndex)];
                    if (id != "0")
                    {
                        var parentTransformIndex =
                            content.LastIndexOf("&" + id, parentGoIndex, StringComparison.Ordinal);
                        if (parentTransformIndex == -1)
                            parentTransformIndex = content.IndexOf("&" + id, parentGoIndex, StringComparison.Ordinal);

                        var parentgoidindex = content.IndexOf(GameObjectIdString, parentTransformIndex,
                            StringComparison.Ordinal);
                        parentgoidindex += GameObjectIdString.Length;
                        var parentGoid = content[parentgoidindex..(
                            content.IndexOf('}', parentgoidindex) - parentgoidindex)];
                        fatherName = GetObjectName(content, parentGoid, parentGoIndex) + "/";
                    }
                }

                var nameIndex = content.IndexOf(GameObjectNameString, parentGoIndex, StringComparison.Ordinal) +
                                GameObjectNameString.Length;
                return fatherName + content[nameIndex..(
                    content.IndexOf("\n", nameIndex, StringComparison.Ordinal) - nameIndex)];
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return "ERROR";
        }

        private static IEnumerable<Type> FindType(string fullName)
        {
            return
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.FullName != null && t.FullName.Equals(fullName));
        }

        public class YamlVisitorEvent : IYamlVisitor
        {
            public bool HavePersistentCall;
            public HashSet<string> IdToCheck = new();
            public ReferenceFinder ReferenceFinder;

            public void Visit(YamlStream stream)
            {
            }

            public void Visit(YamlDocument document)
            {
            }

            public void Visit(YamlScalarNode scalar)
            {
            }

            public void Visit(YamlSequenceNode sequence)
            {
            }

            public void Visit(YamlMappingNode mapping)
            {
                foreach (var n in mapping)
                {
                    n.Value.Accept(this);
                    if (((YamlScalarNode)n.Key).Value != "m_PersistentCalls") continue;

                    if (n.Value["m_Calls"] is not YamlSequenceNode callsSequence) continue;
                    foreach (var call in callsSequence)
                        if (((YamlScalarNode)call["m_MethodName"]).Value == ReferenceFinder._valueToSearch)
                        {
                            HavePersistentCall = true;
                            IdToCheck.Add(((YamlScalarNode)call["m_Target"]["fileID"]).Value);
                        }
                }
            }
        }
    }
}