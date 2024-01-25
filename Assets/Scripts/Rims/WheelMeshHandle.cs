using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMeshHandle : MonoBehaviour {
	public string id;
	[Header("Wheel Info")]
	public string fullName;
	public string rimCredit;
	public Texture wheelPicture;

	[Header("Unlock Status")]
	public bool bypassUnlock;

	[Header("Rim Skinning")]

	public MeshRenderer wheelModel;
	public bool supportsWheelMats;
	public int wheelMatSlot;
	public bool supportsBackWheelMats;
	public int rimBackMatSlot;

	[Header("Tire Skinning")]

	public MeshRenderer tireModel;
	public bool supportsTireMats;
}