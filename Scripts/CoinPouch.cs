using UnityEngine;

public class CoinPouch : MonoBehaviour
{
    public Rigidbody2D rb;
    public int coins;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            Debug.Log("Coins: " + coins);
        }
    }
}
