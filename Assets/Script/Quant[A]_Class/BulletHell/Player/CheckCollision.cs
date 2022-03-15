using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField]
    private float invisFrame = 0;
    [SerializeField]
    private float invisCD = 3.0f;
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject kaboom;
    [SerializeField]
    private ParticleSystem ps;

    [SerializeField]
    private PlayerLiveUI PLUI;
    [SerializeField]
    private GameObject sr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            if(invisFrame <= 0)
            {
                PLUI.TakeDamage();
                invisFrame = invisCD;
                Debug.Log("damage player");
            }
            else if(invisFrame > 0)
            {
                invisFrame -= Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        if(invisFrame > 0)
        {
            invisFrame -= Time.deltaTime;
        }

        if(PLUI.playerLive == 0)
        {
            sr.SetActive(false);
            kaboom.SetActive(true);
            Invoke("ShowUI", 2.5f);
        }


    }


    private void ShowUI()
    {
        gameOverUI.SetActive(true);
    }

}
