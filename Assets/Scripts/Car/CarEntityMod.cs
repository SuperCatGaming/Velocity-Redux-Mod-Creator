using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Entity", menuName = "Mods/Car Entity", order = 1)]
public class CarEntityMod : ScriptableObject
{
    public string id;
    [Header("Car Info")]
    public string carName;
    public string carCreator;
    public string carPeriod;

    [Header("Car Unlock")]
    public bool bypassUnlock;
    public bool secretCar;

    [Header("Car Data")]
    public GameObject carReference;
    public List<CarEntitySkinMod> carSkins;

    public bool carNeedsNewIcons;
}
