using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_ShowModalPopup : MissionSubSection
{
    //[Title("Show Modal Popup")]

    public string header;
    public string body;
    public float duration;

    public override string GetTitle()
    {

        return "Modal: " + duration + "s | " + header + " | " + body;
    }
}
