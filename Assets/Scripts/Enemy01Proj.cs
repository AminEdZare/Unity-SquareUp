using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Proj : MonoBehaviour
{

    [Header("Projectile Stats")]

    public float speed;
    public float offset;
    public float lifetime;

    public int damage;

    private float direction;
    private Transform player;
    private Vector2 target;

    [Header("Objects")]

    public GameObject damageEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        Invoke("DestroyProjectile", lifetime);

    }

    void Update()
    {
        //move direction to void start and replace player.position to target if homing is to be disabled.

        direction = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, direction + offset);

        //this if statement is useless if homing is enabled, can be removed.

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().PlayerDamage(damage);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Instantiate(damageEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
