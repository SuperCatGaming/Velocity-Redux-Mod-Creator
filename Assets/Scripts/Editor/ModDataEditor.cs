using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ModData))]
public class ModDataEditor : Editor
{
    SerializedProperty translatable;
    SerializedProperty id;
    SerializedProperty title;
    SerializedProperty author;
    SerializedProperty version;
    SerializedProperty description;
    SerializedProperty image;
    SerializedProperty dependencies;

    ReorderableList dependencyList;

    bool useDefaultID = true;

    IDValidity idError;
    VersionValidity versionError;

    string lastValidId;
    string lastValidVersion;
    string lastValidTitle;
    string lastValidAuthor;

    float lineHeight;

    public const string sceneTail = "modscenes";
    public const string sceneDataTail = "modscenedata";

    private void OnEnable() {
        translatable = serializedObject.FindProperty("_translatable");
        id = serializedObject.FindProperty("_id");
        title = serializedObject.FindProperty("_title");
        author = serializedObject.FindProperty("_author");
        version = serializedObject.FindProperty("_version");
        description = serializedObject.FindProperty("_description");
        image = serializedObject.FindProperty("_image");
        dependencies = serializedObject.FindProperty("_dependencies");

        lineHeight = EditorGUIUtility.singleLineHeight;

        dependencyList = new ReorderableList(serializedObject, dependencies, true, true, true, true);

        dependencyList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Dependencies");
        };

        dependencyList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            SerializedProperty element = dependencyList.serializedProperty.GetArrayElementAtIndex(index);
            SerializedProperty elmId = element.FindPropertyRelative("_id");
            SerializedProperty elmVer = element.FindPropertyRelative("_version");

