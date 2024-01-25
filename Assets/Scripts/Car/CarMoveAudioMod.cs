using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct AudioGear
{
    public string name;
    public float minSpeed;
    public float maxSpeed;
    public float pitchOffset;
    public float pitchScalar;
    public AnimationCurve pitchCurve;
}

public enum EngineSound {
    W8,
    Turbine,
    ClassicRace, //917
    BMW,
    Carrera_GT,
    CIT,
    Diablo_GTR,
    V8,
    Gallardo,
    Jaguar,
    Mustang,
    R32,
    Viper,
    Zonda,
    Tsunami,
    Taurus,
    Rotar,
    Demui,
    Futurisitc,
    Gutteral, //CarTest1
    aa,
    Engine1_Low,
    Engine1_High,
    Engine2_Low,
    Engine2_High,
    Engine3_Low,
    Engine3_High,
    Engine4_Low,
    Engine4_High,
    Engine5_Low,
    Engine5_High,
    Engine6_Low,
    Engine6_High,
    Engine7_Low,
    Engine7_High,
    Engine8_Low,
    Engine8_High,
    Engine9_Low,
    Engine9_High,
    ModelA_Low,
    ModelA_High,
    ModelT_Low,
    ModelT_High,
}

public enum IdleSound {
    Charger,
    OldMuscle,
    Mx5,
    W8,
    Turbine,
    ClassicRace, //917
    Engine1_Low,
    Engine1_High,
    Engine1_Tickover,
    Engine2_Low,
    Engine2_High,
    Engine2_Tickover,
    Engine3_Low,
    Engine3_High,
    Engine3_Tickover,
    Engine4_Low,
    Engine4_High,
    Engine4_Tickover,
    Engine5_Low,
    Engine5_High,
    Engine5_Tickover,
    Engine6_Low,
    Engine6_High,
    Engine6_Tickover,
    Engine7_Low,
    Engine7_High,
    Engine7_Tickover,
    Engine8_Low,
    Engine8_High,
    Engine8_Tickover,
    Engine9_Low,
    Engine9_High,
    Engine9_Tickover,
    ModelA_Low,
    ModelA_High,
    ModelA_Tickover,
    ModelT_Low,
    ModelT_High,
    ModelT_Tickover,
}

public enum SkidSound {
    Squall,
    Squeak,
    Squeal
}

public enum WinddownSound {
    TurboOff,
    TurboBlow1,
    TurboBlow2
}

public class CarMoveAudioMod : MonoBehaviour {

	[Header("Engine Sounds")]

    public bool isTurboCharger;
    public bool isSuperCharger;

    public EngineSound defaultEngineSound;
    public IdleSound defaultIdleSound;
    public WinddownSound defaultWinddownSound;
    public SkidSound defaultSkidSound;

    [Header("Custom Values")]

    public float enginePitchOffset;
    public float enginePitchScalar;
    public float idlePitch;
	public float burnoutPitch;
	public float burnoutPitchIncrement;
	public float burnoutPitchBackoff;

    public List<AudioGear> audioGears;
}
