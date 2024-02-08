using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovementController playerMovementController;
    private Rigidbody2D rb;
    private void Awake()
    {
        playerMovementController = GameObject.FindObjectOfType(typeof(PlayerMovementController)) as PlayerMovementController;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Death");
        this.enabled = false;
        playerMovementController.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
