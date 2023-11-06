using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinControl : MonoBehaviour
{
    [SerializeField] private int skinNum;
    public int Price;
    public Text showPriceText;

    public Button buyButton;
    public Sprite buySkin;
    public Sprite selectSkin;
    public Sprite selectedSkin;

    private void Update()
    {
        showPriceText.text = Price.ToString();
        if (PlayerPrefs.GetString("ChooseProduct") == "Ball")
        {
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "Ball") == 0)
                buyButton.GetComponent<Image>().sprite = buySkin;
            else if(PlayerPrefs.GetInt("skinNumBall") == skinNum)
                buyButton.GetComponent<Image>().sprite = selectedSkin;
            else
                buyButton.GetComponent<Image>().sprite = selectSkin;
        }
        else if (PlayerPrefs.GetString("ChooseProduct") == "Player")
        {
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "Player") == 0)
                buyButton.GetComponent<Image>().sprite = buySkin;
            else if (PlayerPrefs.GetInt("skinNumPlayer") == skinNum)
                buyButton.GetComponent<Image>().sprite = selectedSkin;
            else
                buyButton.GetComponent<Image>().sprite = selectSkin;
        }
    }
    
}
