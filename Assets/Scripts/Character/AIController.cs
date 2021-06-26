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
    public float MoveTime = 5;

    private GameObject HealthBarPlaceholder, HealthBarIndicator;
    private CircleCollider2D CircleCol2D;
    private Camera CameraComp;
    private float ShootTimer, MoveTimer = 0;
    private ShootController ShootComp;
    public CharacterController CharacterComponent;
    private FractionController FractionComp;
    private Vector2 Direction;

    private void Awake()
    {
        CircleCol2D = GetComponent<CircleCollider2D>();
        CameraComp = PlayerCamera.GetComponent<Camera>();
        ShootComp = GetComponent<ShootController>();
        FractionComp = GetComponent<FractionController>();
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
        Direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (HaveHealthBar) UpdareHealthBar();

        if (CharacterComponent.IsAI)
        {
            if (IsShoots)
            {
                RaycastHit2D ShootCheckRay = Physics2D.Raycast(transform.position + (Player.transform.position - transform.position).normalized * CircleCol2D.radius, (Player.transform.position - transform.position));
                if ((ShootCheckRay.transform.gameObject == Player) && ShootTimer >= ShootCooldown)
                {
                    ShootComp.Shot((Player.transform.position - transform.position).normalized);
                    ShootTimer = 0;
                }
                else ShootTimer += Time.deltaTime * 10;
            }
            
            if (MoveTimer >= MoveTime)
            {
                do
                {
                    Direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                }
                while (Direction == new Vector2(0, 0));
                print("Direction: " + Direction);
                MoveTimer = 0;
            }
            else
            {
                CharacterComponent.Move(Direction);
                MoveTimer += Time.deltaTime;
            }
        }
    }
}
