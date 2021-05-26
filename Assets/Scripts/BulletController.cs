using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() != null)
        {
            collision.gameObject.GetComponent<HealthController>().Health -= Mathf.Abs(GetComponent<Rigidbody2D>().mass + (GetComponent<Rigidbody2D>().velocity.x + GetComponent<Rigidbody2D>().velocity.y) + (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y));
            Destroy(this.gameObject);
            print(collision.gameObject.GetComponent<HealthController>().Health);
        }
    }
}
