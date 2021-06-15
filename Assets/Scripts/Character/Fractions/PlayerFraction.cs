using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFraction : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<FractionController>().CharacterFraction = FractionController.Fraction.Player;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
