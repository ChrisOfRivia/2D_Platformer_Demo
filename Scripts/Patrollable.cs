using UnityEngine;

public class Patrollable : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public int patrolDestination = 0;
    public bool collidable = false;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[patrolDestination];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            FlipDirection();
            patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
        }
    }

    private void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collidable)
        {
            // Optional: Add a layer check here if you want to ignore certain collisions
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            FlipDirection();

            // Reverse patrol direction
            if (patrolPoints.Length > 1)
            {
                // Move to the previous patrol point instead
                patrolDestination = (patrolDestination - 1 + patrolPoints.Length) % patrolPoints.Length;
            }
        }

    }
}
