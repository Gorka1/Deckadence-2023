using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public int dmg = 0;
    public float fireRate = 0;
    public bool projectilePresent = false;
    public string fireType;
    public int maxEffects = 5;

    public static WeaponData CreateFromJSON(string inputJson) {
        return JsonUtility.FromJson<WeaponData>(inputJson);
    }
}
