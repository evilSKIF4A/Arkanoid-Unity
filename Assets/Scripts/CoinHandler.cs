using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    public static int coins;
    public Text TextCoin;
    void Update()
    {
        if (!PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
            coins = PlayerPrefs.GetInt("Coin");
        }
        if (TextCoin != null)
            TextCoin.text = PlayerPrefs.GetInt("Coin").ToString().PadLeft(4, '0');
    }
}
