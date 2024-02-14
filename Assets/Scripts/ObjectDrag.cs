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
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;

        if (IsCollidingWithPlayer())
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            if(!GetComponent<Collider2D>().enabled)
            GetComponent<Collider2D>().enabled = true;
        }
    }
    private bool IsCollidingWithPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
