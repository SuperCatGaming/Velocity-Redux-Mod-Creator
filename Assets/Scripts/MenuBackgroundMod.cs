using UnityEngine;

[CreateAssetMenu(fileName = "New Menu Background", menuName = "Mods/Menu Background", order = 9)]
public class MenuBackgroundMod : ScriptableObject
{
    public string id;
    [Header("Info")]
    public string backgroundName;
    public string creator;
    public GameObject prefab;
}
