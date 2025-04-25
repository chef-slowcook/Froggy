using UnityEngine;

// Component class for aiming the tongue
public class TongueAim : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb2d;
    [Header("Rotation Parameters")]
    [SerializeField] private float rotationSpeed = 100f;

    [Header("Tongue-Line Parameters")]
    [SerializeField] private int _segmentCount = 20;
    private LineRenderer _lineRenderer;
    private float elapsedTime = 0f;
    public float maxTime = 2f;

    void Start()
    {
        if (_lineRenderer == null) _lineRenderer = GetComponent<LineRenderer>();
        LineRendererSettings();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TongueRotation(Transform tonguePivot)
    {
        if (rb2d.bodyType != RigidbodyType2D.Kinematic)
        {
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            rb2d.linearVelocity = Vector2.zero;
        }
        // Get the target direction
        Vector3 aimDirection = MouseAssistant.DirectionToMouse(tonguePivot);
        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.right, aimDirection);

        // Smoothly rotate towards the target rotation
        tonguePivot.rotation = Quaternion.RotateTowards(
            tonguePivot.rotation, // current rotation
            targetRotation, //       new rotation
            rotationSpeed * Time.deltaTime * 100f
        );
        rb2d.MovePosition(tonguePivot.position + (Vector3)aimDirection * 0.1f);
        elapsedTime = 0f; // Reset elapsed time when aiming
    }

    public void DrawTongueLine(Vector3 startPos, Vector3 endPos)
    {
        // Calculate direction and distance
        Vector3 direction = (endPos - startPos).normalized;
        float distance = Vector3.Distance(startPos, endPos);

        // Use a static timer to track elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate straightness factor (0 to 1)
        float straightness = Mathf.Clamp01(elapsedTime / maxTime);

        // Fill segments array with points along the line
        for (int i = 0; i < _segmentCount; i++)
        {
            float t = i / (float)(_segmentCount - 1);
            // Linear interpolation between start and end positions
            Vector3 point = Vector3.Lerp(startPos, endPos, t);

            // Add wavy pattern to the tongue line, reduced by straightness factor
            float waveFrequency = 5f; // Number of waves
            float waveAmplitude = 0.1f * (1f - straightness); // Reduce amplitude as straightness increases
            float waveOffset = Mathf.Sin(t * waveFrequency * Mathf.PI) * waveAmplitude;
            Vector3 perpendicular = Vector3.Cross(direction, Vector3.forward) * waveOffset;

            // Apply the position to the line renderer
            _lineRenderer.SetPosition(i, point + perpendicular);
        }
    }

    private void LineRendererSettings()
    {
        _lineRenderer.positionCount = _segmentCount;
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.03f;
        _lineRenderer.startColor = Color.red;
    }
}
