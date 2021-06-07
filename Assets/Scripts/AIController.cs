using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("AI")]
    public string Fraction;

    [Header("Health Bar")]
    public bool HaveHealthBar;
    public GameObject Canvas;
    public GameObject HealthBarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject HealthBar = Instantiate(HealthBarPrefab, Canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
