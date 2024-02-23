using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPad : MonoBehaviour
{
    private PlayerMovementController playerMovementController;

    private void Start()
    {
        playerMovementController = GameObject.FindObjectOfType(typeof(PlayerMovementController)) as PlayerMovementController;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Pads").GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("Start");
            playerMovementController.Flip();
        }
    }
}
