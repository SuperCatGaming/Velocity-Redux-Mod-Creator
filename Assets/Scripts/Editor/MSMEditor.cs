using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


[CustomEditor(typeof(MissionSectionMod))]
public class MSMEditor : Editor
{

    SerializedProperty sectionTitle;
    SerializedProperty sectionTimeLimit;
    SerializedProperty sectionObjects;
    SerializedProperty sectionGoal;
    SerializedProperty goalObject;
    SerializedProperty enemyCount;
    SerializedProperty subSections;

    ReorderableList subsectionList;
    float lineHeight;
    float lineHeightSpace;

    List<bool> foldouts = new List<bool>();
    List<float> prevHeight = new List<float>();

    private void OnEnable() {
        sectionTitle = serializedObject.FindProperty("sectionTitle");
        sectionTimeLimit = serializedObject.FindProperty("sectionTimeLimit");
        sectionObjects = serializedObject.FindProperty("sectionObjects");
        sectionGoal = serializedObject.FindProperty("sectionGoal");
        goalObject = serializedObject.FindProperty("goalObject");
        enemyCount = serializedObject.FindProperty("enemyCount");
        subSections = serializedObject.FindProperty("subSections");

        lineHeight = EditorGUIUtility.singleLineHeight;
        lineHeightSpace = lineHeight + 5;
        subsectionList = new ReorderableList(serializedObject, subSections, true, true, true, true);

        subsectionList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Sub Sections");
        };

        subsectionList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            while (foldouts.Count < subsectionList.count) {
                foldouts.Add(false);
            }
            while (prevHeight.Count < subsectionList.count) {
                prevHeight.Add(0);
            }
            if (foldouts.Count > subsectionList.count) {
                foldouts.RemoveRange(subsectionList.count, foldouts.Count - subsectionList.count);
            }
            if (prevHeight.Count > subsectionList.count) {
                prevHeight.RemoveRange(subsectionList.count, prevHeight.Count - subsectionList.count);
            }

            float height = 0;
            
            SerializedProperty element = subsectionList.serializedProperty.GetArrayElementAtIndex(index);
            
            MissionSubSectionMod mssm = (MissionSubSectionMod)GetTargetObjectOfProperty(element);

