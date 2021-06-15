using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FractionController : MonoBehaviour
{

    public string CharacterFractionAsString;
    public Fraction CharacterFraction;
    public GameObject ThisPrefab;

    [Header("Spawning")]
    public GameObject NorthBorder;
    public GameObject SouthBorder;
    public GameObject WestBorder;
    public GameObject EastBorder;

    private void Awake()
    {
        switch (CharacterFractionAsString)
        {
            case "Player":
                CharacterFraction = Fraction.Player;
                break;
            case "Enemy":
                CharacterFraction = Fraction.Player;
                break;
        }
    }

    public void Respawn()
    {
        GameObject Obj = Instantiate(ThisPrefab);
        if (Obj.GetComponent<HealthController>() != null) Obj.GetComponent<HealthController>().Health = Obj.GetComponent<HealthController>().MaxHealth;
        Obj.transform.position = new Vector2(Random.Range(WestBorder.transform.position.x, EastBorder.transform.position.x), Random.Range(SouthBorder.transform.position.y, NorthBorder.transform.position.y));
        GetComponent<HealthController>().AfterSpawn();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public class Fraction
    {
        public string RuName;
        public bool IsRespawning;

        public Fraction(string RuName, bool IsRespawning)
        {
            this.RuName = RuName;
            this.IsRespawning = IsRespawning;
        }
        public static Fraction Enemy = new Fraction("Враги", true);

        public static Fraction Player = new Fraction("Игроки и союзники", false);
    }
}
