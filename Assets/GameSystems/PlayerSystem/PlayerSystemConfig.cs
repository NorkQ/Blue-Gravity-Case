using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;

[CreateAssetMenu(menuName = "Pipoza/Config/PlayerSystemConfig", fileName = "PlayerSystemConfig")]
[Config]
public class PlayerSystemConfig : GlobalConfig<PlayerSystemConfig> {
 
    [Title("Debug")]
    public float Debug;

    [Title("Input")]
    public string AnimatorHorizontalValueID;
    public string AnimatorVerticalValueID;
    public string AnimatorSpeedValueID;
    public string AnimatorDirectionValueID;

    [Title("Gameplay")]
    public float Gameplay;

    [Title("UI")]
    public float UI;

    [Title("Player")]
    public float MovementSpeed;
    public Sprite DefaultHead;
    public Sprite DefaultBody;
    public Sprite DefaultLegs;

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
