using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer = 0f;
    private Player player;
    private void Start()
    {
        player = GameObject.FindObjectOfType(typeof(Player)) as Player;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 8f)
        {
            player.Die();
        }
    }
    public void ResetTimer()
    {
        timer = 0f;
    }
}
