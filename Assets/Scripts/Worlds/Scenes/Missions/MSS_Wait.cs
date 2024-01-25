using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_Wait : MissionSubSection
{
    //[Title("Wait For...")]
    public float time;

    public override string GetTitle()
    {

        return "WAIT " + time + " Second" + (time != 1f ? "s" : "");
    }
}
