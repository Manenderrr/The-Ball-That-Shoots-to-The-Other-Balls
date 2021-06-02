using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject Placeholder;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().localScale = new Vector3(Player.GetComponent<HealthController>().Health / Player.GetComponent<HealthController>().MaxHealth, 1, 0);

        //GetComponent<RectTransform>().position = new Vector2(Placeholder.GetComponent<RectTransform>().position.x - Placeholder.GetComponent<RectTransform>().localScale.x + GetComponent<RectTransform>().localScale.x, Placeholder.GetComponent<RectTransform>().position.y);
    }
}
