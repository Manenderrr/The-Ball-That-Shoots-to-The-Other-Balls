using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public float Health = 10;
    public float MaxHealth = 10;

    public GameObject HealthBarPlaceholder, HealthBarIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Health = 1;
            GetComponent<FractionController>().Respawn();
        }
    }

    public void AfterSpawn()
    {
        Destroy(this.gameObject);
        Destroy(HealthBarPlaceholder);
        Destroy(HealthBarIndicator);
    }
}