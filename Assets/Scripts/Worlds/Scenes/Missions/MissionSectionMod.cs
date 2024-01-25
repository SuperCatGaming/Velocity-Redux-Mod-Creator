using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mission Section", menuName = "Mods/Mission Section Mod")]
public class MissionSectionMod : ScriptableObject {
    [System.Serializable]
    public enum SectionGoal {
        ReachTrigger,
        DestroyAllEnemies

    }

    [Header("Info")]

    public string sectionTitle;
    public float sectionTimeLimit;
    public List<GameObject> sectionObjects;

    [Header("Goals")]

    public SectionGoal sectionGoal;

    /// <summary>
    /// Reach the Trigger entries
    /// </summary>

    //[ShowIf("sectionGoal", SectionGoal.ReachTrigger)]
    public GameObject goalObject;

    /// <summary>
    /// Destroy all enemies
    /// </summary>

    //[ShowIf("sectionGoal", SectionGoal.DestroyAllEnemies)]
    public int enemyCount;

    [Header("SubSections")]

    //[ListDrawerSettings(OnBeginListElementGUI = "BeginDrawListElement", OnEndListElementGUI = "EndDrawListElement")]
    //[SerializeReference]
    public List<MissionSubSectionMod> subSections;
}
