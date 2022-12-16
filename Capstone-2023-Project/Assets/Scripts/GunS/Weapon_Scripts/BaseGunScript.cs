using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGunScript : MonoBehaviour
{
    public string gunName = "gun";
    public GameObject firePoint;
    public GunStats gunStats;
    public GunData gunData;
    [SerializeField]
    protected GameObject gunModel;
    [SerializeField]
    protected GameObject propFirePoint;
    [SerializeField] 
    Sprite gunCardSprite;
    [SerializeField]
    MuzzleFlash MuzzleFlash;
    [SerializeField]
    AudioSource ShootingAudio;
    protected WeaponManager WM;
    private float nextTimeToFire = 0f;
    bool gameEnabled = false;
    float shootPitch;

    protected virtual void Start() {
        WM = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        shootPitch = ShootingAudio.pitch + gunStats.dmg;
    }

    void Update() {
        if (gameEnabled) {
            if (!gunModel.activeSelf) {
                gunModel.SetActive(true);
            }

            bool inputRegistered;

            if (gunStats.fireType == GunEnums.FireType.Automatic) {
                inputRegistered = Input.GetButton("Fire1");
            } else {
                inputRegistered = Input.GetButtonDown("Fire1");
            }

            if (inputRegistered && Time.time >= nextTimeToFire) {
                nextTimeToFire = Time.time + 1f / gunStats.fireRate;
                WM.UpdateAmmo();
                FireEvent();
                ShootingAudio.pitch = Mathf.Clamp(shootPitch - gunStats.dmg,0.1f,1.8f);
                ShootingAudio.Play();
                MuzzleFlash.Activate();
            }
        } else {
            if (gunModel.activeSelf) {
                gunModel.SetActive(false);
            }
        }
    }

    public GunStatusReport GetReport() {
        GunStatusReport returnData = new GunStatusReport();
        returnData.name = gunName;
        // foreach (GameObject child in transform) {    // 'specified cast not supported'
        //     if (child.CompareTag("Effect")) {
        //         returnData.effectData.Add(child.GetComponent<AbstractEffect>().GetReport());
        //     }
        // }
        return returnData;
    }

    public Sprite GetCardSprite() {
        return gunCardSprite;
    }

    public void SetGameEnabled(bool condition = true) { gameEnabled = condition; }
    public abstract void FireEvent();
}  
