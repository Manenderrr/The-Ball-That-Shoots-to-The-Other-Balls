using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [Header("Ammo")]
    public int Ammo = 5;
    public int MaxAmmo = 5;

    [Header("Reloading")]
    public float ReloadTime = 1;
    public float ReloadTimer = 0;
    public bool IsReloading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ammo <= 0)
        {
            IsReloading = true;
            ReloadTimer += Time.deltaTime;
        }
        if (ReloadTimer >= ReloadTime)
        {
            IsReloading = false;
            ReloadTimer = 0;
            Ammo = MaxAmmo;
        }
    }
}
