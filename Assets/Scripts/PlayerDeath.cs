using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    //public RectTransform menu;
    //public GameObject gameMenu;
    //public ScoreManager scoreManager;
    //[SerializeField] AudioSource deathSound;
    [SerializeField] bool isPlaying = false;
    private float speed = 0.3f;
    private PlayerMovementController playerMovementController;
    //[SerializeField] AudioSource music;
    //public Animator deathAnimator;
    //public SpriteRenderer deathSprite;
    //public SaveManager save;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //save = GameObject.FindObjectOfType(typeof(SaveManager)) as SaveManager;
        playerMovementController = GameObject.FindObjectOfType(typeof(PlayerMovementController)) as PlayerMovementController;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            //scoreManager.UpdateScore((int)transform.position.y);

        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Die();
        }

    }

    public void Die()
    {
        //music.Pause();
        this.GetComponent<Player>().enabled = false;
        for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length; i++)
        {
            this.GetComponentsInChildren<SpriteRenderer>()[i].enabled = false;
        }
        playerMovementController.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        //gameMenu.SetActive(false);
        //menu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);

        if (!isPlaying)
        {
            StartCoroutine(playDeath());
        }
        //save.SaveGameBoth();
    }
    IEnumerator playDeath()
    {
        isPlaying = true;
        //deathSprite.enabled = true;
        //deathAnimator.SetInteger("death", 1);
        //deathSound.Play();
        yield return new WaitForEndOfFrame();
    }
}
