using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Owner;
    public float DamageModifier = 2;
    private Rigidbody2D Rig2D;

    private void Awake()
    {
        Rig2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>() != null)
        {
            collision.gameObject.GetComponent<HealthController>().Health -= Mathf.Abs(Rig2D.mass + (Rig2D.velocity.x + Rig2D.velocity.y) / 2 + (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y)) * DamageModifier;
            print("Health of " + collision.gameObject + ": " + collision.gameObject.GetComponent<HealthController>().Health);

            if (collision.gameObject.GetComponent<HealthController>().Health <= 0 && Owner.GetComponent<ScoreController>() != null)
            {
                Owner.GetComponent<ScoreController>().Score += collision.gameObject.GetComponent<ScoreController>().Reward;
            }
        }

        Destroy(this.gameObject);
    }
}
