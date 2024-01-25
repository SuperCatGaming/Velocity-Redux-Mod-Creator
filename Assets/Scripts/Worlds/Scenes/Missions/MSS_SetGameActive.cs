using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_SetGameActive : MissionSubSection
{
    //[Title("Set Game Active State")]
    public bool active;

    public override string GetTitle()
    {
        return (active ? "Set Game ACTIVE" : "Set Game INACTIVE");
    }
}
