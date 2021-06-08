using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public CharacterController CharacterControllerComponent;
    public GameObject BulletPrefab;
    public float BulletPower = 1;

    public GameObject Shot()
    {
        GameObject Bullet = Instantiate(BulletPrefab);

        Vector3 Direction = CharacterControllerComponent.Aim.transform.position - transform.position;

        Bullet.transform.position = transform.position + Direction.normalized * (GetComponent<CircleCollider2D>().radius + Bullet.GetComponent<CircleCollider2D>().radius + 0.2f);

        Bullet.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, CharacterControllerComponent.Aim.transform.position.z - transform.position.z));

        Bullet.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * BulletPower + new Vector3(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y, 0));

        Bullet.GetComponent<BulletController>().Owner = this.gameObject;

        return Bullet;
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
                Shot();
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.3f;
        }
        else Time.timeScale = 1;
    }
}
