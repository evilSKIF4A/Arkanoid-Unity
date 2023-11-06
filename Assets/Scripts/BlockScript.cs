using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private int hitsToKill;
    [SerializeField]
    private int points;
    private int numberOfHits;

    void Start()
    {
        numberOfHits = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            numberOfHits++;

            if(hitsToKill == numberOfHits)
            {
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
                player.SendMessage("addPoints", points);
                Destroy(this.gameObject);
            }
        }
    }
}
