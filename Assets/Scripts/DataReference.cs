using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using Unity.Plastic.Newtonsoft.Json;
using Newtonsoft.Json;

public class DataReference : MonoBehaviour {
    public static CarData[] carData;
    public static RimData[] rimData;
    public static MusicData[] musicData;

    public void LoadData() {
        if (carData == null) carData = JsonConvert.DeserializeObject<CarData[]>(File.ReadAllText("Assets/Resources/cardata.json"));
        if (rimData == null) rimData = JsonConvert.DeserializeObject<RimData[]>(File.ReadAllText("Assets/Resources/rimdata.json"));
        if (musicData == null) musicData = JsonConvert.DeserializeObject<MusicData[]>(File.ReadAllText("Assets/Resources/musicdata.json"));
    }

    public class CarData {
        public string name;
        public string id;
        public List<Skin> skins = new List<Skin>();

        public class Skin {
            public string id;
            public string name;
            public List<Data> data = new List<Data>();

            public class Data {
                public string name;
                public List<string> materials = new List<string>();
            }
        }
    }

    public class RimData {
        public string id;
    }

    public class MusicData {
        public string id;
        public string name;
    }
}
