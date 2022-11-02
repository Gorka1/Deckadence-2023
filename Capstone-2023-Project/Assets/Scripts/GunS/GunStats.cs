using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunStats
{
    public int dmg = 0;
    public float fireRate = 0f;
    public float range = 0f;
    public GunEnums.FireType fireType = GunEnums.FireType.Single;
    public int ammo = 0;
    public float speed = 0f;
    public float critChance = 0f;
    public float critBonus = 200f;
    public float spread = 0f;
}
