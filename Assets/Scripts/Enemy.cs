using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float damage = 10;
    public bool hasHit = false;
    public float speed;
    int collisionDmg = 50;
    PlayerController player;
    public float experiencePoints = 10;
    public GameObject healthBar;
    public Image healthBarImage;
    public Rigidbody2D enemyRb;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        health = maxHealth;
    }

     void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        healthBar.gameObject.transform.position = this.transform.position;
    }

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
        
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
        UpdateHealthBar();
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
