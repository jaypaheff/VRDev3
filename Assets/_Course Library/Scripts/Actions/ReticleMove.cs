using UnityEngine;

public class ReticleMove : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float scaleAmount = 0.15f;
    public float scaleSpeed = 3f;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3, 0, Space.World);

        float scale = 1f + Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;

        transform.localScale = originalScale * scale;
    }
}
