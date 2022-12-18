using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Editor
{
    public class PackageDesigner : EditorWindow
    {
        private readonly Queue<ExportTask> _mToExport = new();
        private AssetPackage[] _mAssetPackageList;
        private DependencyTreeView _mAssetPreviewTree;
        private bool _mCloseOnFinishExport;
        private Vector2 _mErroDisplayScroll;
        private string _mPackageCompileError;
        private Vector2 _mPackageListScrollPos;
        private TreeViewState _mReorgstate;
        private DependencyTreeView _mReorgTreeView;
        private TreeViewState _mTvstate;
        public List<string> NonCompilingFiles { get; } = new();
        public AssetPackage CurrentlyEdited { get; private set; }

        public void OnEnable()
        {
            GetAllPackageList();

            _mTvstate = new TreeViewState();
            _mAssetPreviewTree = new DependencyTreeView(_mTvstate)
            {
                Designer = this,
                IsPreview = true
            };
            _mReorgstate = new TreeViewState();
            _mReorgTreeView = new DependencyTreeView(_mReorgstate)
            {
                Designer = this,
                IsPreview = false
            };
            Undo.undoRedoPerformed += UndoPerformed;
            PopulateTreeview();
        }

        public void OnDisable()
        {
            Undo.undoRedoPerformed -= UndoPerformed;
            EditorApplication.UnlockReloadAssemblies();
        }

        public void OnGUI()
        {
            if (_mToExport.Count > 0)
                EditorUtility.DisplayProgressBar("Exporting package...", "Exporting package", 0.5f);
            else
                EditorUtility.ClearProgressBar();
            if (GUILayout.Button("Export All Package")) ExportAll();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical(GUILayout.Width(128));
            if (GUILayout.Button("New..."))
            {
                var savePath =
                    EditorUtility.SaveFilePanelInProject("Save package file", "package", "asset", "Save package");
                if (savePath != "")
                {
                    var package = CreateInstance<AssetPackage>();
                    AssetDatabase.CreateAsset(package, savePath.Replace(Application.dataPath, "Assets"));
                    CurrentlyEdited = package;
                    ArrayUtility.Add(ref _mAssetPackageList, package);
                    AssetDatabase.Refresh();
                }
            }

            _mPackageListScrollPos = EditorGUILayout.BeginScrollView(_mPackageListScrollPos, "box");
            foreach (var t in _mAssetPackageList)
                if (t != CurrentlyEdited)
                {
                    if (!GUILayout.Button(t.PackageName)) continue;
                    CurrentlyEdited = t;
                    PopulateTreeview();
                }
                else
                {
                    GUILayout.Label(t.PackageName);
                }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
            if (CurrentlyEdited != null)
                EditedUI();
            EditorGUILayout.EndHorizontal();
        }

        public void OnFocus()
        {
            PopulateTreeview();
        }

        [MenuItem("基本工具/打包设置")]
        public static void Open()
        {
            GetWindow<PackageDesigner>();
        }

        public void OnUpdate()
        {
            if (_mToExport.Count > 0)
            {
                var task = _mToExport.Peek();
                if (!task.Copied)
                {
                    task.OldPathSaved = new string[task.Package.Dependencies.Length];
                    task.NewPathSaved = new string[task.Package.Dependencies.Length];
                    task.ExportTemp = Application.dataPath + "/" + task.Package.PackageName + "_Export";
                    task.MovePath = task.ExportTemp.Replace(Application.dataPath, "Assets");
                    Directory.CreateDirectory(task.ExportTemp);
                    for (var i = 0; i < task.Package.DependenciesId.Length; ++i)
                    {
                        var destPath = task.Package.OutputPath[i].Replace("Assets", task.MovePath);
                        var directorypath = destPath.Replace("Assets", Application.dataPath);
                        Directory.CreateDirectory(Path.GetDirectoryName(directorypath) ?? string.Empty);
                    }

                    AssetDatabase.Refresh();

                    for (var i = 0; i < task.Package.DependenciesId.Length; ++i)
                    {
                        var path = AssetDatabase.GUIDToAssetPath(task.Package.DependenciesId[i]);
                        task.OldPathSaved[i] = path;
                        var destPath = task.Package.OutputPath[i].Replace("Assets", task.MovePath);
                        task.NewPathSaved[i] = destPath;
                        AssetDatabase.MoveAsset(path, destPath);
                    }

                    AssetDatabase.Refresh();
                    task.Copied = true;
                }
                else
                {
                    Debug.Log("Exporting and cleaning");
                    AssetDatabase.ExportPackage(task.MovePath, task.Destination, ExportPackageOptions.Recurse);
                    for (var i = 0; i < task.OldPathSaved.Length; ++i)
                        AssetDatabase.MoveAsset(task.NewPathSaved[i], task.OldPathSaved[i]);
                    FileUtil.DeleteFileOrDirectory(task.ExportTemp);
                    AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
                    _mToExport.Dequeue();
                }
            }
            else if (_mCloseOnFinishExport)
            {
                EditorApplication.Exit(0);
            }
        }

        private void UndoPerformed()
        {
            PopulateTreeview();
        }

        public void ExportCurrentPackage(string saveTo = "")
        {
            if (saveTo == "")
                saveTo = EditorUtility.SaveFilePanel("Export package", Application.dataPath.Replace("/Assets", ""),
                    CurrentlyEdited.PackageName, "unitypackage");
            if (saveTo == "")
                return;

            var task = new ExportTask
            {
                Destination = saveTo,
                Package = CurrentlyEdited
            };

            _mToExport.Enqueue(task);
        }

        public void ExportAll(string saveFolder = "")
        {
            if (saveFolder == "")
                saveFolder = EditorUtility.SaveFolderPanel("Choose output Folder",
                    Application.dataPath.Replace("/Assets", ""), "Package Output");

            if (saveFolder == "")
                return;

            Debug.LogFormat("Export all package : {0} package to export", _mAssetPackageList.Length);

            var current = CurrentlyEdited;
            foreach (var t in _mAssetPackageList)
            {
                CurrentlyEdited = t;
                ExportCurrentPackage(saveFolder + "/" + CurrentlyEdited.PackageName + ".unitypackage");
            }

            CurrentlyEdited = current;
        }

        public static void CommandLineExportAllPackage()
        {
            var designer = GetWindow<PackageDesigner>();

            var commandLineArgument = Environment.GetCommandLineArgs();
            var index = Array.IndexOf(commandLineArgument, "PackageDesigner.CommandLineExportAllPackage");

            if (index < 0 || index + 1 >= commandLineArgument.Length ||
                !Directory.Exists(commandLineArgument[index + 1]))
            {
                Debug.LogError(
                    "Specify a path to export the packages to! (place the path after -executeMethod PackageDesigner.CommandLineExportAllPackage \"your path here\")");
                EditorApplication.Exit(12);
            }

            designer.ExportAll(commandLineArgument[index + 1]);
            designer._mCloseOnFinishExport = true;
        }

        public void EditedUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginVertical();

            if (_mPackageCompileError != "")
            {
                _mErroDisplayScroll = EditorGUILayout.BeginScrollView(_mErroDisplayScroll, GUILayout.Height(64));
                EditorGUILayout.HelpBox(_mPackageCompileError, MessageType.Error);
                EditorGUILayout.EndScrollView();
            }

            EditorGUILayout.BeginHorizontal();
            var packageName = EditorGUILayout.DelayedTextField("Package Name", CurrentlyEdited.PackageName);
            if (packageName != CurrentlyEdited.PackageName)
            {
                Undo.RecordObject(CurrentlyEdited, "Renamed package");
                CurrentlyEdited.PackageName = packageName;
            }


            if (GUILayout.Button("Export ...")) ExportCurrentPackage();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.LabelField("ASSETS LIST", GUILayout.ExpandHeight(true));

            EditorGUILayout.EndVertical();
            var r = GUILayoutUtility.GetLastRect();
            r.y += EditorGUIUtility.singleLineHeight;
            r.height -= EditorGUIUtility.singleLineHeight * 1.5f;
            _mAssetPreviewTree.OnGUI(r);

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("OUTPUT", GUILayout.ExpandHeight(true));
            EditorGUILayout.EndVertical();
            r = GUILayoutUtility.GetLastRect();
            r.y += EditorGUIUtility.singleLineHeight;
            r.height -= EditorGUIUtility.singleLineHeight * 1.5f;
            _mReorgTreeView.OnGUI(r);

            EditorGUILayout.EndHorizontal();

            if (_mAssetPreviewTree.AssetPreviews is { Length: > 0 })
            {
                EditorGUILayout.BeginHorizontal("box", GUILayout.Height(128.0f));
                if (_mAssetPreviewTree.AssetPreviews != null)
                    foreach (var t in _mAssetPreviewTree.AssetPreviews)
                        EditorGUILayout.LabelField(t, GUILayout.Height(128.0f));

                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();
        }

        public void GetAllAssetsDependency(Object[] objs)
        {
            Undo.RecordObject(CurrentlyEdited, "Dependencies added");
            CurrentlyEdited.DependenciesId ??= Array.Empty<string>();

            foreach (var t in objs)
            {
                var str = AssetDatabase.GetDependencies(AssetDatabase.GetAssetPath(t));

                foreach (var t1 in str)
                {
                    var depId = AssetDatabase.AssetPathToGUID(t1);
                    if (ArrayUtility.Contains(CurrentlyEdited.DependenciesId, depId)) continue;
                    ArrayUtility.Add(ref CurrentlyEdited.DependenciesId, depId);
                    ArrayUtility.Add(ref CurrentlyEdited.OutputPath, AssetDatabase.GUIDToAssetPath(depId));
                }
            }

            EditorUtility.SetDirty(CurrentlyEdited);

            PopulateTreeview();
        }

        public void PopulateTreeview()
        {
            _mPackageCompileError = "";
            _mErroDisplayScroll = Vector2.zero;

            if (CurrentlyEdited == null)
                return;

            var files = Array.Empty<string>();
            var depPath = CurrentlyEdited.Dependencies;
            foreach (var t in depPath)
                if (AssetDatabase.GetMainAssetTypeAtPath(t) == typeof(MonoScript))
                    ArrayUtility.Add(ref files, t.Replace("Assets", Application.dataPath));

            if (files.Length != 0) CheckCanCompile(files);


            _mAssetPreviewTree.AssetPackage = CurrentlyEdited;
            _mAssetPreviewTree.Reload();
            _mAssetPreviewTree.ExpandAll();

            _mReorgTreeView.AssetPackage = CurrentlyEdited;
            _mReorgTreeView.Reload();
            _mReorgTreeView.ExpandAll();
        }

        public void GetAllPackageList()
        {
            var assets = AssetDatabase.FindAssets("t:AssetPackage");
            _mAssetPackageList = new AssetPackage[assets.Length];

            for (var i = 0; i < assets.Length; ++i)
                _mAssetPackageList[i] =
                    AssetDatabase.LoadAssetAtPath<AssetPackage>(AssetDatabase.GUIDToAssetPath(assets[i]));
        }

        public void CheckCanCompile(string[] files)
        {
            NonCompilingFiles.Clear();
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.Location.Contains("Library"))
                    continue;
                parameters.ReferencedAssemblies.Add(assembly.Location);
            }

            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            var results = provider.CompileAssemblyFromFile(parameters, files);

            if (!results.Errors.HasErrors) return;
            var sb = new StringBuilder();

            foreach (CompilerError error in results.Errors)
            {
                sb.AppendLine($"Error in {error.FileName} : {error.ErrorText}");
                NonCompilingFiles.Add(error.FileName.Replace(Application.dataPath, "Assets"));
            }


            _mPackageCompileError = sb.ToString();
        }

        public class ExportTask
        {
            public bool Copied;
            public string Destination;

            public string ExportTemp;
            public string MovePath;
            public string[] NewPathSaved;

            public string[] OldPathSaved;
            public AssetPackage Package;
        }
    }


    public class DependencyTreeView : TreeView
    {
        public readonly List<int> MDragged = new();
        public AssetPackage AssetPackage;
        public GUIContent[] AssetPreviews;

        public PackageDesigner Designer;

        //TODO replace that with proper id handling, reusing etc. For now simple increment will be enough
        protected int FreeId;
        public bool IsPreview;

        protected GenericMenu MContextMenu;

        protected Texture2D MFolderIcone;

        public DependencyTreeView(TreeViewState state) : base(state)
        {
            MFolderIcone = EditorGUIUtility.Load("Folder Icon.asset") as Texture2D;
            FreeId = 0;
        }

        protected override TreeViewItem BuildRoot()
        {
            var item = new TreeViewItem
            {
                depth = -1
            };

            if (AssetPackage == null || AssetPackage.DependenciesId == null || AssetPackage.DependenciesId.Length == 0)
            {
                var itm = new TreeViewItem(FreeId, 0, "Nothing");
                item.AddChild(itm);
                return item;
            }

            for (var i = 0; i < AssetPackage.DependenciesId.Length; ++i)
            {
                var assetpath = AssetDatabase.GUIDToAssetPath(AssetPackage.DependenciesId[i]);
                var path = IsPreview ? assetpath : AssetPackage.OutputPath[i];

                RecursiveAdd(item, path, assetpath, i);
            }

            SetupDepthsFromParentsAndChildren(item);
            return item;
        }

        public void RecursiveAdd(TreeViewItem root, string value, string fullPath, int dependencyIdx)
        {
            while (true)
            {
                var idx = value.IndexOf('/');

                if (idx > 0)
                {
                    var node = value[..idx];
                    var childValue = value[(idx + 1)..];

                    if (root.hasChildren)
                        foreach (var t in root.children.Where(t => t.displayName == node))
                        {
                            RecursiveAdd(t, childValue, fullPath, dependencyIdx);
                            return;
                        }

                    var itm = new TreeViewItem(FreeId);
                    FreeId += 1;
                    itm.displayName = node;
                    itm.icon = MFolderIcone;
                    root.AddChild(itm);
                    root = itm;
                    value = childValue;
                    continue;
                }
                else
                {
                    var itm = new AssetTreeViewItem(FreeId);
                    FreeId += 1;

                    itm.displayName = value;
                    itm.FullAssetPath = fullPath;
                    itm.DependencyIdx = dependencyIdx;
                    var obj = AssetDatabase.LoadAssetAtPath(fullPath, typeof(Object));
                    itm.icon = AssetPreview.GetMiniThumbnail(obj);

                    root.AddChild(itm);
                }

                break;
            }
        }

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            base.SelectionChanged(selectedIds);

            AssetPreviews = Array.Empty<GUIContent>();

            var items = FindRows(selectedIds);

            foreach (var t in items)
                if (!t.hasChildren)
                {
                    if (t is not AssetTreeViewItem itm) continue;
                    var content =
                        new GUIContent(
                            AssetPreview.GetAssetPreview(AssetDatabase.LoadAssetAtPath(itm.FullAssetPath,
                                typeof(Object))));
                    ArrayUtility.Add(ref AssetPreviews, content);
                }
        }

        protected override void ContextClickedItem(int id)
        {
            base.ContextClickedItem(id);

            if (IsPreview)
                return;

            var itm = FindItem(id, rootItem);

            if (itm is AssetTreeViewItem)
                return;
            MContextMenu = new GenericMenu();
            MContextMenu.AddItem(new GUIContent("New Folder"), false, CreateFolderContext, itm);
            MContextMenu.ShowAsContext();
        }

        protected void CreateFolderContext(object item)
        {
            var root = (TreeViewItem)item;
            var itm = new TreeViewItem(FreeId);
            FreeId += 1;
            itm.displayName = "Folder";
            itm.icon = MFolderIcone;
            if (root != null)
            {
                root.AddChild(itm);

                SetupDepthsFromParentsAndChildren(root);
            }

            SetExpanded(itm.id, true);
        }

        protected override void CommandEventHandling()
        {
            base.CommandEventHandling();

            if (!Event.current.commandName.Contains("Delete")) return;
            var items = FindRows(GetSelection());
            var haveDelete = false;

            Undo.RecordObject(AssetPackage, "Delete dependency");
            foreach (var t in items)
                RecursiveDelete(t, ref haveDelete);

            if (haveDelete) DesignerReloadTrees();
        }

        public void RecursiveDelete(TreeViewItem item, ref bool haveDelete)
        {
            if (!item.hasChildren)
            {
                if (item is not AssetTreeViewItem itm) return;
                if (!haveDelete) haveDelete = true;

                var guid = AssetDatabase.AssetPathToGUID(itm.FullAssetPath);
                var idx = ArrayUtility.FindIndex(AssetPackage.DependenciesId, x => x == guid);

                if (idx != -1)
                {
                    ArrayUtility.RemoveAt(ref AssetPackage.DependenciesId, idx);
                    ArrayUtility.RemoveAt(ref AssetPackage.OutputPath, idx);
                }

                EditorUtility.SetDirty(AssetPackage);
            }
            else
            {
                foreach (var t in item.children)
                    RecursiveDelete(t, ref haveDelete);
            }
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            GUI.color = Color.white;

            if (args.item.hasChildren == false)
                if (args.item is AssetTreeViewItem itm)
                    if (Designer.NonCompilingFiles.Contains(itm.FullAssetPath))
                        GUI.color = Color.red;

            base.RowGUI(args);
        }

        protected override bool CanRename(TreeViewItem item)
        {
            return item is not AssetTreeViewItem;
        }

        protected override void RenameEnded(RenameEndedArgs args)
        {
            var item = FindItem(args.itemID, rootItem);

            item.displayName = args.newName;

            TriggerRename(item);

            args.acceptedRename = true;
        }

        protected override bool CanStartDrag(CanStartDragArgs args)
        {
            return !IsPreview;
        }

        protected override void SetupDragAndDrop(SetupDragAndDropArgs args)
        {
            base.SetupDragAndDrop(args);

            MDragged.Clear();
            MDragged.AddRange(args.draggedItemIDs);

            DragAndDrop.objectReferences = Array.Empty<Object>();
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.StartDrag("Item view");
        }

        protected override DragAndDropVisualMode HandleDragAndDrop(DragAndDropArgs args)
        {
            if (args.dragAndDropPosition == DragAndDropPosition.OutsideItems)
                return DragAndDropVisualMode.Rejected;

            if (!args.performDrop) return DragAndDropVisualMode.Move;
            if (DragAndDrop.objectReferences.Length > 0)
            {
                if (!IsPreview)
                    return
                        DragAndDropVisualMode.Rejected;
                Designer.GetAllAssetsDependency(DragAndDrop.objectReferences);
            }
            else
            {
                var dropTarget = args.parentItem;

                if (dropTarget is AssetTreeViewItem)
                    return DragAndDropVisualMode.Rejected;


                foreach (var itm in MDragged.Select(t => FindItem(t, rootItem)))
                    if (itm is AssetTreeViewItem assetItem)
                    {
                        var filename = Path.GetFileName(assetItem.FullAssetPath);
                        var newFilename = GetFullPath(dropTarget) + "/" + filename;

                        Designer.CurrentlyEdited.OutputPath[assetItem.DependencyIdx] = newFilename;
                    }
                    else
                    {
                        var originPath = GetFullPath(itm.parent);
                        var targetPath = GetFullPath(dropTarget);

                        foreach (var t in itm.children)
                            ReparentAssets(t, originPath, targetPath);
                    }

                Designer.PopulateTreeview();
            }

            return DragAndDropVisualMode.Move;
        }

        public string GetFullPath(TreeViewItem item)
        {
            if (item.parent == null || item.parent == rootItem)
                return item.displayName;

            return GetFullPath(item.parent) + "/" + item.displayName;
        }

        public void TriggerRename(TreeViewItem item)
        {
            if (item.hasChildren)
            {
                foreach (var t in item.children)
                    TriggerRename(t);
            }
            else
            {
                if (item is not AssetTreeViewItem assetItem) return;
                var p = GetFullPath(item);

                Designer.CurrentlyEdited.OutputPath[assetItem.DependencyIdx] = p;
            }
        }

        public void ReparentAssets(TreeViewItem item, string rootPath, string newPath)
        {
            if (item.hasChildren)
            {
                foreach (var t in item.children)
                    ReparentAssets(t, rootPath, newPath);
            }
            else
            {
                if (item is not AssetTreeViewItem assetTreeItem)
                    return;

                var path = GetFullPath(assetTreeItem);
                path = path.Replace(rootPath, newPath);
                Designer.CurrentlyEdited.OutputPath[assetTreeItem.DependencyIdx] = path;
            }
        }

        public void DesignerReloadTrees()
        {
            Designer.PopulateTreeview();
        }
    }

    public class AssetTreeViewItem : TreeViewItem
    {
        public int DependencyIdx = -1;
        public string FullAssetPath = "";

        public AssetTreeViewItem(int id) : base(id)
        {
        }
    }
}