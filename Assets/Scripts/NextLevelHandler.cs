using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHandler : MonoBehaviour
{
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings - 4)
        {
            PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("level" + (SceneManager.GetActiveScene().buildIndex + 1).ToString() + "Open", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
