using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Visual Theme", menuName = "Mods/Game Theme", order = 9)]
public class GameTheme : ScriptableObject
{
    public string id;
    public string themeName;
    public ColorBlock themeBlock;
}
