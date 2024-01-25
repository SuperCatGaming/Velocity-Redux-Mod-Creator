using UnityEngine;

[ExecuteAlways]
public class PlayEngineSounds : MonoBehaviour
{
    private AudioSource source;
    private AudioListener listener;
    private static AssetBundle sfx;

    [Header("Make sure to remove this script before packing your mod!")]
    public EngineSound engineTest;
    public IdleSound idleTest;
    public WinddownSound winddownTest;
    public SkidSound skidTest;

    public void PlayEngine() {
        FindSources();
        switch (engineTest) {
            //TODO: change path in assetbundle
            case EngineSound.W8:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/W8/W8.ogg");
                break;
            case EngineSound.Turbine:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/Turbine Engine/TurbineEngine_loaded.ogg");
                break;
            case EngineSound.ClassicRace:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/classic race engines/917_Loaded.ogg");
                break;
            case EngineSound.BMW:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/BMW_REV.ogg");
                break;
            case EngineSound.Carrera_GT:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/CARRERA_GT_REV.ogg");
                break;
            case EngineSound.CIT:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/CIT_REV.ogg");
                break;
            case EngineSound.Diablo_GTR:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/DIABLO_GTR_REV.ogg");
                break;
            case EngineSound.V8:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/FUCKIN_V8.ogg");
                break;
            case EngineSound.Gallardo:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/GALLARDO_REV.ogg");
                break;
            case EngineSound.Jaguar:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/Jaguar.ogg");
                break;
            case EngineSound.Mustang:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/mustang.ogg");
                break;
            case EngineSound.R32:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/R32_REV.ogg");
                break;
            case EngineSound.Viper:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/VIPER_REV.ogg");
                break;
            case EngineSound.Zonda:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Rev Sounds/zonda.ogg");
                break;
            case EngineSound.Tsunami:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/Tsunami_MedRpm1.wav");
                break;
            case EngineSound.Taurus:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/Taurus.ogg");
                break;
            case EngineSound.Rotar:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/rotar.wav");
                break;
            case EngineSound.Demui:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/fix_demui.wav");
                break;
            case EngineSound.Futurisitc:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/engine futuristic.wav");
                break;
            case EngineSound.Gutteral:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/CARTEST1.wav");
                break;
            case EngineSound.aa:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/aa.wav");
                break;
            case EngineSound.Engine1_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine1/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine1_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine1/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine2_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine2/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine2_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine2/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine3_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine3/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine3_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine3/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine4_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine4/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine4_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine4/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine5_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine5/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine5_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine5/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine6_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine6/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine6_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine6/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine7_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine7/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine7_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine7/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine8_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine8/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine8_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine8/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.Engine9_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine9/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.Engine9_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine9/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.ModelA_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modela/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.ModelA_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modela/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            case EngineSound.ModelT_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modelt/ENGINE_SAMPLE_TYPE_LOW_LOADED.wav");
                break;
            case EngineSound.ModelT_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modelt/ENGINE_SAMPLE_TYPE_HIGH_LOADED.wav");
                break;
            default:
                Debug.LogWarning("Not a valid Engine Sound");
                return;
        }
        source.Play();

    }
    public void PlayIdle() {
        FindSources();
        switch (idleTest) {
            case IdleSound.Charger:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Idle/chargeridleagain.ogg");
                break;
            case IdleSound.OldMuscle:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Idle/old_muscle_idle.ogg");
                break;
            case IdleSound.Mx5:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Nathan/Mx5_idle_loop.wav");
                break;
            case IdleSound.W8:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/W8/W8idle.ogg");
                break;
            case IdleSound.Turbine:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/Turbine Engine/TurbineEngine_idle.ogg");
                break;
            case IdleSound.ClassicRace:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/zolton/classic race engines/917_Unloaded.ogg");
                break;
            case IdleSound.Engine1_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine1/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine1_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine1/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine1_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine1/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine2_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine2/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine2_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine2/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine2_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine2/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine3_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine3/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine3_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine3/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine3_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine3/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine4_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine4/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine4_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine4/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine4_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine4/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine5_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine5/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine5_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine5/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine5_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine5/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine6_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine6/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine6_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine6/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine6_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine6/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine7_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine7/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine7_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine7/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine7_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine7/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine8_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine8/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine8_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine8/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine8_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine8/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.Engine9_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine9/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.Engine9_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine9/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.Engine9_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/engine9/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.ModelA_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modela/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.ModelA_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modela/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.ModelA_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modela/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            case IdleSound.ModelT_Low:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modelt/ENGINE_SAMPLE_TYPE_LOW_UNLOADED.wav");
                break;
            case IdleSound.ModelT_High:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modelt/ENGINE_SAMPLE_TYPE_HIGH_UNLOADED.wav");
                break;
            case IdleSound.ModelT_Tickover:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/modelt/ENGINE_SAMPLE_TYPE_TICKOVER.wav");
                break;
            default:
                Debug.LogWarning("Not a valid Idle Sound");
                return;
        }
        source.Play();
    }

    public void PlayWinddown() {
        FindSources();
        switch (winddownTest) {
            case WinddownSound.TurboOff:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Turbo/turbo_off.wav");
                break;
            case WinddownSound.TurboBlow1:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Turbo/TurboBlow1.wav");
                break;
            case WinddownSound.TurboBlow2:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/Turbo/TurboBlow2.wav");
                break;
            default:
                Debug.LogWarning("Not a valid Winddown Sound");
                return;
        }
        source.Play();
    }

    public void PlaySkid() {
        FindSources();
        switch (skidTest) {
            case SkidSound.Squall:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/tyres/TYRE_SAMPLE_TYPE_SQUALL.wav");
                break;
            case SkidSound.Squeak:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/tyres/TYRE_SAMPLE_TYPE_SQUEAK.wav");
                break;
            case SkidSound.Squeal:
                source.clip = sfx.LoadAsset<AudioClip>("Assets/SFX/Cars/FR3/tyres/TYRE_SAMPLE_TYPE_SQUEAL.wav");
                break;
            default:
                Debug.LogWarning("Not a valid Skid Sound");
                return;
        }
        source.Play();
    }

    public void FindSources() {
        if (source == null) {
            source = transform.GetComponent<AudioSource>();
        }

        if (listener == null) {
            listener = transform.GetComponent<AudioListener>();
        }
        sfx = BundleSupport.GetBundle();
    }
}
