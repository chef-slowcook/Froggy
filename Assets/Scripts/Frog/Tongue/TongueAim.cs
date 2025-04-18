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

    void Start()
    {
        if (_lineRenderer == null) _lineRenderer = GetComponent<LineRenderer>();
        LineRendererSettings();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void TongueRotation(Transform tonguePivot)
    {
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
    }

    public void DrawTongueLine(Vector3 startPos, Vector3 endPos)
    {
        // Calculate direction and distance
        Vector3 direction = (endPos - startPos).normalized;
        float distance = Vector3.Distance(startPos, endPos);

        // Fill segments array with points along the line
        for (int i = 0; i < _segmentCount; i++)
        {
            float t = i / (float)(_segmentCount - 1);
            // Linear interpolation between start and end positions
            Vector3 point = Vector3.Lerp(startPos, endPos, t);

            // Add slight curve to make it look more tongue-like
            // Sine curve that's strongest in the middle
            float curveStrength = 0.1f * Mathf.Sin(t * Mathf.PI);
            Vector3 perpendicular = Vector3.Cross(direction, Vector3.forward) * curveStrength;

            // Apply the position to the line renderer
            _lineRenderer.SetPosition(i, point + perpendicular);
        }
    }

    private void LineRendererSettings()
    {
        _lineRenderer.positionCount = _segmentCount;
        _lineRenderer.startWidth = 0.05f;
        _lineRenderer.endWidth = 0.05f;
        _lineRenderer.startColor = Color.green;
        _lineRenderer.endColor = Color.yellow;
        Color endColor = _lineRenderer.endColor;
        endColor.a = 0.5f;
        _lineRenderer.endColor = endColor;
    }

}
