using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBullet : MonoBehaviour
{
    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Deactivated");
            Deactivate(); // Deactivate bullet
        }
    }
}
