using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Skin Addon", menuName = "Mods/Car Skin (for existing cars)", order = 3)]
public class CarEntitySkinAddon : ScriptableObject
{
    private void OnEnable() {
        Lists.InitializeLists();
        CarNames = Lists.CarList;
        RimNames = Lists.RimList;
    }

    public string id;
    [Header("Skin Info")]
    public string skinName;
    public string skinLongName;
    public string skinCreator;
    public string skinPeriod;
    public Texture skinImage;
    public string carId;

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
    public List<string> CarNames;
    public List<string> RimNames;
}
