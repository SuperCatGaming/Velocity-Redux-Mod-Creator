using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SceneGameModeMod))]
public class SGMMEditor : Editor
{

    SerializedProperty id;
    SerializedProperty translatablePrefix;
    SerializedProperty translatableName;
    SerializedProperty gameMode;
    SerializedProperty carSpawns;
    SerializedProperty gameModeObjects;
    SerializedProperty overrideMusicId;

    SerializedProperty RaceCheckpointTotal;
    SerializedProperty RaceSupportsLaps;
    SerializedProperty RaceIsFastCross;

    SerializedProperty GearHuntUnlockKey;
    SerializedProperty GearHuntKeyUnlock;

    SerializedProperty GearHuntUnlockGears;
    SerializedProperty GearHuntGearsRequired;
    SerializedProperty GearHuntGearsUnlock;

    SerializedProperty RacePlatinumTime;
    SerializedProperty RaceGoldTime;
    SerializedProperty RaceSilverTime;
    SerializedProperty RaceBronzeTime;
    SerializedProperty RacePlatinumUnlock;
    SerializedProperty RaceGoldUnlock;
    SerializedProperty RaceSilverUnlock;
    SerializedProperty RaceBronzeUnlock;

    SerializedProperty missionSections;

    private void OnEnable() {
        id = serializedObject.FindProperty("id");
        translatablePrefix = serializedObject.FindProperty("translatablePrefix");
        translatableName = serializedObject.FindProperty("translatableName");
        gameMode = serializedObject.FindProperty("gameMode");
        carSpawns = serializedObject.FindProperty("carSpawns");
        gameModeObjects = serializedObject.FindProperty("gameModeObjects");
        overrideMusicId = serializedObject.FindProperty("overrideMusicId");
        RaceCheckpointTotal = serializedObject.FindProperty("RaceCheckpointTotal");
        RaceSupportsLaps = serializedObject.FindProperty("RaceSupportsLaps");
        RaceIsFastCross = serializedObject.FindProperty("RaceIsFastCross");
        GearHuntUnlockKey = serializedObject.FindProperty("GearHuntUnlockKey");
        GearHuntKeyUnlock = serializedObject.FindProperty("GearHuntKeyUnlock");
        GearHuntUnlockGears = serializedObject.FindProperty("GearHuntUnlockGears");
        GearHuntGearsRequired = serializedObject.FindProperty("GearHuntGearsRequired");
        GearHuntGearsUnlock = serializedObject.FindProperty("GearHuntGearsUnlock");
        RacePlatinumTime = serializedObject.FindProperty("RacePlatinumTime");
        RaceGoldTime = serializedObject.FindProperty("RaceGoldTime");
        RaceSilverTime = serializedObject.FindProperty("RaceSilverTime");
        RaceBronzeTime = serializedObject.FindProperty("RaceBronzeTime");
        RacePlatinumUnlock = serializedObject.FindProperty("RacePlatinumUnlock");
        RaceGoldUnlock = serializedObject.FindProperty("RaceGoldUnlock");
        RaceSilverUnlock = serializedObject.FindProperty("RaceSilverUnlock");
        RaceBronzeUnlock = serializedObject.FindProperty("RaceBronzeUnlock");
        missionSections = serializedObject.FindProperty("missionSections");
    }

    public override void OnInspectorGUI() {
        //base.OnInspectorGUI();

        //SceneGameModeMod s = target as SceneGameModeMod;

        //s.translatablePrefix = EditorGUILayout.TextField(/*"Translatable Prefix",*/ s.translatablePrefix);
        //s.translatableName = EditorGUILayout.TextField(s.translatableName);

        //s.gameMode = (NetworkGameSetup.NetworkGameType)EditorGUILayout.EnumPopup(s.gameMode);
        serializedObject.Update();

        EditorGUILayout.PropertyField(id);
        EditorGUILayout.PropertyField(translatablePrefix);
        EditorGUILayout.PropertyField(translatableName);
        EditorGUILayout.PropertyField(gameMode);
        EditorGUILayout.PropertyField(carSpawns);

        EditorGUILayout.PropertyField(gameModeObjects);
        EditorGUILayout.PropertyField(overrideMusicId);

        if (gameMode.enumValueIndex == (int)NetworkGameSetup.NetworkGameType.Race) {
            EditorGUILayout.PropertyField(RaceCheckpointTotal);
            EditorGUILayout.PropertyField(RaceSupportsLaps);
            EditorGUILayout.PropertyField(RaceIsFastCross);
        }

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(GearHuntUnlockKey);
        EditorGUILayout.PropertyField(GearHuntKeyUnlock);


        if (gameMode.enumValueIndex == (int)NetworkGameSetup.NetworkGameType.Gearhunt) {
            EditorGUILayout.PropertyField(GearHuntUnlockGears);
            if (GearHuntUnlockGears.boolValue) {
                EditorGUILayout.PropertyField(GearHuntGearsRequired);
                EditorGUILayout.PropertyField(GearHuntGearsUnlock);
            }
        }

        if (gameMode.enumValueIndex == (int)NetworkGameSetup.NetworkGameType.Race) {
            EditorGUILayout.PropertyField(RacePlatinumTime);
            EditorGUILayout.PropertyField(RaceGoldTime);
            EditorGUILayout.PropertyField(RaceSilverTime);
            EditorGUILayout.PropertyField(RaceBronzeTime);
            EditorGUILayout.PropertyField(RacePlatinumUnlock);
            EditorGUILayout.PropertyField(RaceGoldUnlock);
            EditorGUILayout.PropertyField(RaceSilverUnlock);
            EditorGUILayout.PropertyField(RaceBronzeUnlock);
        }

        if (gameMode.enumValueIndex == (int)NetworkGameSetup.NetworkGameType.Mission) {
            EditorGUILayout.PropertyField(missionSections);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
