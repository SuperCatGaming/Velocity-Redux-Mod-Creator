using System.Collections.Generic;
using UnityEngine;
using System;
using AYellowpaper.SerializedCollections;
using System.Text;

[PreferBinarySerialization]
public class LanguageGame : ScriptableObject {
    public string id;
    public string localName;

    public SerializedDictionary<string, string> translations;
}
