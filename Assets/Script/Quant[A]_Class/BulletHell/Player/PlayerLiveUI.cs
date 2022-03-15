using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLiveUI : MonoBehaviour
{
    public int playerLive = 3;
    [SerializeField]
    private Text playerLiveText;

    public void TakeDamage()
    {
        playerLive -= 1;
    }

    private void Update()
    {
        playerLiveText.text = "x " + playerLive.ToString();
    }
}
