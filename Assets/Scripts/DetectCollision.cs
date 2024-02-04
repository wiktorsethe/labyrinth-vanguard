using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Wall"))
        {
            gameManager.ResetTimer();
        }
    }
}
