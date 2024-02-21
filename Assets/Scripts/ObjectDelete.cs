using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    private Vector2 size;
    private Vector2 offset;
    [SerializeField] private float bonusSize;
    private void Start()
    {
        transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
        size = GetComponent<BoxCollider2D>().size;
        offset = GetComponent<BoxCollider2D>().offset;
    }
    public void DeleteObject()
    {
        Time.timeScale = 1f;
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
                GetComponent<BoxCollider2D>().size = new Vector2(size.x + bonusSize, size.y);
                GetComponent<BoxCollider2D>().offset = new Vector2(offset.x - (bonusSize / 2), offset.y);
                transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                GetComponent<BoxCollider2D>().size = new Vector2(size.x, size.y);
                GetComponent<BoxCollider2D>().offset = new Vector2(offset.x, offset.y);
                transform.Find("Canvas").transform.Find("Button").gameObject.SetActive(false);
            }
        }
    }
}
