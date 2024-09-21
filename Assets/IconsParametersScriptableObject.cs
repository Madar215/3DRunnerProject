using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IconsParametersScriptableObject", order = 1)]
public class IconsParametersScriptableObject : ScriptableObject
{
    public float HeartPortraitX = 1.5f;
    public float HeartPortraitY = 6f;
    public float HeartLandscapeX = 9f;
    public float HeartLandscapeY = 6f;
    public float StarPortraitX = -1.5f;
    public float StarPortraitY = 6f;
    public float StarLandscapeX = -9f;
    public float StarLandscapeY = 6f;
    public float PortraitScale = 0.12f;
    public float LandscapeScale = 0.2f;
}
