using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int playerLives = 3;
    public int playerCoin = 0;
    public Text TextLives;
    public Text TextCoins;
    public GameObject panel, ObjectGameOver, ObjectLevelComplete;
    private GameObject platform, ball;

    [SerializeField] private RewardedAds rAds;
    void Start()
    {
        platform = GameObject.FindGameObjectsWithTag("Player")[0];
        ball = GameObject.FindGameObjectsWithTag("Ball")[0];
        playerCoin = PlayerPrefs.GetInt("Coin");
        TextCoins.text = playerCoin.ToString().PadLeft(4, '0');
    }

    void Update()
    {
        GameOverOpen();
        LevelComplete();
    }

    private void addPoints(int points)
    {
        if(playerCoin <= 9999)
        {
            playerCoin += points;
            TextCoins.text = playerCoin.ToString().PadLeft(4, '0');
        }
    }

    private void TakeLife()
    {
        playerLives--;
        TextLives.text = playerLives.ToString();
        if(playerLives == 0)
        {
            rAds.LoadAds();
        }
    }
    private void GiveLife()
    {
        playerLives = 1;
        TextLives.text = playerLives.ToString();
        ObjectGameOver.SetActive(false);
        panel.SetActive(false);
        platform.GetComponentInChildren<MoveObjectPC>().Speed = 30f;
        ball.GetComponentInChildren<MoveBall>().speed = 25f;
    }

    private void GameOverOpen()
    {
        if(playerLives == 0)
        {
            panel.SetActive(true);
            ObjectGameOver.SetActive(true);
            platform.GetComponentInChildren<MoveObject>().speed = 0f;
            platform.GetComponentInChildren<MoveObjectPC>().Speed = 0;
            ball.GetComponentInChildren<MoveBall>().speed = 0;
        }
    }

    private void LevelComplete()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            if(SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings - 4)
                PlayerPrefs.SetInt("level" + SceneManager.GetActiveScene().buildIndex + 1 + "Open", 1);

            panel.SetActive(true);
            ObjectLevelComplete.SetActive(true);
            platform.GetComponentInChildren<MoveObject>().speed = 0f;
            platform.GetComponentInChildren<MoveObjectPC>().Speed = 0f;
            ball.GetComponentInChildren<MoveBall>().speed = 0f;
            PlayerPrefs.SetInt("Coin", playerCoin);
        }
    }
}
