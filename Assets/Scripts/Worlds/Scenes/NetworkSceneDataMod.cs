using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct CarSpawns
{
    public Vector3 Position;
    public Quaternion Rotation;
}

public class NetworkSceneDataMod : MonoBehaviour
{
    public bool isLobby;
    public List<CarSpawns> carSpawns;
    public string sceneBaseMusicId;
}
