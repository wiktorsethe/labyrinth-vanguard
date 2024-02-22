using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovementController playerMovementController;
    private Rigidbody2D rb;
    private LevelMenu lvlMenu;
    private void Awake()
    {
        playerMovementController = GameObject.FindObjectOfType(typeof(PlayerMovementController)) as PlayerMovementController;
        lvlMenu = GameObject.FindObjectOfType(typeof(LevelMenu)) as LevelMenu;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GameObject spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        transform.position = spawn.transform.position;
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
        lvlMenu.Death();
        playerMovementController.enabled = false;
        GetComponent<Animator>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
