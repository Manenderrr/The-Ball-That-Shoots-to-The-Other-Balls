using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoIndicatorController : MonoBehaviour
{
    public GameObject Player;
    private AmmoController AmmoComp;
    private TMPro.TextMeshProUGUI TextComp;

    private void Awake()
    {
        AmmoComp = Player.GetComponent<AmmoController>();
        TextComp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!AmmoComp.IsReloading)
        {
            TextComp.text = AmmoComp.Ammo.ToString() + "/" + AmmoComp.MaxAmmo.ToString();
        }
        else
        {
            TextComp.text = (AmmoComp.ReloadTimer / AmmoComp.ReloadTime).ToString() + " (Перезарядка)";
        }
    }
}
