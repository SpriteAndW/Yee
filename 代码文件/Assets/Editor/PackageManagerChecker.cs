using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Assets.Editor
{
    public class PackageChecker
    {
        private static AddRequest _addRequest;
        private static ListRequest _listRequest;
        private static readonly Stack<int> MissingPackages = new();
        private static List<PackageEntry> _packageToAdd;

        // [InitializeOnLoadMethod]
        public static void CheckPackage()
        {
            var filePath = Application.dataPath + "/../Library/PackageChecked";
            if (File.Exists(filePath)) return;
            Debug.Log("[Auto Package] : Checking if required packages are included");
            var packageListFile =
                Directory.GetFiles(Application.dataPath, "PackageImportList.txt", SearchOption.AllDirectories);
            if (packageListFile.Length == 0)
            {
                Debug.LogError(
                    "[Auto Package] : Couldn't find the packages list. Be sure there is a file called PackageImportList in your project");
            }
            else
            {
                var packageListPath = packageListFile[0];
                _packageToAdd = new List<PackageEntry>();
                var content = File.ReadAllLines(packageListPath);
                foreach (var line in content)
                {
                    var split = line.Split('@');
                    var entry = new PackageEntry
                    {
                        Name = split[0],
                        Version = split.Length > 1 ? split[1] : null
                    };
                    _packageToAdd.Add(entry);
                }

                File.WriteAllText(filePath, "Delete this to trigger a new auto package check");
                _listRequest = Client.List();
                EditorApplication.update += OnUpdate;
            }
        }

        public static void OnUpdate()
        {
            if (_listRequest != null)
            {
                if (_listRequest.IsCompleted)
                {
                    var foundPackages = new bool[_packageToAdd.Count];
                    for (var i = 0; i < foundPackages.Length; ++i)
                        foundPackages[i] = false;
                    foreach (var package in _listRequest.Result)
                        for (var i = 0; i < foundPackages.Length; ++i)
                            if (package.packageId.Contains(_packageToAdd[i].Name))
                            {
                                foundPackages[i] = true;
                                Debug.Log("[Auto package] Package " + _packageToAdd[i].Name +
                                          " already imported in that project");
                            }

                    for (var i = 0; i < foundPackages.Length; ++i)
                        if (!foundPackages[i])
                            MissingPackages.Push(i);
                    _listRequest = null;
                }
                else if (_listRequest.Error != null)
                {
                    Debug.Log(_listRequest.Error.message);
                    _listRequest = null;
                }
            }
            else
            {
                var noMorePackage = false;

                if (MissingPackages.Count > 0)
                    EditorUtility.DisplayProgressBar("Importing package", "Importing missing package for the project",
                        1.0f - MissingPackages.Count / (float)_packageToAdd.Count);
                else
                    EditorUtility.ClearProgressBar();

                if (_addRequest == null)
                {
                    if (MissingPackages.Count == 0)
                    {
                        noMorePackage = true;
                    }
                    else
                    {
                        var package = MissingPackages.Pop();
                        var name = _packageToAdd[package].Name;
                        if (_packageToAdd[package].Version != null)
                            name += "@" + _packageToAdd[package].Version;

                        _addRequest = Client.Add(name);
                    }
                }
                else
                {
                    if (_addRequest.IsCompleted)
                    {
                        if (_addRequest.Error != null)
                            Debug.LogError("[Auto Package Error] : " + _addRequest.Error.message);
                        else if (_addRequest.Result != null)
                            Debug.Log("[Auto Package] : Automatically added package " + _addRequest.Result.displayName);
                        else
                            Debug.LogError(
                                "[Auto Package] : Unknown error with adding new package to the Package Manager");
                        _addRequest = null;
                    }
                }

                if (!noMorePackage) return;
                Debug.Log("[Auto Package] : All packages checked");
                EditorApplication.update -= OnUpdate;
            }
        }

        public class PackageEntry
        {
            public string Name;
            public string Version;
        }
    }
}