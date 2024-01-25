#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataReference))]
public class CarDataDrawer : Editor {
    private bool carsFO = false;
    private Hash carsFOHash = new Hash();
    private bool rimsFO = false;
    //private Hash rimsFOHash = new Hash();
    private bool musicFO = false;
    //private Hash musicFOHash = new Hash();
    private DataReference script;
    private GUIStyle indent1Text;
    private GUIStyle indent1;
    private GUIStyle indent2;
    private GUIStyle indent3;
    private GUIStyle indent4;
    private GUIStyle indent5Text;

    private bool init = false;
    private void Init() {
        if (!init) {
            script = (DataReference)target;
            script.LoadData();

            indent1Text = new GUIStyle(EditorStyles.label);
            indent1Text.padding = new RectOffset(20, 0, 0, 0);
            indent1 = new GUIStyle(EditorStyles.foldout);
            indent1.margin = new RectOffset(10, 0, 0, 0);
            indent2 = new GUIStyle(EditorStyles.foldout);
            indent2.margin = new RectOffset(20, 0, 0, 0);
            indent3 = new GUIStyle(EditorStyles.foldout);
            indent3.margin = new RectOffset(25, 0, 0, 0);
            indent4 = new GUIStyle(EditorStyles.foldout);
            indent4.margin = new RectOffset(30, 0, 0, 0);
            indent5Text = new GUIStyle(EditorStyles.label);
            indent5Text.padding = new RectOffset(50, 0, 0, 0);
            init = true;
        }
    }
    public override void OnInspectorGUI() {
        Init();
        EditorGUILayout.HelpBox("This script gives you some information about the base game", MessageType.Info);

        if (carsFO = EditorGUILayout.Foldout(carsFO, "Cars", true)) {
            foreach (DataReference.CarData carData in DataReference.carData) {
                if (carsFOHash[carData, 0] = CopyFoldout(carData.id, carsFOHash[carData, 0], carData.id, true, indent1)) {
                    if (carsFOHash[carData, 1] = EditorGUILayout.Foldout(carsFOHash[carData, 1], "Skins", true, indent2)) {
                        foreach (DataReference.CarData.Skin skin in carData.skins) {
                            if (carsFOHash[carData, skin] = CopyFoldout(skin.id, carsFOHash[carData, skin], skin.name + $" ({skin.id})", true, indent3)) {
                                foreach (DataReference.CarData.Skin.Data data in skin.data) {
                                    if (carsFOHash[carData, skin, data] = EditorGUILayout.Foldout(carsFOHash[carData, skin, data], data.name, true, indent4)) {
                                        foreach (string s in data.materials) {
                                            EditorGUILayout.LabelField(s, indent5Text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (rimsFO = EditorGUILayout.Foldout(rimsFO, "Rims", true)) {
            foreach (DataReference.RimData rimData in DataReference.rimData) {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(rimData.id, indent1Text);

                CopyButton(rimData.id);

                EditorGUILayout.EndHorizontal();
            }
        }

        if (musicFO = EditorGUILayout.Foldout(musicFO, "Music", true)) {
            foreach (DataReference.MusicData musicData in DataReference.musicData) {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(musicData.id, indent1Text);

                CopyButton(musicData.id);

                EditorGUILayout.EndHorizontal();
            }
        }
    }

    private void CopyButton(string text) {
        if (EditorGUILayout.LinkButton("Copy to clipboard")) {
            GUIUtility.systemCopyBuffer = text;
            Debug.Log("Copied " + text + " to clipboard");
        }
    }

    private bool CopyFoldout(string copyText, bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style) {
        EditorGUILayout.BeginHorizontal();
        bool ret = EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick, style);
        CopyButton(copyText);
        EditorGUILayout.EndHorizontal();

        return ret;
    }
}

class Hash {
    Hashtable table = new Hashtable();

    public bool Get(object o, int i) {
        object ret = table[o];
        if (ret != null) return ((bool[])ret)[i];
        else {
            table[o] = new bool[] { false, false };
            return false;
        }
    }

    public bool GetSpecial(object o) {
        object ret = table[o];
        if (ret != null) return (bool)ret;
        else {
            table[o] = false;
            return false;
        }
    }

    public bool this[DataReference.CarData car, int i] {
        get { return Get(car.name, i); }
        set {
            bool[] set = (bool[])table[car.name];
            set[i] = value;
            table[car.name] = set;
        }
    }

    public bool this[DataReference.CarData car, DataReference.CarData.Skin skin] {
        get { return GetSpecial(car.name + skin.name); }
        set {
            table[car.name + skin.name] = value;
        }
    }

    public bool this[DataReference.CarData car, DataReference.CarData.Skin skin, DataReference.CarData.Skin.Data data] {
        get { return GetSpecial(car.name + skin.name + data.name); }
        set {
            table[car.name + skin.name + data.name] = value;
        }
    }
}

#endif
