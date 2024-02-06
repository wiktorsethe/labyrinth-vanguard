using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    [Header("Components")]
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer playerImage;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private Transform groundCheck;
    [Space(10f)]

    [Header("Variables")]
    [SerializeField] private float checkRadius;
    private float move;

    private bool isGrounded;
    private bool facingRight;
    private bool isDeath = false;
    private bool isWalled;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    [Space(10f)]

    [Header("Other Scripts")]
    float x;
    //private PlayerMovementController playerMovementController;
    //public SaveManager save;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //ChangePlayerSkin();
    }
    private void Start()
    {
        //save = GameObject.FindObjectOfType(typeof(SaveManager)) as SaveManager;
        //playerMovementController = GameObject.FindObjectOfType(typeof(PlayerMovementController)) as PlayerMovementController;
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
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Die();
        }
    }
    private void Flip()
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
    public void Die()
    {
        //music.Pause();
        Debug.Log("Death");
        this.GetComponent<Player>().enabled = false;
        for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length; i++)
        {
            this.GetComponentsInChildren<SpriteRenderer>()[i].enabled = false;
        }
        //playerMovementController.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        //gameMenu.SetActive(false);
        //menu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);

        if (!isDeath)
        {
            StartCoroutine(playDeath());
        }
        //save.SaveGameBoth();
    }
    private IEnumerator playDeath()
    {
        isDeath = true;
        //deathSprite.enabled = true;
        //deathAnimator.SetInteger("death", 1);
        //deathSound.Play();
        yield return new WaitForEndOfFrame();
    }
    /*
    public void ChangePlayerSkin()
    {
        Outfit outfit = playerData.GetSelectedOutfit();
        if (outfit.image != null)
        {
            playerImage.sprite = outfit.image;
        }
        if (outfit.animator != null)
        {
            playerAnimator.runtimeAnimatorController = outfit.animator;
        }
    }*/
}
