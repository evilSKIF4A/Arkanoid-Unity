using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBorders : MonoBehaviour
{
    [SerializeField]
    private float StandartHeight, StandartWidth;
    [SerializeField]
    private GameObject[] Wall;
    private Vector2[] _coordinatesWall;
    private float NewHeight, NewWidth;

    void Start()
    {
        _coordinatesWall = new Vector2[Wall.Length];
        for(int i = 0; i < Wall.Length; ++i)
            _coordinatesWall[i] = Wall[i].transform.position;
        NewHeight = Screen.height;
        UpdateWall();
    }

    void Update()
    {
        UpdateWall();
        NewHeight = Screen.height;
        NewWidth = Screen.width;
    }

    private void UpdateWall()
    {
        if (NewHeight > StandartHeight)
            for (int i = 0; i < Wall.Length; ++i)
                Wall[i].transform.position = new Vector2(_coordinatesWall[i].x * StandartHeight / NewHeight, _coordinatesWall[i].y);
    }
}
