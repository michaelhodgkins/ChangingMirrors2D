using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed;

    PlayerController player;

     void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

     void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
