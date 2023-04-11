using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health = 0;
    public TextMeshProUGUI healthDisplay;
    public AudioSource deathAudio;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(DeathTimer());
            Die();
        }
    }

    private void Update()
    {
        healthDisplay.text = "Health: " + health;
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSecondsRealtime(5);
    }
    void Die()
    {
       deathAudio.Play();
       SceneManager.LoadScene(0);
    }
}
