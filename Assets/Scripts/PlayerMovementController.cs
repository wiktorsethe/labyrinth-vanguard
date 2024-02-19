using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool facingRight = true;
    [SerializeField] private Transform obstacleDetector;
    [SerializeField] private Vector2 size;
    private RaycastHit2D obstacleHit;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if(!facingRight) transform.Translate(Vector2.left * speed * Time.deltaTime);
        else if(facingRight) transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (!CanMove())
        {
            Flip();
        }
    }
    private bool CanMove()
    {
        if (!facingRight) obstacleHit = Physics2D.BoxCast(obstacleDetector.position, size, 0, Vector2.left, 0.1f);
        else if(facingRight) obstacleHit = Physics2D.BoxCast(obstacleDetector.position, size, 0, Vector2.right, 0.1f);

        if (obstacleHit.collider != null && !obstacleHit.collider.CompareTag("Pad") && !obstacleHit.collider.CompareTag("Gem"))
        {
            return false;
        }
        return true;
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 startPosition = obstacleDetector.position;
        Vector2 direction = Vector2.right;
        Gizmos.DrawWireCube(startPosition + direction * size.x * 0.5f, size);
    }
}
