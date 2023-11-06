using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject panel, ObjectMenu;
    private GameObject platform, ball;
    private void Start()
    {
        platform = GameObject.FindGameObjectsWithTag("Player")[0];
        ball = GameObject.FindGameObjectsWithTag("Ball")[0];
    }
    public void MenuOpen()
    {
        panel.SetActive(true);
        ObjectMenu.SetActive(true);
        platform.GetComponentInChildren<MoveObjectPC>().Speed = 0;
        ball.GetComponentInChildren<MoveBall>().speed = 0;
    }

    public void MenuClose()
    {
        ObjectMenu.SetActive(false);
        panel.SetActive(false);
        platform.GetComponentInChildren<MoveObjectPC>().Speed = 30;
        ball.GetComponentInChildren<MoveBall>().speed = 25;
    }

}
