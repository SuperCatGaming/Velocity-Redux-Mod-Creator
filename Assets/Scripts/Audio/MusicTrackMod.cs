using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music Track", menuName = "Mods/Music Track", order = 7)]
public class MusicTrackMod : ScriptableObject
{
    public string id;
    public bool isMainMenuTheme;
    public string trackName;
    public AudioClip audioClipIntro;
    public AudioClip audioClipLoop;
    public bool loops;
}