            string name = mssm.GetTitle();

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, lineHeight), element.FindPropertyRelative("type"));
            EditorGUI.indentLevel++;
            height += lineHeightSpace;
            if (foldouts[index] = EditorGUI.Foldout(new Rect(rect.x, rect.y + height, rect.width, lineHeight), foldouts[index], name)) {
                height += lineHeightSpace;
                EditorGUI.indentLevel++;
                SerializedProperty prop;
                switch (mssm.type) {
                    case MissionSubSectionMod.SubSectionType.CreateAICar:
                        prop = element.FindPropertyRelative("createAICar");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("car"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("skin"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("rims"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("weaponIndex"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("spawnPosition"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("spawnRotation"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("healthPercentage"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("requireKill"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.CreateClosingDoor:
                        prop = element.FindPropertyRelative("createClosingDoor");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("position"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("rotation"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("permanent"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.HandleCamera:
                        prop = element.FindPropertyRelative("handleCamera");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        SerializedProperty camFoc = prop.FindPropertyRelative("cameraFocus");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), camFoc);
                        height += lineHeightSpace;
                        if (camFoc.enumValueIndex == (int)MSS_HandleCamera.CameraFocus.DetachCamera) {
                            EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("cameraPosition"));
                            height += lineHeightSpace;
                            EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("cameraRotation"));
                            height += lineHeightSpace;
                        } else if (camFoc.enumValueIndex == (int)MSS_HandleCamera.CameraFocus.AttachAI) {
                            EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("aiIndex"));
                            height += lineHeightSpace;
                        }
                        SerializedProperty camOrb = prop.FindPropertyRelative("cameraOrbit");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), camOrb);
                        height += lineHeightSpace;
                        if (camOrb.boolValue) {
                            EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("orbitSpeed"));
                            height += lineHeightSpace;
                        }
                        break;
                    case MissionSubSectionMod.SubSectionType.RemoveAllClosingDoors:
                        prop = element.FindPropertyRelative("removeAllClosingDoors");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.SetGameActive:
                        prop = element.FindPropertyRelative("setGameActive");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("active"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.ShowGameUI:
                        prop = element.FindPropertyRelative("showGameUI");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("show"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.ShowModalPopup:
                        prop = element.FindPropertyRelative("showModalPopup");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("header"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("body"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("duration"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.Transition:
                        prop = element.FindPropertyRelative("transition");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("transitionType"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("transitionDuration"));
                        height += lineHeightSpace;
                        break;
                    default:
                    case MissionSubSectionMod.SubSectionType.Wait:
                        prop = element.FindPropertyRelative("wait");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("time"));
                        height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.WaitForAllEnemiesToBeKilled:
                        prop = element.FindPropertyRelative("waitForAllEnemiesToBeKilled");
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("name"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("waitToFinish"));
                        height += lineHeightSpace;
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop.FindPropertyRelative("active"));
                        height += lineHeightSpace;
                        break;
                }

                //Enumerator and NextVisible() have a ton of side effects and
                //does not work intuitively

                //IEnumerator enumerator = prop.GetEnumerator();
                //Debug.Log(prop.CountInProperty());
                //prop.NextVisible(true);
                //do {
                //    EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop);

                //    //int i = ((SerializedProperty)enumerator.Current).CountRemaining();
                //    //if (i > 0)
                //    //Debug.Log("Skipping " + i);
                //    //for (; i > 0; i--) {
                //    //    if (!enumerator.MoveNext()) break;
                //    //}
                //    height += lineHeightSpace;
                //} while (prop.NextVisible(false));
                //EditorGUI.PropertyField(new Rect(rect.x, rect.y + height, rect.width, lineHeight), prop);
                EditorGUI.indentLevel--;
            } else
            height += lineHeight;

            EditorGUI.indentLevel--;
            prevHeight[index] = height;
        };

        subsectionList.elementHeightCallback = (int index) => {

            float height = 0;

            SerializedProperty element = subsectionList.serializedProperty.GetArrayElementAtIndex(index);

            MissionSubSectionMod mssm = (MissionSubSectionMod)GetTargetObjectOfProperty(element);

            height += lineHeightSpace;
            if (foldouts.Count > index && foldouts[index]) {
                height += lineHeightSpace;
                switch (mssm.type) {
                    case MissionSubSectionMod.SubSectionType.CreateAICar:
                        height += lineHeightSpace * 10;
                        break;
                    case MissionSubSectionMod.SubSectionType.CreateClosingDoor:
                        height += lineHeightSpace * 5;
                        break;
                    case MissionSubSectionMod.SubSectionType.HandleCamera:
                        height += lineHeightSpace * 4;
                        SerializedProperty prop = element.FindPropertyRelative("handleCamera");
                        SerializedProperty camFoc = prop.FindPropertyRelative("cameraFocus");
                        if (camFoc.enumValueIndex == (int)MSS_HandleCamera.CameraFocus.DetachCamera) {
                            height += lineHeightSpace * 2;
                        } else if (camFoc.enumValueIndex == (int)MSS_HandleCamera.CameraFocus.AttachAI) {
                            height += lineHeightSpace;
                        }
                        SerializedProperty camOrb = prop.FindPropertyRelative("cameraOrbit");
                        if (camOrb.boolValue) height += lineHeightSpace;
                        break;
                    case MissionSubSectionMod.SubSectionType.RemoveAllClosingDoors:
                        height += lineHeightSpace * 2;
                        break;
                    case MissionSubSectionMod.SubSectionType.SetGameActive:
                        height += lineHeightSpace * 3;
                        break;
                    case MissionSubSectionMod.SubSectionType.ShowGameUI:
                        height += lineHeightSpace * 3;
                        break;
                    case MissionSubSectionMod.SubSectionType.ShowModalPopup:
                        height += lineHeightSpace * 5;
                        break;
                    case MissionSubSectionMod.SubSectionType.Transition:
                        height += lineHeightSpace * 4;
                        break;
                    default:
                    case MissionSubSectionMod.SubSectionType.Wait:
                        height += lineHeightSpace * 3;
                        break;
                    case MissionSubSectionMod.SubSectionType.WaitForAllEnemiesToBeKilled:
                        height += lineHeightSpace * 3;
                        break;
                }
            } else height += lineHeight;

            return height;
        };
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(sectionTitle);
        EditorGUILayout.PropertyField(sectionTimeLimit);
        EditorGUILayout.PropertyField(sectionObjects);
        EditorGUILayout.PropertyField(sectionGoal);



        switch (sectionGoal.enumValueIndex) {
            case (int)MissionSectionMod.SectionGoal.ReachTrigger:
                EditorGUILayout.PropertyField(goalObject);
                break;
            case (int)MissionSectionMod.SectionGoal.DestroyAllEnemies:
                EditorGUILayout.PropertyField(enemyCount);
                break;
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        subsectionList.DoLayoutList();

        //EditorGUILayout.PropertyField(subSections);
        serializedObject.ApplyModifiedProperties();
    }



    //The following methods are from https://github.com/lordofduct/spacepuppy-unity-framework/blob/master/SpacepuppyBaseEditor/EditorHelper.cs

    /// <summary>
    /// Gets the object the property represents.
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public static object GetTargetObjectOfProperty(SerializedProperty prop) {
        if (prop == null) return null;

        var path = prop.propertyPath.Replace(".Array.data[", "[");
        object obj = prop.serializedObject.targetObject;
        var elements = path.Split('.');
        foreach (var element in elements) {
            if (element.Contains("[")) {
                var elementName = element.Substring(0, element.IndexOf("["));
                var index = System.Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                obj = GetValue_Imp(obj, elementName, index);
            } else {
                obj = GetValue_Imp(obj, element);
            }
        }
        return obj;
    }

    private static object GetValue_Imp(object source, string name) {
        if (source == null)
            return null;
        var type = source.GetType();

        while (type != null) {
            var f = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (f != null)
                return f.GetValue(source);

            var p = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p != null)
                return p.GetValue(source, null);

            type = type.BaseType;
        }
        return null;
    }

    private static object GetValue_Imp(object source, string name, int index) {
        if (GetValue_Imp(source, name) is not IEnumerable enumerable) return null;
        var enm = enumerable.GetEnumerator();
        //while (index-- >= 0)
        //    enm.MoveNext();
        //return enm.Current;

        for (int i = 0; i <= index; i++) {
            if (!enm.MoveNext()) return null;
        }
        return enm.Current;
    }
}
