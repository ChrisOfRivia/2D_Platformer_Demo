using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.right;
    public float lengthOfCast = 10f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, startPosition) >= lengthOfCast)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        if (other.CompareTag("Weak Point"))
        {
            Destroy(other.transform.parent.gameObject); // Enemy
            Destroy(gameObject); // Fireball

        }
    }

}
