using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectPC : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(moveHorizontal, 0);

        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
}
