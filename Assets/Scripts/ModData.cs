using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mod", menuName = "Mods/Mod Asset", order = 100)]
public class ModData : ScriptableObject {
    public bool _translatable;
    public string _id;
    public string _title;
    public string _author;
    public string _version;
    public string _description;
    public Sprite _image;
    public List<Dependency> _dependencies;

    [Serializable]
    public class Dependency {
        public string _id;
        public string _version;
    }
}
