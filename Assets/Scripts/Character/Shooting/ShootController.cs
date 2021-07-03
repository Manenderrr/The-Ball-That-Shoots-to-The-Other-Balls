using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public CharacterController CharacterControllerComponent;
    public GameObject BulletPrefab;
    public float BulletPower = 500;
    private AmmoController AmmoComp;

    public GameObject Shot(Vector3 Direction)
    {
        GameObject Bullet;

        if (!AmmoComp.IsReloading)
        {
            Bullet = Instantiate(BulletPrefab);

            Bullet.transform.position = transform.position + Direction.normalized * (GetComponent<CircleCollider2D>().radius + Bullet.GetComponent<CircleCollider2D>().radius + 0.2f);

            Bullet.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, CharacterControllerComponent.Aim.transform.position.z - transform.position.z));

            Bullet.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * BulletPower + new Vector3(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y, 0));

            Bullet.GetComponent<BulletController>().Owner = this.gameObject;


            if (AmmoComp != null) AmmoComp.Ammo--;
        }
        else
        {
            Bullet = null;
        }
        return Bullet;
    }

    private void Awake()
    {
        AmmoComp = GetComponent<AmmoController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CharacterControllerComponent.IsAI)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shot(CharacterControllerComponent.Aim.transform.position - transform.position);
            }
        }
    }
}