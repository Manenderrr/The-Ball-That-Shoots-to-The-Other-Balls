using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public GameObject Placeholder;
    public GameObject OwnerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().fillAmount = OwnerObject.GetComponent<HealthController>().Health / OwnerObject.GetComponent<HealthController>().MaxHealth;

        //GetComponent<RectTransform>().position = new Vector2(Placeholder.GetComponent<RectTransform>().position.x - Placeholder.GetComponent<RectTransform>().localScale.x + GetComponent<RectTransform>().localScale.x, Placeholder.GetComponent<RectTransform>().position.y);
    }
}
