using System.Collections.Generic;
using UnityEngine;

public enum CarWheelDrive
{
    AWD,
    RWD,
    FWD
}

[System.Serializable]
public struct CarSkin
{
	public string longName;
	public string name;
	public Texture skinPicture;
	public string textureCredit;
	public string skinYear;
    public List<Material> matReplacements;
}

public class CarMoveMod : MonoBehaviour
{
    [Header("Car Objects")]
	public List<CarPartSkinMod> carPartsToSkin;

    [Header("Car Stats")]
    public CarWheelDrive carWheelDrive;

    public AnimationCurve accelerationCurve;
    public AnimationCurve boostCurve;
	public AnimationCurve airBoostCurve;
    public AnimationCurve reverseCurve;
    public AnimationCurve steerCurve;

    [SerializeField] private Vector3 centerOfMass;
    public float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteerAngle;

    public float maxSpeed;
    public float maxBoostSpeed;
    public float maxStuntSpeed;
    public float stuntAcceleration = 2.5f;

    public float maxHealth;
    public float jumpForce;

    public float frontStiffness;
    public float backStiffness;

    public float frontStiffnessDrift = 0.75f;
    public float backStiffnessDrift = 0.45f;

    public float driftRigidbodyRotationValue = 1f;

    public float stiffnessChangeIn;
    public float stiffnessChangeOut;

    public float dampingRate = 200000f;

    public float airDrag;
    public float groundDrag;
    public float gravityMultiplier = 1.0f;
    public float gravityAirMultiplier = 1.0f;

    public float minimumStuntPoints = 100;
    
    [Header("Vehicle Climb Drag")]
    public float climbDownForce;
    public float climbDownStart;

    [Header("Boost")]
    public float maxBoost;
    public float airBoostForce;
    public float boostForce;

    [Header("Strafing Stuff")]
    public float shiftForce;
    public float shiftCooldown;
    
    [Header("Self-Stabilization")]
    [SerializeField] private bool selfStabilizationEnable;
    [SerializeField] private float selfStabilizationCorrection;
    [SerializeField] private float selfStabilizationSpeed;

    [Header("Car Body")]

	public BoxCollider carCollider;
    public BoxCollider upsideDownTrigger;
    public MeshRenderer bodyRenderer;
    public ReflectionProbe carReflectionProbe;
    public bool supportsSkins;
}
