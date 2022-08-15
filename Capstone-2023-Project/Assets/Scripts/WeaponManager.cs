using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{   
    public WeaponObj ScriptObj {
        get { return this._scriptObj; }
        set {
            this._scriptObj = value;
            SetWeapon();
        }
    }
    [SerializeField]
    private WeaponObj _scriptObj;

    private WeaponData weaponData;
    [SerializeField]
    GameObject WeaponPoint;

    private void Start() {

    }

    private void SetWeapon() {
        Debug.Log("SetWeapon called");
        weaponData = WeaponData.CreateFromJSON(ScriptObj.jsonData.ToString());
        Instantiate(ScriptObj.model, WeaponPoint.transform);
    }
}
