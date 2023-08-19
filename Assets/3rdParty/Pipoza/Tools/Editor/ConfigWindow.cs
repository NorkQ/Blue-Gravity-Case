using Sirenix.Utilities;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;

public class ConfigWindow : OdinMenuEditorWindow
{
    private static Type[] m_TypesToDisplay = TypeCache.GetTypesWithAttribute<ConfigAttribute>().OrderBy(x => x.Name).ToArray();
 
    [MenuItem("Window/Pipoza/Config Window %c")]
    private static void OpenWindow()
    {
        GetWindow<ConfigWindow>().Show();//
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;

        foreach(Type type in m_TypesToDisplay)
        {
            tree.AddAllAssetsAtPath("All Configs", "Assets/GameSystems/", type, true, true);
        }

        return tree;
    }
}