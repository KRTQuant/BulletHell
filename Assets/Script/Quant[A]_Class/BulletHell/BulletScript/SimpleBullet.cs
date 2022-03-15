using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    private int projectileSpeed = 10;
    private float timeLimit = 8;


    private void Update()
    {
        this.rb.velocity = (Vector2.up * projectileSpeed);
        if(this.transform.position.y > 5.9f)
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collide with Enemy");
            collision.GetComponent<MinionStatus>().TakeDamage(20);
            Deactivate(); // Deactivate bullet
        }

        if (collision.CompareTag("Boss"))
        {
            //Debug.Log("Collide with boss");
            collision.GetComponent<BossStatus>().TakeDamage(20);
            Deactivate(); // Deactivate bullet
        }
    }
}
