using System;
using UnityEngine;
using UnityEditor;

public class TireMod : MonoBehaviour {
    public string tire;
    public void SetAsTire(string tire) {
        GameObject newTire = Instantiate(BundleSupport.GetBundle().LoadAsset<GameObject>($"Assets/Models/CarStuff/Tires/{ tire }.fbx"), transform.parent);
        newTire.name = "Tire";
        newTire.AddComponent<TireMod>().tire = tire;
        DestroyImmediate(gameObject, true);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TireMod))]
public class SoundInEditorDrawer : Editor {
    private TireMod script;
    private void OnEnable() {
        script = (TireMod)target;
    }


    //TODO: write a script that creates this script
    public override void OnInspectorGUI() {
        string choice = script.tire;
        if (choice == null || choice.Length == 0) choice = "NONE";
        GUILayout.Label("The tire will disappear upon reopening the prefab; this is normal.");
        GUILayout.Label($"You do not need to reclick the button; your choice is { choice }.");
        GUILayout.Label("If you choose to use a custom tire, remove this game object.");

        if (GUILayout.Button("Add Tire")) script.SetAsTire("Tire");
        if (GUILayout.Button("Add Thin Slicks")) script.SetAsTire("ThinSlicksTire");
        if (GUILayout.Button("Add Thick Slicks")) script.SetAsTire("ThickSlicksTire");
        if (GUILayout.Button("Add Sweeper Tire")) script.SetAsTire("SweeperTire");
        if (GUILayout.Button("Add Screamin Tire")) script.SetAsTire("ScreaminTire");
        if (GUILayout.Button("Add PUMA Tire")) script.SetAsTire("PUMATireVRX");
        if (GUILayout.Button("Add Off Road Tire")) script.SetAsTire("OffRoadTire");
        if (GUILayout.Button("Add HO Tire")) script.SetAsTire("HOTire");
        if (GUILayout.Button("Add HH TIre")) script.SetAsTire("HHTire");
        if (GUILayout.Button("Add CTS Tire")) script.SetAsTire("CTSTire");
        if (GUILayout.Button("Add Corgi Slicks")) script.SetAsTire("CorgiSlicksTire");
    }

}
#endif