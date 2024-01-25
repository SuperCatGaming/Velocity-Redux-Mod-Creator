using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_HandleCamera : MissionSubSection
{
    public enum CameraFocus
    {
        DetachCamera,
        AttachPlayer,
        AttachAI
    }

    //[Title("Handle Camera")]

    public CameraFocus cameraFocus;

    //[ShowIf("cameraFocus", CameraFocus.DetachCamera)]
    //[Header("Detatch Camera")]
    public Vector3 cameraPosition;

    //[ShowIf("cameraFocus", CameraFocus.DetachCamera)]
    public Quaternion cameraRotation;

    //[ShowIf("cameraFocus", CameraFocus.AttachAI)]
    //[Header("Attach AI Camera")]
    public int aiIndex;
    //[Space]
    public bool cameraOrbit = false;
    
    //[ShowIf("cameraOrbit", true)]
    public float orbitSpeed = 60f;

    public override string GetTitle()
    {
        string builtTitle = "Camera: ";

        switch (cameraFocus)
        {
            case CameraFocus.DetachCamera:
                builtTitle += "Detach";
                break;
            case CameraFocus.AttachPlayer:
                builtTitle += "Player";
                break;
            case CameraFocus.AttachAI:
                builtTitle += "AI " + aiIndex;
                break;
        }

        if (cameraOrbit) builtTitle += ", Orbit";

        return builtTitle;
    }
}
