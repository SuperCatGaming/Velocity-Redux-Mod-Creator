using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Game Scene", menuName = "Mods/Worlds/Scene Info")]
public class SceneGameInfoMod : ScriptableObject
{
    public enum WorldCategory
    {
        VelocityX,
        TurboRacing,
        StuntTrackDriver,
        StuntTrackDriver2,
        StuntTrackChallenge,
        WorldRace,
        Acceleracers,
        Other,
        TEST
    }

    public string id;
    public string translatableName;
    public string scenePath;

    public List<SceneGameModeMod> sceneModes;

    [Header ("World Info")]
    public WorldCategory worldCategory;
    [TextArea(1,5)]
    public string worldDescription;
    public Sprite worldThumbnail;

    [Header("Scene Values")]

    public bool useHeadlights = false;
    public float killplaneHeight = -100f;

}
