using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            player.score++;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
   
}
