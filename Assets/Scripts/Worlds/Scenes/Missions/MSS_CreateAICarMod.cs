using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
//using Sirenix.OdinInspector;

[System.Serializable]
public class MSS_CreateAICarMod : MissionSubSection
{
    
    //[Title("Create AI Car")]

    public string car;
    //[ValueDropdown("GetAllSkins")]
    public string skin;
    public string rims;
    public int weaponIndex;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation;
    public float healthPercentage = 25f;
    public bool requireKill;

    public override string GetTitle()
    {
        if (car != null)
        {
            return ("Create Car: " + car);
        }
        return "[MSS_CreateAICar] ERROR";
    }

    //#if UNITY_EDITOR
    //    private IEnumerable GetAllSkins()
    //    {
    //        if (car != null)
    //        {
    //            return car.carSkins;
    //        }
    //        else
    //        {
    //            return UnityEditor.AssetDatabase.FindAssets("t:CarEntitySkin")
    //            .Select(x => UnityEditor.AssetDatabase.GUIDToAssetPath(x))
    //            .Select(x => new ValueDropdownItem(x, UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(x)));
    //        }
            
    //    }
    //#endif
}
