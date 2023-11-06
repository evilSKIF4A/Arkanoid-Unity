using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] spritesOpen;
    public Sprite[] spritesClose;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("level1Open"))
            PlayerPrefs.SetInt("level1Open", 1);
        for(int i = 2; i <= 20; i++)
            if (!PlayerPrefs.HasKey("level" + i.ToString() + "Open"))
                PlayerPrefs.SetInt("level" + i.ToString() + "Open", 0);

        for(int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetInt("level" + i.ToString() + "Open") == 1)
                buttons[i - 1].GetComponent<Image>().sprite = spritesOpen[i - 1];
            else
                buttons[i - 1].GetComponent<Image>().sprite = spritesClose[i - 1];
        }
    }
}
