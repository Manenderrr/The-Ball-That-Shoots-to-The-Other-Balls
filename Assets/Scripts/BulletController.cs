using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Owner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() != null)
        {
            collision.gameObject.GetComponent<HealthController>().Health -= Mathf.Abs(GetComponent<Rigidbody2D>().mass + (GetComponent<Rigidbody2D>().velocity.x + GetComponent<Rigidbody2D>().velocity.y) + (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y));
            Destroy(this.gameObject);
            print("Health of " + collision.gameObject + ": " + collision.gameObject.GetComponent<HealthController>().Health);

            if (collision.gameObject.GetComponent<HealthController>().Health <= 0 && Owner.GetComponent<ScoreController>() != null)
            {
                Owner.GetComponent<ScoreController>().Score += collision.gameObject.GetComponent<ScoreController>().Reward;
            }
        }
    }
}
