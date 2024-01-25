using UnityEngine;

[CreateAssetMenu(fileName = "New Boost Theme", menuName = "Mods/Boost Theme", order = 8)]
public class BoostTheme : ScriptableObject
{
    public string id;
    public string themeName;
    public Color uiColor;
    [GradientUsage(true)]
    public Gradient boostGradient;
}
