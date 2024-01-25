using System;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[Serializable]
public class MissionSubSectionMod {

    public enum SubSectionType {
        CreateAICar,
        CreateClosingDoor,
        HandleCamera,
        RemoveAllClosingDoors,
        SetGameActive,
        ShowGameUI,
        ShowModalPopup,
        Transition,
        Wait,
        WaitForAllEnemiesToBeKilled
    }

    public SubSectionType type;
    //[HideLabel]
    //[HorizontalGroup("Split", 200)]
    //public string name = "NO NAME";
    //[HorizontalGroup("Split", 200)]
    //public bool waitToFinish = true;

    public MSS_CreateAICarMod createAICar;
    public MSS_CreateClosingDoor createClosingDoor;
    public MSS_HandleCamera handleCamera;
    public MSS_RemoveAllClosingDoors removeAllClosingDoors;
    public MSS_SetGameActive setGameActive;
    public MSS_ShowGameUI showGameUI;
    public MSS_ShowModalPopup showModalPopup;
    public MSS_Transition transition;
    public MSS_Wait wait;
    public MSS_WaitForAllEnemiesToBeKilled waitForAllEnemiesToBeKilled;

    public string GetTitle() {
        MissionSubSection mss = type switch {
            SubSectionType.CreateAICar => createAICar,
            SubSectionType.CreateClosingDoor => createClosingDoor,
            SubSectionType.HandleCamera => handleCamera,
            SubSectionType.RemoveAllClosingDoors => removeAllClosingDoors,
            SubSectionType.SetGameActive => setGameActive,
            SubSectionType.ShowGameUI => showGameUI,
            SubSectionType.ShowModalPopup => showModalPopup,
            SubSectionType.Transition => transition,
            SubSectionType.Wait => wait,
            SubSectionType.WaitForAllEnemiesToBeKilled => waitForAllEnemiesToBeKilled,
            _ => null,
        };
        return mss.GetTitle() + (mss.waitToFinish ? "" : "  [SKIP DURATION]");
    }

    //public static Texture icon;

    //public virtual string GetTitle() { return name; }
    //public virtual Texture GetIcon() { return null; }

}
