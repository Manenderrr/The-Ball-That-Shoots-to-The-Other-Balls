using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Health Bar")]
    public bool HaveHealthBar;
    public GameObject Canvas;
    public GameObject HealthBarPlaceholderPrefab;
    public GameObject HealthBarIndicatorPrefab;
    public GameObject PlayerCamera;
    public float HealthBarHeight = 0.2f;

    [Header("AI")]
    public bool IsShoots;
    public GameObject Player;
    public float ShootCooldown = 5;

    private GameObject HealthBarPlaceholder, HealthBarIndicator;
    private CircleCollider2D CircleCol2D;
    private Camera CameraComp;
    private float ShootTimer = 0;
    private ShootController ShootComp;

    private void Awake()
    {
        CircleCol2D = GetComponent<CircleCollider2D>();
        CameraComp = PlayerCamera.GetComponent<Camera>();
        ShootComp = GetComponent<ShootController>();
    }

    void CreateHealthBar()
    {
        HealthBarPlaceholder = Instantiate(HealthBarPlaceholderPrefab, Canvas.transform);
        HealthBarIndicator = Instantiate(HealthBarIndicatorPrefab, Canvas.transform);

        HealthBarIndicator.GetComponent<HealthBarController>().OwnerObject = this.gameObject;
        HealthBarIndicator.GetComponent<HealthBarController>().Placeholder = HealthBarPlaceholder;

        GetComponent<HealthController>().HealthBarPlaceholder = HealthBarPlaceholder;
        GetComponent<HealthController>().HealthBarIndicator = HealthBarIndicator;
    }

    void UpdareHealthBar()
    {
        HealthBarPlaceholder.transform.position = CameraComp.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + CircleCol2D.radius + HealthBarHeight));
        HealthBarIndicator.transform.position = CameraComp.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + CircleCol2D.radius + HealthBarHeight));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (HaveHealthBar) CreateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (HaveHealthBar) UpdareHealthBar();

        if (IsShoots)
        {
            RaycastHit2D ShootCheckRay = Physics2D.Raycast(transform.position + (Player.transform.position - transform.position).normalized * CircleCol2D.radius, (Player.transform.position - transform.position));
            if ((ShootCheckRay.transform.gameObject == Player) && ShootTimer > ShootCooldown)
            {
                ShootComp.Shot((Player.transform.position - transform.position).normalized);
                ShootTimer = 0;
            }
            else ShootTimer += Time.deltaTime * 10;
        }
    }
}
