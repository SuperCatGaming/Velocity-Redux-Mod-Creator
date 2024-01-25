using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MissionSubSectionMod))]
public class MSSMEditor : Editor
{

    SerializedProperty type;
    SerializedProperty active;
    SerializedProperty createAICar;
    SerializedProperty createClosingDoor;
    SerializedProperty handleCamera;
    SerializedProperty removeAllClosingDoors;
    SerializedProperty setGameActive;
    SerializedProperty showGameUI;
    SerializedProperty showModalPopup;
    SerializedProperty transition;
    SerializedProperty wait;
    SerializedProperty waitForAllEnemiesToBeKilled;

    private void OnEnable() {
        type = serializedObject.FindProperty("type");
        active = serializedObject.FindProperty("active");
        createAICar = serializedObject.FindProperty("createAICar");
        createClosingDoor = serializedObject.FindProperty("createClosingDoor");
        handleCamera = serializedObject.FindProperty("handleCamera");
        removeAllClosingDoors = serializedObject.FindProperty("removeAllClosingDoors");
        setGameActive = serializedObject.FindProperty("setGameActive");
        showGameUI = serializedObject.FindProperty("showGameUI");
        showModalPopup = serializedObject.FindProperty("showModalPopup");
        transition = serializedObject.FindProperty("transition");
        wait = serializedObject.FindProperty("wait");
        waitForAllEnemiesToBeKilled = serializedObject.FindProperty("waitForAllEnemiesToBeKilled");
    }

    public override void OnInspectorGUI() {
        //base.OnInspectorGUI();

        //SceneGameModeMod s = target as SceneGameModeMod;

        //s.translatablePrefix = EditorGUILayout.TextField(/*"Translatable Prefix",*/ s.translatablePrefix);
        //s.translatableName = EditorGUILayout.TextField(s.translatableName);

        //s.gameMode = (NetworkGameSetup.NetworkGameType)EditorGUILayout.EnumPopup(s.gameMode);
        serializedObject.Update();

        EditorGUILayout.PropertyField(type);

        switch (type.enumValueIndex) {
            case (int)MissionSubSectionMod.SubSectionType.CreateAICar:
                active.objectReferenceValue = createAICar.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.CreateClosingDoor:
                active.objectReferenceValue = createClosingDoor.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.HandleCamera:
                active.objectReferenceValue = handleCamera.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.RemoveAllClosingDoors:
                active.objectReferenceValue = removeAllClosingDoors.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.SetGameActive:
                active.objectReferenceValue = setGameActive.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.ShowGameUI:
                active.objectReferenceValue = showGameUI.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.ShowModalPopup:
                active.objectReferenceValue = showModalPopup.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.Transition:
                active.objectReferenceValue = transition.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.Wait:
                active.objectReferenceValue = wait.objectReferenceValue;
                break;
            case (int)MissionSubSectionMod.SubSectionType.WaitForAllEnemiesToBeKilled:
                active.objectReferenceValue = waitForAllEnemiesToBeKilled.objectReferenceValue;
                break;
        }

        EditorGUILayout.PropertyField(active);

        //switch (type.enumValueIndex) {
        //    case (int)MissionSubSectionMod.SubSectionType.CreateAICar:
        //        EditorGUILayout.PropertyField(createAICar);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.CreateClosingDoor:
        //        EditorGUILayout.PropertyField(createClosingDoor);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.HandleCamera:
        //        EditorGUILayout.PropertyField(handleCamera);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.RemoveAllClosingDoors:
        //        EditorGUILayout.PropertyField(removeAllClosingDoors);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.SetGameActive:
        //        EditorGUILayout.PropertyField(setGameActive);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.ShowGameUI:
        //        EditorGUILayout.PropertyField(showGameUI);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.ShowModalPopup:
        //        EditorGUILayout.PropertyField(showModalPopup);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.Transition:
        //        EditorGUILayout.PropertyField(transition);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.Wait:
        //        EditorGUILayout.PropertyField(wait);
        //        break;
        //    case (int)MissionSubSectionMod.SubSectionType.WaitForAllEnemiesToBeKilled:
        //        EditorGUILayout.PropertyField(waitForAllEnemiesToBeKilled);
        //        break;
        //}

        serializedObject.ApplyModifiedProperties();
    }
}
