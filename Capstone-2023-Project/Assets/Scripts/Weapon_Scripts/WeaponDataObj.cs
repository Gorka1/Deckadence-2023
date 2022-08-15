using UnityEngine;

[System.Serializable]
public class WeaponDataObj
{
    public int dmg = 0;
    public float fireRate = 0f;
    public bool projectilePresent = false;
    public string fireType = "basic";
    public float range = 0f;
    public bool automatic = false;
    public int ammo = 0;
    public static WeaponDataObj CreateFromJSON(string inputString) {
        return JsonUtility.FromJson<WeaponDataObj>(inputString);
    }
}
