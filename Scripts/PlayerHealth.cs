using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public PlayerInput playerInput;
    public Animator animator;

    public Sprite deadPlayer;
    public Sprite alivePlayer;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public Image[] heartImages;

    public PlayerMovement playerMovement;
    public SpriteRenderer playerSpriteRenderer;

    public Canvas deathScreen;
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            deathScreen.enabled = true;

            health = 0;
            animator.enabled = false;
            playerMovement.enabled = false;
            playerInput.enabled = false;


            // Replace with dead sprite
            playerSpriteRenderer.sprite = deadPlayer;

            // Rotate the character to 90 degrees on Z axis 
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }


    void Update()
    {
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            int heartValue = i * 2;

            if (health >= heartValue + 2)
            {
                heartImages[i].sprite = fullHeart;
            }
            else if (health == heartValue + 1)
            {
                heartImages[i].sprite = halfHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

}
