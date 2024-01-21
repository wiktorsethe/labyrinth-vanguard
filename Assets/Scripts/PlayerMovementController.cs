using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Camera cam;

    public Player player;
    public Trajectory trajectory;
    public float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isWalled;
    public LayerMask whatIsWall;
    public bool onGround = false;
    bool canJump = false;
    //---------------------------------------
    void Start()
    {
        cam = Camera.main;
        player.DesactivateRb();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsWall);

        if (isGrounded || isWalled)
        {
            onGround = true;
            if (Input.GetMouseButtonDown(0) && onGround)
            {
                isDragging = true;
                canJump = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0) && canJump)
            {
                isDragging = false;
                onGround = false;
                canJump = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();

            }
        }
    }

    //-Drag--------------------------------------
    void OnDragStart()
    {//ScreenToWorldPoint
        Ray point = cam.ScreenPointToRay(Input.mousePosition);
        startPoint = new Vector2(point.origin.x, point.origin.y);
        //startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
    }

    void OnDrag()
    {
        Ray point = cam.ScreenPointToRay(Input.mousePosition);
        endPoint = new Vector2(point.origin.x, point.origin.y);
        //endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //just for debug
        Debug.DrawLine(startPoint, endPoint);
        trajectory.UpdateDots(player.pos, force);
    }

    void OnDragEnd()
    {
        //push the ball
        player.ActivateRb();

        player.Push(force);

        trajectory.Hide();
    }
}
