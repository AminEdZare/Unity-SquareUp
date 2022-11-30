using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Spawn Stats")]

    [SerializeField]
    private float spawnRadius = 7;
    [SerializeField]
    private float time = 1.5f;

    public float timeBtwEffAndSpawn;

    [Header("Spawn Objects")]

    public GameObject spawnEffect;
    public GameObject[] enemies;

    void Start ()
    {
        StartCoroutine(SpawnAnEnemy());
    }
	
	IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(spawnEffect, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(timeBtwEffAndSpawn);

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        

        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
