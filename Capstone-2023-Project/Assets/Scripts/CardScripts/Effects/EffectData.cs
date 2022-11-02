using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EffectData {
    public Sprite icon;
    public string name;
    public float time;
    public EffectData(Sprite newIcon, string newName, float newTime) {
        icon = newIcon;
        name = newName;
        time = newTime;
    }
}
