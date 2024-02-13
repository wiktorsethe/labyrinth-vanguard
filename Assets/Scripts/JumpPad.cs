using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            float jumpForce = 10f;
            Vector2 velocity = otherRigidbody.velocity;
            otherRigidbody.AddForce(Vector2.up * (velocity.magnitude + jumpForce), ForceMode2D.Impulse);
        }
    }
}
