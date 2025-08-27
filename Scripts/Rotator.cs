using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotateX = 0f; // degrees per second
    public float rotateY = 0f; // degrees per second
    public float rotateZ = 0f; // degrees per second

    void Update()
    {
        transform.Rotate(rotateX, rotateY, rotateZ * Time.deltaTime);
    }
}
