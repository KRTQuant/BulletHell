using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    public int maxHealth = 10000;
    public int currentHealth;

    [SerializeField]
    private BossHealthBar healthBar;
    [SerializeField]
    private MinionsBulletPattern minionsBullet;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        /*if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            minionsBullet.GetComponent<MinionsBulletPattern>().CancelInvoke("MinionsBullet");
        }*/


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(GameObject.Find("BossShip"));
            SceneManager.LoadScene(0);
        }
    }
}
