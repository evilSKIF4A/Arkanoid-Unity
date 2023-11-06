using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignSkin : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Platform;
    public Sprite[] skinBalls;
    public Sprite[] skinPlatforms;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("skinNumBall"))
            PlayerPrefs.SetInt("skinNumBall", 0);
        if (!PlayerPrefs.HasKey("skinNumPlayer"))
            PlayerPrefs.SetInt("skinNumPlayer", 0);

        Ball.GetComponent<SpriteRenderer>().sprite = skinBalls[PlayerPrefs.GetInt("skinNumBall")];
        Platform.GetComponent<SpriteRenderer>().sprite = skinPlatforms[PlayerPrefs.GetInt("skinNumPlayer")];
    }
}
