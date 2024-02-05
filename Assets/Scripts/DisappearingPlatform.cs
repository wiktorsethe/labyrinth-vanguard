using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private float timer;
    private bool disapered = false;
    private Component[] colliders;
    private void Start()
    {
        colliders = gameObject.GetComponents<BoxCollider2D>();
    }
    private void Update()
    {
        if (disapered)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                timer = 0;
                disapered = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                foreach (BoxCollider2D collider in colliders)
                {
                    collider.enabled = true;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("SetActive", 3f);
        }
    }
    private void SetActive()
    {
        disapered = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
