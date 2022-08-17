using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponObj", menuName = "Capstone-2023-Project/WeaponObj", order = 0)]
public class WeaponObj : ScriptableObject {
    public new string name;
    public Sprite cardIcon;
    public GameObject model;
    public AnimationClip animations;    // how are animations done in unity, it's been like 5 years
    public TextAsset jsonData;
    public WeaponDataObj data;
    public List<AudioClip> sounds;
    public GameObject projectile = null;
    public delegate void attack();
}
