using UnityEngine;

public class CameraFrontFollow : MonoBehaviour
{
    public Transform player;
    public float distanceInFront = 3f;
    public float heightOffset = 0.5f;
    public float smoothSpeed = 5f;

    private Vector3 velocity = Vector3.zero;
    private float currentDirection = 1f;

    void LateUpdate()
    {
        float targetDirection = Mathf.Sign(player.localScale.x);

        // Smoothly interpolate the direction
        currentDirection = Mathf.Lerp(currentDirection, targetDirection, Time.deltaTime * smoothSpeed);

        Vector3 targetPos = player.position + new Vector3(currentDirection * distanceInFront, heightOffset, 0f);
        targetPos.z = -10f; // Keep Z fixed

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1f / smoothSpeed);
    }
}
