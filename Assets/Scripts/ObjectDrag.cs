using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    private BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        if (!IsCollidingWithPlayer())
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }
    private bool IsCollidingWithPlayer()
    {
        // Sprawd� kolizj� z obiektami o tagu "Player" przy u�yciu overlap box
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true; // Je�li jest kolizja z graczem, zwr�� true
            }
        }

        return false; // Je�li nie ma kolizji z graczem, zwr�� false
    }
}
