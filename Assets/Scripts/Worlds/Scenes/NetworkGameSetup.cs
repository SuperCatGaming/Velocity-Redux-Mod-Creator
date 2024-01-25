using UnityEngine;
public class NetworkGameSetup : MonoBehaviour {

    [System.Serializable]
    public enum NetworkGameType {
        Joyride = 0,
        Battle = 1,
        Race = 2,
        CaptureTheFlag = 3,
        Gearhunt = 4,
        Mission = 5,
        Payload = 6
    }
}
