using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MissionSubSection {
    //[HideLabel]
    //[HorizontalGroup("Split", 200)]
    public string name = "NO NAME";
    //[HorizontalGroup("Split", 200)]
    public bool waitToFinish = true;

    //public static Texture icon;

    public virtual IEnumerator Execute() { yield return null; }
    public virtual string GetTitle() { return name; }
    public virtual Texture GetIcon() { return null; }

}
