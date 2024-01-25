using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mod Details", menuName = "Mods/Mod Details")]
public class TranslatedModDetails : ScriptableObject {
	public string languageId;
	public string title;
	public string description;
}
