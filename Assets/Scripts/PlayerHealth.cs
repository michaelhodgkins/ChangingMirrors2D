using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public TextMeshProUGUI healthDisplay;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        healthDisplay.text = "Health: " + health;
    }

    void Die()
    {
        Debug.Log("You died");
        SceneManager.LoadScene(0);
    }
}
