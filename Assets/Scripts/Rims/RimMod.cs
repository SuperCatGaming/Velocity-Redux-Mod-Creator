using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rim", menuName = "Mods/Rim", order = 5)]
public class RimMod : ScriptableObject
{
    [Header("Rim Prefab")]
    public GameObject rimPrefab;
}
