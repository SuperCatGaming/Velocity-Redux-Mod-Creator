using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_ShowGameUI : MissionSubSection
{
    //[Title("Handle Game UI")]

    public bool show;

    public override string GetTitle()
    {
        return (show ? "Show Game UI" : "Hide Game UI");
    }
}
