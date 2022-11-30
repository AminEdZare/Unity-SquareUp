using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIQ : MonoBehaviour
{
    [Header("Stats")]

    public int health;
    public int regen;
    public int XP;

    public float speed;
    public float shotFrequency;

    private float timeBtwShots;

    [Header("Distances")]

    public float distanceRange;
    public float retreatRange;

    [Header("Objects")]

    public GameObject projectile;
    public GameObject deathEffect;

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBtwShots = shotFrequency;
    }

    void Update()
    {
        
        if (health <= 0)
        {
            Score.scoreValue += XP;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().PlayerRegen(regen);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>().RunPulse();
        }
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) > distanceRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < distanceRange && Vector2.Distance(transform.position, target.position) > retreatRange)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.position) < retreatRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = shotFrequency;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
