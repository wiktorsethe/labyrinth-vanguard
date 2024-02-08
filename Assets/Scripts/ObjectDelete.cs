using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    private void Start()
    {
        transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
    }
    public void DeletePlatform()
    {
        Time.timeScale = 1f;
        Debug.Log("Platform Deleted");
        Destroy(gameObject);
    }
    public void DeleteJumpPad()
    {
        Time.timeScale = 1f;
        Debug.Log("Jump Pad Deleted");
        Destroy(gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                Time.timeScale = 0.1f;
                GetComponent<BoxCollider2D>().size = new Vector2(9f, 1.6f);
                GetComponent<BoxCollider2D>().offset = new Vector2(-1f, 0f);
                transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                GetComponent<BoxCollider2D>().size = new Vector2(7f, 1.6f);
                GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
            }
        }
    }
}
