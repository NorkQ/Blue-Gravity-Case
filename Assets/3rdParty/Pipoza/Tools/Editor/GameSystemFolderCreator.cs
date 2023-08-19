using UnityEngine;
using UnityEditor;
using System.Reflection;
using Sirenix.Utilities;

public class GameSystemFolderCreator : MonoBehaviour
{
    [MenuItem("Assets/Create/Pipoza/Create Game System Folder")]
    private static void createGameSystemFolder(MenuCommand i_MenuCommand)
    {
        string currentFolder = "";
        TryGetActiveFolderPath(out currentFolder);

        AssetDatabase.CreateFolder(currentFolder, "New Game System");

        string createdFolderPath = currentFolder + "/New Game System";
        
        foreach(string folderName in ToolsGlobalConfig.Instance.GameSystemFolders)
        {
            UnityEngine.Windows.Directory.CreateDirectory(createdFolderPath + "/" + folderName);
        }

        AssetDatabase.Refresh();
    }

    public static bool TryGetActiveFolderPath(out string path)
    {
        var _tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("TryGetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);

        object[] args = new object[] { null };
        bool found = (bool)_tryGetActiveFolderPath.Invoke(null, args);
        path = (string)args[0];

        return found;
    }
}
