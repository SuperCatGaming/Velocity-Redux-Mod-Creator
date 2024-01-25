using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Language", menuName = "Mods/Language")]
[PreferBinarySerialization]
public class Language : ScriptableObject {
    public string id;
    public string localName;
    [SerializedDictionary("ID", "Translation")]
    public SerializedDictionary<string, string> translations;
    
}
