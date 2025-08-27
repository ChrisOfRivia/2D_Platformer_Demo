using UnityEngine;

public class PassablePlatform : MonoBehaviour
{
    public Rigidbody2D playerBody;
    void Update()
    {
        if(playerBody.position.y < transform.position.y - 0.2f)
        {
            // If the player is below the platform, disable the collider
            GetComponent<Collider2D>().enabled = false;
        }
        else if (playerBody.position.y > transform.position.y + 2f)
        {
            // If the player is above the platform, enable the collider
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
