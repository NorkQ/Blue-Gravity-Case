using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;

[CreateAssetMenu(menuName = "Pipoza/Config/GeneralConfig", fileName = "GeneralConfig")]
[Config]
public class GeneralConfig : SingletonScriptableObject<GeneralConfig> {
 
    [Title("Debug")]
    public float Debug;
    
    [Title("Input")]
    public float Input;

    [Title("Gameplay")]
    public AudioClip InGameAmbientMusic;
    public AudioClip InInventoryAmbientMusic;
    public AudioClip InShopAmbientMusic;

    [Title("UI")]
    public string NotEnoughMoneyWarning;

    [Title("Player")]
    public float Player;

    [Title("Camera")]
    public float Camera;

    [Title("Tweens")]
    public float Tweens;

    [Button]
    private void openScript()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        UnityEngine.Debug.Log(path);

        path = path.Replace("asset", "cs");
        Object script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
        AssetDatabase.OpenAsset(script.GetInstanceID());
#endif
    }
}
