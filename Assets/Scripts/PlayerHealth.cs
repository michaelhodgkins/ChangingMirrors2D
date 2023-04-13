using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health = 0;
    public TextMeshProUGUI healthDisplay;
    public AudioSource deathAudio;
    public SpriteRenderer sr;

    public void TakeDamage(int damage)
    {
        health -= damage;
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

    private void Update()
    {
        healthDisplay.text = "Health: " + health;
    }

    void Die()
    {
       deathAudio.Play();
       SceneManager.LoadScene(0);
    }
}
