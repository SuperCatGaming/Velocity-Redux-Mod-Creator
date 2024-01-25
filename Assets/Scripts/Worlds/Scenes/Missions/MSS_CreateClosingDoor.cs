using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_CreateClosingDoor : MissionSubSection
{
    //[Title("Create Closing Door")]

    public Vector3 position;
    public Quaternion rotation;
    public bool permanent;

    public override string GetTitle()
    {
        return ("Create Closing Door" + (permanent ? " - Permanent" : ""));
    }
}
