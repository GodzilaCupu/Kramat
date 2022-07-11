using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX Player", menuName = "ScriptibleObject/Player/Step-SFX")]
public class WalkingScrptibleObject : ScriptableObject
{
    public List<AudioClip> stepingSFX = new List<AudioClip>();
}
