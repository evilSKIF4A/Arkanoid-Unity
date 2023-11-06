using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public Button buttonSound;
    public Sprite soundOn;
    public Sprite soundOff;
    void Start()
    {
        if (!PlayerPrefs.HasKey("OnSound"))
            PlayerPrefs.SetInt("OnSound", 1);
        ChangeSprite(PlayerPrefs.GetInt("OnSound"));
    }
    public void ButtonSound()
    {
        PlayerPrefs.SetInt("OnSound", PlayerPrefs.GetInt("OnSound") == 0 ? 1 : 0);
        ChangeSprite(PlayerPrefs.GetInt("OnSound"));
    }
    private void ChangeSprite(int onSound)
    {
        buttonSound.GetComponent<Image>().sprite = onSound == 1 ? soundOn : soundOff;
    }
}
