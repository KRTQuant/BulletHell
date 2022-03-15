using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinionStatus : MonoBehaviour
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


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("this func inside TakeDamage");
            //Debug.Log(this.gameObject.name);
            this.gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
            MinionsBulletPattern MBP = GetComponent<MinionsBulletPattern>();
            MBP.CancelInvoke("MinionsBullet");

        }
    }
}
