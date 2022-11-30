using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private float timeBtwShots;

    [Header("Weapon Stats")]

    public float shotFrequency;

    [Header("Objects")]

    public GameObject projectile;
    public Transform shotPoint;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = shotFrequency;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}
