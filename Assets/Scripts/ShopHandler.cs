using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    private int skinNum = 0;
    public GameObject[] skinBalls;
    public GameObject[] skinPlatforms;
    public GameObject objectSkinBalls;
    public GameObject objectSkinPlatform;
    void Start()
    {
        if (!PlayerPrefs.HasKey("skin1Ball"))
            PlayerPrefs.SetInt("skin1Ball", 1);
        if (!PlayerPrefs.HasKey("skin1Player"))
            PlayerPrefs.SetInt("skin1Player", 1);
        if(PlayerPrefs.GetString("ChooseProduct") == "Ball")
        {
            objectSkinBalls.SetActive(true);
            skinBalls[skinNum].SetActive(true);
        }
        else if(PlayerPrefs.GetString("ChooseProduct") == "Player")
        {
            objectSkinPlatform.SetActive(true);
            skinPlatforms[skinNum].SetActive(true);
        }
    }

    public void OnLeftButtonShop()
    {
        if (PlayerPrefs.GetString("ChooseProduct") == "Ball")
        {
            skinBalls[skinNum--].SetActive(false);
            if (skinNum == -1)
                skinNum = skinBalls.Length - 1;
            skinBalls[skinNum].SetActive(true);
        }
        else if (PlayerPrefs.GetString("ChooseProduct") == "Player")
        {
            skinPlatforms[skinNum--].SetActive(false);
            if (skinNum == -1)
                skinNum = skinPlatforms.Length - 1;
            skinPlatforms[skinNum].SetActive(true);
        }
    }
    public void OnRightButtonShop()
    {
        if (PlayerPrefs.GetString("ChooseProduct") == "Ball")
        {
            skinBalls[skinNum++].SetActive(false);
            if (skinNum == skinBalls.Length)
                skinNum = 0;
            skinBalls[skinNum].SetActive(true);
        }
        else if (PlayerPrefs.GetString("ChooseProduct") == "Player")
        {
            skinPlatforms[skinNum++].SetActive(false);
            if (skinNum == skinPlatforms.Length)
                skinNum = 0;
            skinPlatforms[skinNum].SetActive(true);
        }
    }
    public void OnBuySelectButton()
    {
        if (PlayerPrefs.GetString("ChooseProduct") == "Ball")
        {
            if (!PlayerPrefs.HasKey(skinBalls[skinNum].GetComponent<Image>().name + "Ball"))
                PlayerPrefs.SetInt(skinBalls[skinNum].GetComponent<Image>().name + "Ball", 0);
            if (PlayerPrefs.GetInt(skinBalls[skinNum].GetComponent<Image>().name + "Ball") == 0 && PlayerPrefs.GetInt("Coin") >= skinBalls[skinNum].GetComponent<SkinControl>().Price)
            {
                PlayerPrefs.SetInt(skinBalls[skinNum].GetComponent<Image>().name + "Ball", 1);
                PlayerPrefs.SetInt("skinNumBall", skinNum);
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - skinBalls[skinNum].GetComponent<SkinControl>().Price);
            }
            else if(PlayerPrefs.GetInt(skinBalls[skinNum].GetComponent<Image>().name + "Ball") == 1)
                PlayerPrefs.SetInt("skinNumBall", skinNum);
        }
        else if (PlayerPrefs.GetString("ChooseProduct") == "Player")
        {
            if (!PlayerPrefs.HasKey(skinPlatforms[skinNum].GetComponent<Image>().name + "Player"))
                PlayerPrefs.SetInt(skinPlatforms[skinNum].GetComponent<Image>().name + "Player", 0);
            if (PlayerPrefs.GetInt(skinPlatforms[skinNum].GetComponent<Image>().name + "Player") == 0 && PlayerPrefs.GetInt("Coin") >= skinPlatforms[skinNum].GetComponent<SkinControl>().Price)
            {
                PlayerPrefs.SetInt(skinPlatforms[skinNum].GetComponent<Image>().name + "Player", 1);
                PlayerPrefs.SetInt("skinNumPlayer", skinNum);
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - skinPlatforms[skinNum].GetComponent<SkinControl>().Price);
            }
            else if(PlayerPrefs.GetInt(skinPlatforms[skinNum].GetComponent<Image>().name + "Player") == 1)
                PlayerPrefs.SetInt("skinNumPlayer", skinNum);
        }
    }
}