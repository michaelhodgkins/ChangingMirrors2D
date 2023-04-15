using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int level = 1;
    public float xp = 0;
    [SerializeField] float requiredXp = 10;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;
    public Rigidbody2D rb;

    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        xpText.text = "XP: " + xp;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (xp >= requiredXp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        requiredXp *= 2;
        level++;
        levelText.text = "Level: " + level;
        Weapon weapon = GetComponentInChildren<Weapon>();
        weapon.fireRate -= 0.1f;
        weapon.damage += 5f;

    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement.normalized);
        

    }


}
