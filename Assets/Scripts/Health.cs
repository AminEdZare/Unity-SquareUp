using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    [Header("Health")]

    public int health;
    public int numOfHearts;

    [Header("Objects")]

    public GameObject playerDeathEffect;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().GameOver();
        }
    }

    public void PlayerDamage(int damage)
    {
        health -= damage;
    }

    public void PlayerRegen(int regen)
    {
        health += regen;
    }


}
