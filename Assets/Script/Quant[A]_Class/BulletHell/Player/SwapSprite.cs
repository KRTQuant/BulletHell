using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprite : MonoBehaviour
{
    [Header("Variable")]
    public Sprite redShip, goldShip;

    [Header("Reference")]
    public SpriteRenderer spriteRen;
    public AutoShoot autoShoot;


/*    private void Start()
    {
        redShip = Resources.Load<Sprite>("ship_8");
        goldShip = Resources.Load<Sprite>("ship_0");
    }*/
    private void Update()
    {
        //SwapCharSprite();
    }
/*    private void SwapCharSprite()
   {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (autoShoot)
            {
                spriteRen.sprite = goldShip;
                autoShoot = !autoShoot;
            }
            else
            {
                spriteRen.sprite = redShip;
                autoShoot = !autoShoot;
            }
        }
   }*/
}
