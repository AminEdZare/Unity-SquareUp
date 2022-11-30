using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    [Header("Projectile Stats")]

    public float speed;
    public float lifetime;
    public float distance;

    public int damage;

    [Header("Objects")]

    public LayerMask whatIsSolid;

    public GameObject destroyEffect;
    public GameObject dissappearEffect;

    private void Start()
    {
        Invoke("SlowDestroyProjectile", lifetime);
    }


    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyIQ>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void SlowDestroyProjectile()
    {
        Instantiate(dissappearEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
