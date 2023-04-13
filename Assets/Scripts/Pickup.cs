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
                health.health += 20;
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
    }
}
