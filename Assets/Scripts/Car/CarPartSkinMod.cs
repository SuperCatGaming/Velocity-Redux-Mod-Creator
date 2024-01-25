using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct CarPartSkinStruct
//{
//	public bool isVisible;
//	public List<Material> matReplacements;
//}

public class CarPartSkinMod : MonoBehaviour
{
	[Header("Info")]
	public MeshRenderer bodyRenderer;
	public bool isLOD;
	[Header("Stuff if not LOD")]
	[SerializeField] public Material outlineMat;
	public List<GameObject> objectsToToggle;
	//[Header("Skins")]
	//public List<CarPartSkinStruct> skins;
}