            //GUI.SetNextControlName("ID" + index);
            elmId.stringValue = EditorGUI.TextField(new Rect(rect.x, rect.y, rect.width, lineHeight), "ID", elmId.stringValue);
            //GUI.SetNextControlName("Version" + index);
            elmVer.stringValue = EditorGUI.TextField(new Rect(rect.x, rect.y + lineHeight, rect.width, lineHeight), "Version", elmVer.stringValue);


        };

        dependencyList.elementHeightCallback = (int index) => {
            return lineHeight * 2;
        };
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.HelpBox("Try to make the ID unique to you and this mod. For example, you could use \"username.mod_name\"", MessageType.Info);

        //image = (Sprite)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 60), "Icon", data._image, typeof(Sprite), false);


        EditorGUILayout.PropertyField(translatable);
        if (!translatable.boolValue) useDefaultID = EditorGUILayout.Toggle("Use Default ID", useDefaultID);

        if (!translatable.boolValue && useDefaultID) {
            id.stringValue = FullIDRegex(author.stringValue) + "." + FullIDRegex(title.stringValue);
            if (GUI.GetNameOfFocusedControl() == "ID") GUI.FocusControl("");
        }

        //Only allow valid ids
        GUI.SetNextControlName("ID");
        id.stringValue = EditorGUILayout.TextField("ID", id.stringValue).ToLower().Trim();
        idError = CheckID(id.stringValue);

        if (idError == IDValidity.Valid) {
            lastValidId = id.stringValue;
        }

        if (GUI.GetNameOfFocusedControl() != "ID") {
            if (id.stringValue != lastValidId) {
                id.stringValue = lastValidId;
            }
        }

        if (idError == IDValidity.InvalidChar) EditorGUILayout.HelpBox("ID may only contain lowercase letters, numbers, \"_\", and \".\"", MessageType.Warning);
        if (idError == IDValidity.StartLetter) EditorGUILayout.HelpBox("ID must start with a letter", MessageType.Warning);
        if (idError == IDValidity.EndUnderscore) EditorGUILayout.HelpBox("ID cannot end with \"_\" or \".\"", MessageType.Warning);
        if (idError == IDValidity.SceneTail) EditorGUILayout.HelpBox("ID cannot end with " + sceneTail, MessageType.Warning);
        if (idError == IDValidity.SceneDataTail) EditorGUILayout.HelpBox("ID cannot end with " + sceneDataTail, MessageType.Warning);
        if (idError == IDValidity.Empty) EditorGUILayout.HelpBox("ID cannot be empty", MessageType.Warning);

        GUI.SetNextControlName("Title");
        title.stringValue = EditorGUILayout.TextField("Title", title.stringValue);

        if (string.IsNullOrWhiteSpace(title.stringValue)) {
            if (GUI.GetNameOfFocusedControl() != "Title") title.stringValue = lastValidTitle;
            EditorGUILayout.HelpBox("Title should not be blank", MessageType.Warning);
        } else lastValidTitle = title.stringValue;

        GUI.SetNextControlName("Author");
        author.stringValue = EditorGUILayout.TextField("Author", author.stringValue);

        if (string.IsNullOrWhiteSpace(author.stringValue)) {
            if (GUI.GetNameOfFocusedControl() != "Author") author.stringValue = lastValidAuthor;
            EditorGUILayout.HelpBox("Author should not be blank", MessageType.Warning);
        } else lastValidAuthor = author.stringValue;

        GUI.SetNextControlName("Version");
        version.stringValue = EditorGUILayout.TextField("Version", version.stringValue).ToLower().Trim();
        versionError = CheckVersion(version.stringValue);

        if (versionError == VersionValidity.Valid) {
            lastValidVersion = version.stringValue;
        }

        if (GUI.GetNameOfFocusedControl() != "Version") {
            if (version.stringValue != lastValidVersion) {
                version.stringValue = lastValidVersion;
            }
        }

        if (versionError == VersionValidity.InvalidChar) EditorGUILayout.HelpBox("Version may only contain lowercase letters, numbers, \"_\" and \".\"", MessageType.Warning);
        if (versionError == VersionValidity.StartEndInvalid) EditorGUILayout.HelpBox("Version cannot start or end with \"_\" or \".\"", MessageType.Warning);
        if (versionError == VersionValidity.Double) EditorGUILayout.HelpBox("Version cannot contain \"..\", \"._\", \"_.\", or \"__\"", MessageType.Warning);
        if (versionError == VersionValidity.Empty) EditorGUILayout.HelpBox("Version cannot be empty", MessageType.Warning);

        EditorGUILayout.LabelField("Description");
        description.stringValue = EditorGUILayout.TextArea(description.stringValue);
        EditorGUILayout.PropertyField(image);

        EditorGUILayout.HelpBox("Each dependency must be valid, or the mod will fail to load. For the version field, an '*' can be used only at the end to signify any version matching the first part. (Ex. \"0.1.*\" will work with 0.1.0, 0.1.1, etc.)", MessageType.Info);
        EditorGUILayout.Space();
        dependencyList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }

    public static void Render() {

    }

    public static IDValidity CheckID(string id) {
        if (id == "") return IDValidity.Empty;
        if (id != RegexID(id)) return IDValidity.InvalidChar;
        if (id != TrimID(id)) return IDValidity.EndUnderscore;
        if (Regex.IsMatch(id[0].ToString(), @"[^a-z]")) return IDValidity.StartLetter;
        if (id.EndsWith(sceneTail)) return IDValidity.SceneTail;
        if (id.EndsWith(sceneDataTail)) return IDValidity.SceneDataTail;
        return IDValidity.Valid;
    }

    public static string RegexID(string str) {
        if (str == null) return "";
        return Regex.Replace(str, @"[^a-z0-9_.]", "_");
    }

    public static string TrimID(string str) {
        //remove trailing _
        if (str == null) return "";
        return Regex.Replace(str, @"([_.]+$)", "");
    }

    public static string FullIDRegex(string id) {
        return Regex.Replace(RegexID(id.ToLower().Trim()), @"([_.]+$)|(_(?=_))", "");
    }

    public enum IDValidity {
        Valid,
        InvalidChar,
        StartLetter,
        EndUnderscore,
        SceneTail,
        SceneDataTail,
        Empty
    }


    public static VersionValidity CheckVersion(string version) {
        if (version == "") return VersionValidity.Empty;
        if (version != RegexVersion(version)) return VersionValidity.InvalidChar;
        if (version != TrimVersion(version)) return VersionValidity.StartEndInvalid;
        if (version != VersionRemoveDouble(version)) return VersionValidity.Double;
        return VersionValidity.Valid;
    }

    public static string RegexVersion(string str) {
        if (str == null) return "";
        return Regex.Replace(str, @"[^a-z0-9_.]", "_");
    }

    public static string TrimVersion(string str) {
        //remove beginning or trailing _ or .
        if (str == null) return "";
        return Regex.Replace(str, @"([_.]+$)|(^[_.]+)", "");
    }

    public static string VersionRemoveDouble(string str) {
        //remove double _ or ., including _. and ._
        if (str == null) return "";
        return Regex.Replace(str, @"(_(?=[_.]))|(\.(?=[_.]))", "");
    }

    public static string FullVersionRegex(string id) {
        return VersionRemoveDouble(TrimVersion(RegexID(id.ToLower().Trim())));
    }

    public enum VersionValidity {
        Valid,
        InvalidChar,
        StartEndInvalid,
        Double,
        Empty
    }

}
