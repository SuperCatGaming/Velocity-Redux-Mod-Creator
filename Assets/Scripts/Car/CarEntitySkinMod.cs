using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Skin Entity", menuName = "Mods/Car Skin (for cars in this mod)", order = 2)]
public class CarEntitySkinMod : ScriptableObject
{
    private void OnEnable() {
        Lists.InitializeLists();
        RimNames = Lists.RimList;
    }

    public string id;
    [Header("Skin Info")]
    public string skinName;
    public string skinLongName;
    public string skinCreator;
    public string skinPeriod;
    public Texture skinImage;

    [Header("Skin Defaults")]
    public Color skinRimColor;
    public Color skinRimSecondary;
    public Color skinTireColor;
    public string defaultRim;

    [Header("Skin Color")]
    public bool skinColorChangeable = false;
    public List<int> skinColorSlots;
    public Color skinColorDefault = Color.white;

    [Header("Skin Unlock")]
    public bool bypassUnlock;

    [Header("Skin Data")]
    public List<CarSkinData> skinMaterials;

    [Header("Name Lists (for your reference)")]
    public List<string> RimNames;
}
