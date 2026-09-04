using System.Collections.Generic;
using UnityEngine;
using static Health;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    private Collider2D hurtbox;
    private Rigidbody2D rb;

    private void Start()
    {
        hurtbox = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Punch") || collision.CompareTag("Kick"))
        {

        }

    }
    private void GotHit(GameObject hitbox)
    {
        Vector2 direction = (transform.position - hitbox.transform.position).normalized;

        rb.AddForce(direction * 10, ForceMode2D.Impulse);
    }
}
