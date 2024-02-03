using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            //collectSound.Play();
            Destroy(collision.gameObject);
            playerData.gems += 3;
            //save.LocalSaveGame();
        }
    }
}
