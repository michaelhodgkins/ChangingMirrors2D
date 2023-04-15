using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100;
    public float maxHealth = 100;
    public AudioSource deathAudio;
    public SpriteRenderer sr;
    public GameObject healthBar;
    public Image healthBarImage;
    public TextMeshProUGUI healthText;
    public PlayerController player;


    private void Start()
    {
        health = maxHealth;
        healthText.text = health + "/" + maxHealth;

    }

    private void Update()
    {
        
    }

    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1f);
        healthText.text = health + "/" + maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealthBar();
        StartCoroutine(ColorSwitch());

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator ColorSwitch()
    {
        sr.color = Color.red;
        yield return new WaitForSecondsRealtime(0.2f);
        sr.color = Color.white;
    }

    void Die()
    {
       deathAudio.Play();
       SceneManager.LoadScene(0);
    }
}
