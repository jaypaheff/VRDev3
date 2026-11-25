using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class BallRallyTracker : MonoBehaviour
{
    [Header("UI (Optional)")]
    public TextMeshProUGUI scoreText;

    [Header("Respawn Settings")]
    public Transform spawnPoint;
    [Tooltip("Set this slightly above your floor's Y position (e.g., 0.05 if floor is at Y = 0)")]
    public float minHeight = 0.05f;

    private int hitCount = 0;
    private float lastHitTime = 0f;
    private Rigidbody rb;
    private Vector3 defaultStartPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultStartPos = spawnPoint != null ? spawnPoint.position : transform.position;
        UpdateScoreUI();
    }

    void Update()
    {
        // Failsafe: respawns the ball if it touches floor height or falls through
        if (transform.position.y <= minHeight)
        {
            ResetRally();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Prints what the ball hits in the Console so you can verify tags
        Debug.Log("Ball hit: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

        // Count paddle hits (0.2s cooldown prevents double-counting one swing)
        if (collision.gameObject.CompareTag("Paddle") && Time.time - lastHitTime > 0.2f)
        {
            hitCount++;
            lastHitTime = Time.time;
            UpdateScoreUI();
        }

        // Respawn when touching anything tagged "Floor"
        if (collision.gameObject.CompareTag("Floor"))
        {
            ResetRally();
        }
    }

    public void ResetRally()
    {
        hitCount = 0;
        UpdateScoreUI();

        // Use rb.linearVelocity instead of rb.velocity if you are on Unity 6
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();

        Vector3 targetPos = spawnPoint != null ? spawnPoint.position : defaultStartPos;
        rb.position = targetPos;
        transform.position = targetPos;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Hits: " + hitCount;
        }
    }
}
