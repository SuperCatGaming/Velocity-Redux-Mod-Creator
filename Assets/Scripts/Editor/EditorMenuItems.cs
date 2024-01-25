using UnityEditor;
using System.IO;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System;
using Unity.SharpZipLib.Zip;
using System.Security.Cryptography;

public class EditorMenuItems {

    const string sceneTail = "modscenes";
    const string sceneDataTail = "modscenedata";

    const string builtModsDir = "Assets/Built Mods/";
    const string assetBundleDirectory = builtModsDir + "Bundles";
    const string zipDirectory = builtModsDir + "Zip";

    [MenuItem("Assets/Mods/Build Mods")]
    static void BuildAllAssetBundles() {
        AssetDatabase.RemoveUnusedAssetBundleNames();
        if (!Directory.Exists(assetBundleDirectory)) {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        if (!Directory.Exists(zipDirectory)) {
            Directory.CreateDirectory(zipDirectory);
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        Debug.Log("Finished building mods... Now moving into Mods folder.");
        string[] names = AssetDatabase.GetAllAssetBundleNames();

        foreach (string name in names) {
            if (name.EndsWith(sceneTail)) continue;
            if (name.EndsWith(sceneDataTail)) continue;

            if (File.Exists(Path.Combine(assetBundleDirectory, name))) {
                string zipFile = Path.Combine(zipDirectory, name + ".zip");
                ZipFile zip = ZipFile.Create(zipFile);
                zip.BeginUpdate();
                using (var sha = SHA256.Create()) {
                    string file = Path.Combine(assetBundleDirectory, name);
                    byte[] hash;
                    zip.Add(file, name);
                    using (var stream = File.OpenRead(file)) {
                        hash = sha.ComputeHash(stream);
                    }
                    //printHash(hash);
                    //string pw = BitC
                    file = Path.Combine(assetBundleDirectory, name + sceneTail);
                    if (File.Exists(file)) {
                        zip.Add(file, name + sceneTail);
                        using (var stream = File.OpenRead(file)) {
                            hash = Combine(hash, sha.ComputeHash(stream));
                            //printHash(newHash);
                        }

                        file = Path.Combine(assetBundleDirectory, name + sceneDataTail);
                        if (File.Exists(file)) {
                            zip.Add(file, name + sceneDataTail);
                            using (var stream = File.OpenRead(file)) {
                                hash = Combine(hash, sha.ComputeHash(stream));
                                //printHash(newHash);
                            }
                        }
                    }


                    //printHash(hash);
                    // If hash size is greater than 256 bytes, it must have been appended; rehash.
                    if (hash.Length > 256) hash = sha.ComputeHash(hash);

                    zip.Password = Convert.ToBase64String(hash);

                    zip.CommitUpdate();
                    zip.Close();

                    // Encrypt password and package with mod

                    // gather public key
                    string publicKey = File.ReadAllText("Assets/Resources/public.key");
                    var reader = new StringReader(publicKey);
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    var pubKey = (RSAParameters)xs.Deserialize(reader);

                    var csp = new RSACryptoServiceProvider();
                    csp.ImportParameters(pubKey);

                    byte[] cypher = csp.Encrypt(hash, false);
                    //printHash(cypher);

                    string path = Path.Combine(builtModsDir, name + ".vrx");
                    if (File.Exists(path)) {
                        File.Delete(path);
                    }
                    FileStream fs = File.Create(path);
                    fs.Write(cypher);
                    fs.Write(File.ReadAllBytes(zipFile));
                    fs.Close();
                }
            }
        }
        Debug.Log("Complete!");
    }

    private static byte[] Combine(byte[] b1, byte[] b2) {
        byte[] ret = new byte[b1.Length + b2.Length];

        Array.Copy(b1, ret, b1.Length);
        Array.Copy(b2, 0, ret, b1.Length, b2.Length);
        return ret;
    }

    private static void printHash(byte[] hash) {
        Debug.Log(Convert.ToBase64String(hash));
        Debug.Log(BitConverter.ToString(hash));
        Debug.Log(hash.Length);
    }

    [MenuItem("Assets/Mods/Create New Mod")]
    static void CreateNewMod() {
        ModDetailsPrompt p = ScriptableObject.CreateInstance<ModDetailsPrompt>();
        p.data = ScriptableObject.CreateInstance<ModData>();
        p.missing = Resources.Load<Sprite>("Textures/UI/194.png");
        p.Show();
    }

    static void CreatePrefabWithSelection(Action method) {
        if (Selection.activeGameObject != null) {
            string path = AssetDatabase.GetAssetPath(Selection.activeGameObject);
            if (path.EndsWith(".prefab")) {
                if (!EditorUtility.DisplayDialog("Warning", "The selected object looks like a prefab; prefabs shouldn't be used to create a prefab, you should use a model.", "Ok", "I know what I'm doing")) {
                    method();
                } else return;
            } else if (path.EndsWith(".fbx")) {
                method();
            } else if (PrefabUtility.GetPrefabAssetType(Selection.activeGameObject) == PrefabAssetType.Model) {
                if (!EditorUtility.DisplayDialog("Warning", "The selected object isn't a tested model type. It may work, it may not. Only the .fbx format is tested.", "Accept", "Cancel")) {
                    method();
                } else return;
            } else if (EditorUtility.DisplayDialog("Warning", "The selected object doesn't seem like a model...", "I know what I'm doing", "Cancel")) {
                method();
            } else return;
        } else method();
    }

    //[MenuItem("Assets/Automated Creation")]
    //static void AutoCreate() {
    //    for (char c = 'f'; c <= 'z'; c++) {
    //        string title = "test_" + c;

    //        string path = Path.Combine("Assets/LetterTests", title.ToLower());
    //        if (File.Exists(path)) {
    //            EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ title }\" already exists.", "Close");
    //            return;
    //        }
    //        try {
    //            string modFolder = AssetDatabase.CreateFolder("Assets/LetterTests", title.ToLower());
    //            if (modFolder == "") {
    //                EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ title }\" could not be created.", "Close");
    //                return;
    //            }
    //            modFolder = AssetDatabase.CreateFolder(path, "Mod");
    //            if (modFolder == "") {
    //                EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ title }\" could not be created.", "Close");
    //                return;
    //            }

    //            var imp = AssetImporter.GetAtPath(Path.Combine(path, "Mod"));
    //            imp.assetBundleName = title;
    //            path = Path.Combine(path, "Mod");
    //            ModData data = new ModData();
    //            data._title = "Test " + c.ToString().ToUpper();
    //            data._id = "vrx.test_" + c;
    //            data._author = "vrx";
    //            data._version = "0";
    //            AssetDatabase.CreateAsset(data, Path.Combine(path, "mod.asset"));

    //        } catch (Exception e) {
    //            EditorUtility.DisplayDialog("Unable to create mod", $"An error occurred: { e.Message }.", "Close");
    //            Debug.LogException(e);
    //            return;
    //        }
    //    }

    //    AssetDatabase.Refresh();
    //}

    [MenuItem("Assets/Create/Mods/Rim Prefab")]
    static void CreateRimPrefab() {
        CreatePrefabWithSelection(RimPrefab);
    }

    [MenuItem("Assets/Create/Mods/Car Prefab")]
    static void CreateCarPrefab() {
        CreatePrefabWithSelection(CarPrefab);
    }

    private static void CarPrefab() {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        GameObject gameObject = new GameObject("RENAME_ME");

        if (!Directory.Exists(path)) {
            path = Directory.GetParent(path).FullName;
            Debug.Log(path);
            int start = path.IndexOf("/Assets/");
            if (start == -1) start = path.IndexOf("\\Assets\\");
            if (start == -1) {
                EditorUtility.DisplayDialog("Error", $"Could not find Assets folder in path { path }...", "Ok");
                return;
            }
            path = path.Substring(start + 1);
            Debug.Log(path);
        }

        Rigidbody b = gameObject.AddComponent<Rigidbody>();
        b.mass = 1800; //TODO: check other cars
        b.useGravity = false;
        b.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        CarMoveMod carMove = gameObject.AddComponent<CarMoveMod>();


        GameObject lights = new GameObject("Vehicle Lights");
        GameObject headlights = Resources.Load<GameObject>("Prefabs/CarStuff/HeadLights");
        GameObject taillights = Resources.Load<GameObject>("Prefabs/CarStuff/TailLights");
        GameObject boostlights = Resources.Load<GameObject>("Prefabs/CarStuff/BoostLight");
        GameObject damageSmoke = Resources.Load<GameObject>("Prefabs/CarStuff/DamageSmoke");
        PrefabUtility.InstantiatePrefab(headlights, lights.transform);
        PrefabUtility.InstantiatePrefab(taillights, lights.transform);
        PrefabUtility.InstantiatePrefab(boostlights, lights.transform);
        PrefabUtility.InstantiatePrefab(damageSmoke, lights.transform);

        lights.transform.parent = gameObject.transform;

        GameObject wheelCol = new GameObject("Wheel Colliders");
        GameObject wheelLF = new GameObject("WheelLF");
        GameObject wheelRF = new GameObject("WheelRF");
        GameObject wheelLB = new GameObject("WheelLB");
        GameObject wheelRB = new GameObject("WheelRB");

        wheelLF.transform.position = new Vector3(-0.3f, 0.396f, 0.5f);
        wheelRF.transform.position = new Vector3(0.3f, 0.396f, 0.5f);
        wheelLB.transform.position = new Vector3(-0.3f, 0.396f, -0.5f);
        wheelRB.transform.position = new Vector3(0.3f, 0.396f, -0.5f);
        GameObject[] wheels = { wheelLF, wheelRF, wheelLB, wheelRB };

        JointSpring spring = new JointSpring {
            spring = 50000,
            damper = 20000
        };
        WheelFrictionCurve forward = new WheelFrictionCurve {
            extremumSlip = 0.4f,
            extremumValue = 1,
            asymptoteSlip = 0.8f,
            asymptoteValue = 0.5f,
            stiffness = 4
        };
        WheelFrictionCurve sideways = new WheelFrictionCurve {
            extremumSlip = 0.2f,
            extremumValue = 0.5f,
            asymptoteSlip = 1f,
            asymptoteValue = 0.8f,
            stiffness = 5
        };


        for (int i = 0; i < wheels.Length; i++) {
            wheels[i].transform.parent = wheelCol.transform;
            WheelCollider col = wheels[i].AddComponent<WheelCollider>();
            col.radius = 0.22f; //todo check other cars
            col.wheelDampingRate = 2.3f;
            col.suspensionDistance = 0.1f;
            col.suspensionSpring = spring;
            col.forwardFriction = forward;
            col.sidewaysFriction = sideways;
        }

        wheelCol.transform.parent = gameObject.transform;

        GameObject models = new GameObject("Models");
        GameObject widthOverride = new GameObject("WheelWidthOverride");
        GameObject wheel = Resources.Load<GameObject>("Prefabs/CarStuff/Wheel");
        PrefabUtility.InstantiatePrefab(wheel, widthOverride.transform).name = "WheelLeftFront";
        GameObject curWheel = (GameObject)PrefabUtility.InstantiatePrefab(wheel, widthOverride.transform);
        curWheel.name = "WheelLeftBack";
        curWheel.transform.position = new Vector3(curWheel.transform.position.x, curWheel.transform.position.y, -0.49f);
        curWheel = (GameObject)PrefabUtility.InstantiatePrefab(wheel, widthOverride.transform);
        curWheel.name = "WheelRightFront";
        curWheel.transform.position = new Vector3(0.42f, curWheel.transform.position.y, curWheel.transform.position.z);
        curWheel = (GameObject)PrefabUtility.InstantiatePrefab(wheel, widthOverride.transform);
        curWheel.name = "WheelRightBack";
        curWheel.transform.position = new Vector3(0.42f, curWheel.transform.position.y, -0.49f);
        widthOverride.transform.parent = models.transform;
        models.transform.parent = gameObject.transform;

        if (Selection.activeGameObject != null) {
            GameObject model = (GameObject)PrefabUtility.InstantiatePrefab(Selection.activeGameObject, models.transform);
            BoxCollider box = model.AddComponent<BoxCollider>();
            box.material = Resources.Load<PhysicMaterial>("Physic Materials/CarMat");
            carMove.carCollider = box;
            carMove.bodyRenderer = model.GetComponent<MeshRenderer>();
        }

        GameObject audio = Resources.Load<GameObject>("Prefabs/CarStuff/Car Audio Sources");
        PrefabUtility.InstantiatePrefab(audio, gameObject.transform);

        GameObject weapon = Resources.Load<GameObject>("Prefabs/CarStuff/WeaponHandler");
        PrefabUtility.InstantiatePrefab(weapon, gameObject.transform);

        GameObject reflection = Resources.Load<GameObject>("Prefabs/CarStuff/CarReflection");
        GameObject rP = (GameObject)PrefabUtility.InstantiatePrefab(reflection, gameObject.transform);

        carMove.carReflectionProbe = rP.GetComponent<ReflectionProbe>();

        Selection.activeObject = PrefabUtility.SaveAsPrefabAsset(gameObject, path + "/RENAME_ME.prefab");

        UnityEngine.Object.DestroyImmediate(gameObject);
    }

    private static void RimPrefab() {
        string name = "RENAME_ME";
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (Selection.activeObject != null) name = Selection.activeObject.name;
        GameObject gameObject = new GameObject(name);
        gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        if (!Directory.Exists(path)) {
            path = Directory.GetParent(path).FullName;
            Debug.Log(path);
            int start = path.IndexOf("/Assets/");
            if (start == -1) start = path.IndexOf("\\Assets\\");
            if (start == -1) {
                EditorUtility.DisplayDialog("Error", $"Could not find Assets folder in path { path }...", "Ok");
                return;
            }
            path = path.Substring(start + 1);
            Debug.Log(path);
        }

        WheelMeshHandle wheel = gameObject.AddComponent<WheelMeshHandle>();
        if (Selection.activeGameObject != null) {
            wheel.wheelModel = ((GameObject)PrefabUtility.InstantiatePrefab(Selection.activeGameObject, gameObject.transform)).GetComponent<MeshRenderer>();
        }

        GameObject tire = new GameObject("Tire");
        tire.transform.parent = gameObject.transform;
        tire.AddComponent<TireMod>();

        string fullPath = Path.Combine(path, name + ".prefab");
        if (File.Exists(fullPath)) {
            bool rn = EditorUtility.DisplayDialog("Error", $"File at { fullPath } already exists...", "Rename", "Overwrite");
            if (rn) {
                int i = 1;
                do {
                    fullPath = Path.Combine(path, name + i + ".prefab");
                    i++;
                } while (File.Exists(fullPath));
            }
        }

        Selection.activeObject = PrefabUtility.SaveAsPrefabAsset(gameObject, fullPath);

        UnityEngine.Object.DestroyImmediate(gameObject);
    }


    class ModDetailsPrompt : EditorWindow {
        internal ModData data;
        internal Sprite missing;

        private bool changeId = true;

        private GUIStyle text;

        private void OnEnable() {
            text = new GUIStyle();
            text.normal.textColor = Color.gray;
            text.stretchHeight = true;
        }

        void OnGUI() {
            EditorGUILayout.Space(26);
            EditorGUILayout.LabelField("(Sometimes this doesn't work;\nyou can click and drag!)", text);
            EditorGUILayout.Space(20);

            data._image = (Sprite)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 60), "Icon", data._image, typeof(Sprite), false);

            data._title = EditorGUILayout.TextField("Title", data._title);
            EditorGUILayout.LabelField("Description");
            data._description = EditorGUILayout.TextArea(data._description);
            data._author = EditorGUILayout.TextField("Creator", data._author);
            data._version = EditorGUILayout.TextField("Version", data._version);

            if (changeId) data._id = RegexIt(data._author) + "." + RegexIt(data._title);

            string id = EditorGUILayout.TextField("ID", data._id);

            if (id != data._id) {
                changeId = false;
                data._id = id;
            }

            if (GUILayout.Button("Create Mod")) {
                OnClickCreateMod();
                GUIUtility.ExitGUI();
            }
        }

        private string RegexIt(string str) {
            //remove duplicate and trailing _
            if (str == null) return "";
            return Regex.Replace(Regex.Replace(str.ToLower().Trim(), @"[^a-z0-9_]", "_"), @"(_+$)|(_(?=_))", "");
        }

        private bool CheckDetails(string title) {
            if (string.IsNullOrWhiteSpace(data._title)) {
                EditorUtility.DisplayDialog(title, "Please specify a valid mod title.", "Close");
                return true;
            }

            if (string.IsNullOrWhiteSpace(data._author)) {
                EditorUtility.DisplayDialog(title, "Please specify a valid creator name.", "Close");
                return true;
            }

            switch (ModDataEditor.CheckID(data._id)) {
                case ModDataEditor.IDValidity.InvalidChar:
                    EditorUtility.DisplayDialog(title, "ID may only contain lowercase letters, numbers, \"_\", and \".\"", "Close");
                    return true;
                case ModDataEditor.IDValidity.StartLetter:
                    EditorUtility.DisplayDialog(title, "ID must start with a letter", "Close");
                    return true;
                case ModDataEditor.IDValidity.EndUnderscore:
                    EditorUtility.DisplayDialog(title, "ID cannot end with \"_\" or \".\"", "Close");
                    return true;
                case ModDataEditor.IDValidity.SceneTail:
                    EditorUtility.DisplayDialog(title, "ID cannot end with " + sceneTail, "Close");
                    return true;
                case ModDataEditor.IDValidity.SceneDataTail:
                    EditorUtility.DisplayDialog(title, "ID cannot end with " + sceneDataTail, "Close");
                    return true;
                case ModDataEditor.IDValidity.Empty:
                    EditorUtility.DisplayDialog(title, "ID cannot be empty", "Close");
                    return true;
            }

            switch (ModDataEditor.CheckVersion(data._version)) {
                case ModDataEditor.VersionValidity.InvalidChar:
                    EditorUtility.DisplayDialog(title, "Version may only contain lowercase letters, numbers, \"_\" and \".\"", "Close");
                    return true;
                case ModDataEditor.VersionValidity.StartEndInvalid:
                    EditorUtility.DisplayDialog(title, "Version cannot start or end with \"_\" or \".\"", "Close");
                    return true;
                case ModDataEditor.VersionValidity.Double:
                    EditorUtility.DisplayDialog(title, "Version cannot contain \"..\", \"._\", \"_.\", or \"__\"", "Close");
                    return true;
                case ModDataEditor.VersionValidity.Empty:
                    EditorUtility.DisplayDialog(title, "Version cannot be empty", "Close");
                    return true;
            }

            if (string.IsNullOrWhiteSpace(data._description)) {
                if (!EditorUtility.DisplayDialog("Confirmation", $"Will create a mod without a description.", "Ok", "Add a description")) {
                    return true;
                }
            }

            return false;
        }

        void OnClickCreateMod() {
            if (CheckDetails("Unable to create mod")) return;

            if (!EditorUtility.DisplayDialog("Confirmation", $"Will create a mod named { data._title } (in a folder named { data._id }).", "Ok", "Choose another")) {
                return;
            }

            string path = Path.Combine("Assets", data._id);
            if (File.Exists(path)) {
                EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ data._id }\" already exists.", "Close");
                return;
            }
            try {
                string modFolder = AssetDatabase.CreateFolder("Assets", data._id);
                if (modFolder == "") {
                    EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ data._id }\" could not be created.", "Close");
                    return;
                }
                modFolder = AssetDatabase.CreateFolder(path, "Mod");
                if (modFolder == "") {
                    EditorUtility.DisplayDialog("Unable to create mod", $"The folder \"{ data._id }\" could not be created.", "Close");
                    return;
                }
                AssetDatabase.CreateFolder(path, "Scenes");
                AssetDatabase.CreateFolder(path, "SceneData");
                
                var imp = AssetImporter.GetAtPath(Path.Combine(path, "Mod"));
                imp.assetBundleName = data._id;
                imp = AssetImporter.GetAtPath(Path.Combine(path, "Scenes"));
                imp.assetBundleName = data._id + sceneTail;
                imp = AssetImporter.GetAtPath(Path.Combine(path, "SceneData"));
                imp.assetBundleName = data._id + sceneDataTail;
                UnityEngine.Object o = AssetDatabase.LoadMainAssetAtPath(path);
                Selection.SetActiveObjectWithContext(o, o);
                path = Path.Combine(path, "Mod");
            } catch (Exception e) {
                EditorUtility.DisplayDialog("Unable to create mod", $"An error occurred: { e.Message }.", "Close");
                
                //Don't let the user think they are good to place assets in the folder despite seing the error.
                AssetDatabase.DeleteAsset("Assets/" + data._id);
                Debug.LogException(e);
                return;
            }

            try {
                AssetDatabase.CreateFolder(path, "Audio");
                AssetDatabase.CreateFolder(path + "/Audio", "Music");
                AssetDatabase.CreateFolder(path + "/Audio", "Horns");
                AssetDatabase.CreateFolder(path, "BoostThemes");
                AssetDatabase.CreateFolder(path, "Cars");
                //AssetDatabase.CreateFolder(path, "Events");
                AssetDatabase.CreateFolder(path, "GameThemes");
                AssetDatabase.CreateFolder(path, "MenuBackgrounds");
                AssetDatabase.CreateFolder(path, "Rims");
                AssetDatabase.CreateFolder(path, "Skins");
                AssetDatabase.CreateFolder(path, "Worlds");
                AssetDatabase.CreateFolder(path, "Languages");

                AssetDatabase.CreateAsset(data, Path.Combine(path, "mod.asset"));
                AssetDatabase.Refresh();

            } catch (Exception e) {
                EditorUtility.DisplayDialog("Failed to create sub-folders", $"An error occurred creating sub-folders. You can still use the folder, you just won't have the recommended folder structure. Error: { e }", "Close");
                Debug.LogException(e);
            }

            Close();
        }
    }
}