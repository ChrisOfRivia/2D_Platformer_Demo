using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public float suckDuration = 1.5f;
    public float rotationSpeed = 720f;
    public float heightOffset = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SuckIntoPortal(other.transform));
        }
    }

    private System.Collections.IEnumerator SuckIntoPortal(Transform player)
    {
        Vector3 startScale = player.localScale;
        Vector3 endScale = Vector3.zero;
        float elapsed = 0f;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        while (elapsed < suckDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / suckDuration;

            player.localScale = Vector3.Lerp(startScale, endScale, t);
            player.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            Vector3 targetPosition = transform.position + Vector3.up * heightOffset;
            player.position = Vector3.Lerp(player.position, targetPosition, t * 0.1f);

            yield return null;
        }


        player.gameObject.SetActive(false);
    }
}
