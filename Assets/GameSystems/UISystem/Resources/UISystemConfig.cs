using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

[CreateAssetMenu(menuName = "Pipoza/Config/UISystemConfig", fileName = "UISystemConcifg")]
[Config]
public class UISystemConfig : SingletonScriptableObject<UISystemConfig> {
 
    [Title("Debug")]
    public float Debug;
    
    [Title("Input")]
    public float Input;

    [Title("Gameplay")]
    public float Gameplay;

    [Title("UI")]
    public float UI;

    [Title("Player")]
    public float Player;

    [Title("Camera")]
    public float Camera;

    [Title("Tweens")]
    public float BuyButtonErrorDuration;
    public Color BuyButtonNormalColor;
    public Color BuyButtonErrorColor;

    [Button]
    private void openScript()
    {
    }
}
