using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;

    [Header("Volume Scaling (Bonus)")]
    [SerializeField] private float minVelocityToPlay = 0.1f;
    [SerializeField] private float maxVelocityForMaxVolume = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Automatically fetch the AudioSource if not assigned manually
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check relative velocity magnitude to determine how hard the impact was
        float hitSpeed = collision.relativeVelocity.magnitude;

        // Prevent tiny micro-bounces from triggering sound loops
        if (hitSpeed > minVelocityToPlay && bounceSound != null && audioSource != null)
        {
            // Calculate dynamic volume proportional to the impact speed (Normalized between 0 and 1)
            float volume = Mathf.InverseLerp(minVelocityToPlay, maxVelocityForMaxVolume, hitSpeed);

            // Play the sound once without interrupting other instances of it
            audioSource.PlayOneShot(bounceSound, volume);
        }
    }
}
