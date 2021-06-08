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
    public GameObject HealthBarPlaceholderPrefab;
    public GameObject HealthBarIndicatorPrefab;
    float HealthBarHeight = 0.2f;

    private GameObject HealthBarPlaceholder, HealthBarIndicator;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarPlaceholder = Instantiate(HealthBarPlaceholderPrefab, Canvas.transform);
        HealthBarIndicator = Instantiate(HealthBarIndicatorPrefab, Canvas.transform);

        HealthBarIndicator.GetComponent<HealthBarController>().OwnerObject = this.gameObject;
        HealthBarIndicator.GetComponent<HealthBarController>().Placeholder = HealthBarPlaceholder;

        GetComponent<HealthController>().HealthBarPlaceholder = HealthBarPlaceholder;
        GetComponent<HealthController>().HealthBarIndicator = HealthBarIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarPlaceholder.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + GetComponent<CircleCollider2D>().radius + HealthBarHeight));
        HealthBarIndicator.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + GetComponent<CircleCollider2D>().radius + HealthBarHeight));
    }
}
