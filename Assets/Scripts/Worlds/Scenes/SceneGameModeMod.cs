using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Game Scene Mode", menuName = "Mods/Worlds/Scene Game Mode")]
public class SceneGameModeMod : ScriptableObject
{
    public string id;
    public string translatablePrefix;
    public string translatableName;

    public NetworkGameSetup.NetworkGameType gameMode;
    public List<CarSpawns> carSpawns;
    public List<GameObject> gameModeObjects;
    public string overrideMusicId;

    public int RaceCheckpointTotal;
    public bool RaceSupportsLaps;
    public bool RaceIsFastCross;

    public bool GearHuntUnlockKey = false;
    public string GearHuntKeyUnlock;

    public bool GearHuntUnlockGears = false;
    public int GearHuntGearsRequired;
    public string GearHuntGearsUnlock;

    public float RacePlatinumTime = 3600f;
    public float RaceGoldTime = 3601f;
    public float RaceSilverTime = 3602f;
    public float RaceBronzeTime = 3603f;
    public string RacePlatinumUnlock;
    public string RaceGoldUnlock;
    public string RaceSilverUnlock;
    public string RaceBronzeUnlock;

    public List<MissionSectionMod> missionSections;
}
