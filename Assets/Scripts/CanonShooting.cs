using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletPos;
    [HideInInspector] public bool isReadyForShoot = false;
    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        GameObject bullet = GetComponent<ObjectPool>().GetPooledObject();
        bullet.SetActive(true);
        bullet.transform.position = bulletPos.position;
        bullet.transform.rotation = bulletPos.rotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 bulletVelocity = bulletPos.up * 5f;
        rb.velocity = bulletVelocity;
        isReadyForShoot = false;
    }
}
