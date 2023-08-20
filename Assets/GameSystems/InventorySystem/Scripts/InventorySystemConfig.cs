using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;

[CreateAssetMenu(menuName = "Pipoza/Config/InventorySystemConfig", fileName = "InventorySystemConfig")]
[Config]
public class InventorySystemConfig : GlobalConfig<InventorySystemConfig> {
 
    [Title("Debug")]
    public float Debug;
    
    [Title("Input")]
    public float Input;

    [Title("Gameplay")]
    public int InventorySize;
    public ItemUI ItemUIPrefab;
    public ItemUIShop ItemUIShopPrefab;

    [Title("UI")]
    public float UI;

    [Title("Player")]
    public float Player;

    [Title("Camera")]
    public float Camera;

    [Title("Tweens")]
    public float Tweens;

    [Button]
    private void openScript()
    {
        string path = AssetDatabase.GetAssetPath(this);
        UnityEngine.Debug.Log(path);

        path = path.Replace("asset", "cs");
        Object script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
        AssetDatabase.OpenAsset(script.GetInstanceID());
    }
}
