using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float damage = 10;
    public bool hasHit = false;
    public float speed;
    int collisionDmg = 50;
    PlayerController player;
    public float experiencePoints = 10;
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

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(DamageTimer());
        if (health <= 0)
        {
            player.xp += experiencePoints;
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
