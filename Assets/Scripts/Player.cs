using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isWalled;
    public LayerMask whatIsWall;

    [SerializeField] SpriteRenderer playerImage;
    [SerializeField] Animator playerAnimator;
    [SerializeField] SpriteRenderer accessoryImage;
    [SerializeField] TrailRenderer trailMaterial;
    bool facingRight;
    float move;

    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource collectSound;

    [SerializeField] GameObject diamondsPickup;
    //public SaveManager save;
    //public PlayerData playerData;
    int collectItems;
    private void Start()
    {
        //save = GameObject.FindObjectOfType(typeof(SaveManager)) as SaveManager;
        collectItems = 0;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        //ChangePlayerSkin();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsWall);
        //playerAnimator.SetFloat("speed", Mathf.Abs(rb.velocity.y));

    }

    public void Push(Vector2 force)
    {
        if (isGrounded || isWalled)
        {
            rb.AddForce(force, ForceMode2D.Impulse);

            //jumpSound.Play();

            move = rb.velocity.x;
            if (move > 0 && facingRight)
            {
                Flip();
            }
            if (move < 0 && !facingRight)
            {
                Flip();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            move = rb.velocity.x;
            if (move > 0 && facingRight)
            {
                Flip();
            }
            if (move < 0 && !facingRight)
            {
                Flip();
            }
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collect"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            //GameDataMenager.AddDiamonds(3);
            playerData.diamonds += 3;
            collectItems += 3;
            Instantiate(diamondsPickup, collision.gameObject.transform.position, Quaternion.identity);
            if (collectItems >= PlayerPrefs.GetInt("collectItems"))
            {
                PlayerPrefs.SetInt("collectItems", collectItems);
            }
            save.LocalSaveGame();
        }
    }
    
    public void ChangePlayerSkin()
    {
        Outfit outfit = playerData.GetSelectedOutfit();
        Accessory accessory = playerData.GetSelectedAccessory();
        Trail trail = playerData.GetSelectedTrail();
        if (outfit.image != null)
        {
            playerImage.sprite = outfit.image;
        }
        if (outfit.animator != null)
        {
            playerAnimator.runtimeAnimatorController = outfit.animator;
        }
        if (accessory.image != null)
        {
            accessoryImage.sprite = accessory.image;
        }
        if (trail.image != null)
        {
            trailMaterial.material = trail.image;
        }
    
    }*/
}
