using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Skin Data", menuName = "Mods/Car Skin Data", order = 4)]
public class CarSkinData : ScriptableObject
{
    public bool hidePart;
    public bool partIsLOD;
    [Header("Skin Data")]
    public List<Material> skinMaterials;
}
