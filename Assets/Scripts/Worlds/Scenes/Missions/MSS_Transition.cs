using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_Transition : MissionSubSection
{
    public enum TransitionType
    {
        CinematicBarsIn,
        CinematicBarsOut,
        FadeShow,
        FadeHide,
    }

    //[Title("Perform Transition")]

    public TransitionType transitionType;
    public float transitionDuration = 0.5f;

    public override string GetTitle()
    {
        string builtTitle = "Transition: ";

        builtTitle += (transitionDuration) + "s ";

        switch (transitionType)
        {
            case TransitionType.CinematicBarsIn:
                builtTitle += "CineBar IN";
                break;
            case TransitionType.CinematicBarsOut:
                builtTitle += "CineBar OUT";
                break;
            case TransitionType.FadeShow:
                builtTitle += "Fade TO BLACK";
                break;
            case TransitionType.FadeHide:
                builtTitle += "Fade TO GAME";
                break;
        }

        return builtTitle;
    }
}
