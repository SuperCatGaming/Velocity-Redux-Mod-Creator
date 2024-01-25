using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Horn", menuName = "Mods/Horn", order = 6)]
public class HornSound : ScriptableObject
{
    public string id;
    public string hornName;

    public List<AudioClip> audioClips;
    public bool bypassUnlock;
}