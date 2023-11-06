using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour
{
    public float speed;
    public float normalSpeed = 5.0f;
    //public GameObject platform;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = 0.0f;
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }
    public void OnLeftButtonDown()
    {
        if(speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }
    public void OnRightButtonDown()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }
    public void OnButtonUp()
    {
        speed = 0.0f;
    }
}
