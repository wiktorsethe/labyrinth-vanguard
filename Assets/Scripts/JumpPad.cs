using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("Start");

        Rigidbody2D otherRigidbody = collision.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            GameObject.FindGameObjectWithTag("Pads").GetComponent<AudioSource>().Play();
            float jumpForce = 10f;
            Vector2 velocity = otherRigidbody.velocity;
            otherRigidbody.AddForce(Vector2.up * (velocity.magnitude + jumpForce), ForceMode2D.Impulse);
            GameObject.FindGameObjectWithTag("Jump").GetComponent<AudioSource>().Play();
            Debug.Log(velocity + ", " + (Vector2.up * (velocity.magnitude + jumpForce), ForceMode2D.Impulse));
        }
    }
}
