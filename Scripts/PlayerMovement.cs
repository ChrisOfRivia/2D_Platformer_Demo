using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public float horizontalMovement = 0;
    public float verticalMovement = 0;
    private bool facingRight = true;

    public float blinkDistance = 3f;

    public GameObject fireballPrefab;
    public float fireballOffset = 1.5f; // Distance from player

    public PlayerHealth playerHealth;

    public Animator animator;

    void Start()
    {

    }


    void Update()
    {
        // Movement
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);


        // Flip sprite based on direction
        if (horizontalMovement > 0 && !facingRight)
            Flip();
        else if (horizontalMovement < 0 && facingRight)
            Flip();

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f && animator.GetBool("isJumping"))
        {
            OnLanding(); // Reset jump animation
        }

        // Kill player if they fall off screen
        if (rb.position.y < -10f)
        {
            playerHealth.TakeDamage(6);
        }
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            animator.SetBool("isJumping", true);

        if (context.performed && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void Blink(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float direction = facingRight ? 1f : -1f;
            Vector2 newPosition = rb.position + new Vector2(blinkDistance * direction, 0);
            rb.MovePosition(newPosition);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float direction = facingRight ? 1f : -1f;
            Vector3 spawnPos = transform.position + new Vector3(fireballOffset * direction, 0, 0);

            GameObject fireball = Instantiate(fireballPrefab, spawnPos, Quaternion.identity);
            fireball.GetComponent<FireballMove>().direction = new Vector3(direction, 0, 0);

            // Flip the fireball's sprite if shooting left
            Vector3 fireballScale = fireball.transform.localScale;
            fireballScale.x = Mathf.Abs(fireballScale.x) * direction;
            fireball.transform.localScale = fireballScale;
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }






}