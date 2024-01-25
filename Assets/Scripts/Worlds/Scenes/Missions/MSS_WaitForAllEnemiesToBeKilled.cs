using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MSS_WaitForAllEnemiesToBeKilled : MissionSubSection
{
    public bool active;

    public override string GetTitle()
    {
        return "[SECTION END] Wait For All Enemies To Be Killed";
    }
}
