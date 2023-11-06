using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speed;
    public AudioSource audioSource;
    public AudioClip sound;
    [SerializeField] private GameObject platform;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private Vector2 lastVelocity;


    void Start()
    {
        ballInitialForce = new Vector2(10.0f * speed, 30.0f * speed);

        ballIsActive = false;

        ballPosition = transform.position;
    }

    void Update()
    {
        if (speed != 0)
        {
            if (Input.GetButtonDown("Jump") == true)
            {
                if (!ballIsActive)
                {
                    GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
                    ballIsActive = !ballIsActive;
                }
            }
            if (!ballIsActive && platform != null)
            {

                ballPosition.x = platform.transform.position.x;

                transform.position = ballPosition;
            }
            if (ballIsActive && transform.position.y <= -8.5f)
            {
                ballIsActive = !ballIsActive;
                ballPosition.x = platform.transform.position.x;
                ballPosition.y = -7.238f;
                transform.position = ballPosition;

                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                platform.SendMessage("TakeLife");
            }
        }
    }
    public void PushBall()
    {
        if (!ballIsActive)
        {
            GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
            ballIsActive = !ballIsActive;
        }
    }

    private void FixedUpdate()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        if(PlayerPrefs.GetInt("OnSound") == 1)
            audioSource.PlayOneShot(sound);
    }
}
