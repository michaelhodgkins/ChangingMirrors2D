using System.Collections;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public bool hasHit = false;
    public float speed;
    int collisionDmg = 50;
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
            this.TakeDamage(collisionDmg);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageTimer());
        if (health <= 0)
        {
            player.score++;
            
            Die();
        }
    }

    IEnumerator DamageTimer()
    {
        if (hasHit)
        {
            yield return new WaitForSecondsRealtime(2);
            hasHit = false;
        }

    }

    void Die()
    {
       
            Destroy(gameObject);
    }
   
}
