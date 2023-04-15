using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("potion"))
        {
            PlayerHealth health = GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.maxHealth += 20;
                health.health += 20;
                health.UpdateHealthBar();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("scroll"))
        {
            Weapon weapon = GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.fireRate = 0.5f;
            }
            Destroy(collision.gameObject);

        }
        else if(collision.CompareTag("dmg"))
        {
            Weapon weapon = GetComponentInChildren<Weapon>();
            if (weapon != null)
            {
                weapon.damage += 50f;
            }
            Destroy(collision.gameObject);
        }
    }
}
