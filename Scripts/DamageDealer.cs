using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public int damageAmount = 1;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
