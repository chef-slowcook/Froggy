using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TongueAnimation : MonoBehaviour
{
    [Header("Tongue-Line Parameters")]
    [SerializeField, Range(2, 100), Tooltip("How detailed the tongue line is")] private int segmentCount = 60;
    [SerializeField, Range(0f, 20f)] private float waveFrequency = 10f;
    [SerializeField, Range(0f, 1f)] private float waveAmplitude = 0.1f;
    [SerializeField, Range(0f, 0.2f)] private float startWidth = 0.05f;
    [SerializeField, Range(0f, 0.2f)] private float endWidth = 0.02f;
    [SerializeField] private Color startColor = Color.red;
    private float straightness = 1f;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ApplyLineRendererSettings();
    }

    public void StartDrawing(Transform start, Transform end)
    {
        lineRenderer.enabled = true;
        StartCoroutine(DrawTongueLine(start, end));
    }

    /// Draws the tongue line with a wavy effect between two points.
    private IEnumerator DrawTongueLine(Transform start, Transform end)
    {
        while (lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            Vector3 direction = (end.position - start.position).normalized;
            for (int segmentIndex = 0; segmentIndex < segmentCount; segmentIndex++)
            {
                float normalizedTime = segmentIndex / (float)(segmentCount - 1);
                Vector3 point = Vector3.Lerp(start.position, end.position, normalizedTime);
                float waveOffset = Mathf.Sin(normalizedTime * waveFrequency * Mathf.PI) * waveAmplitude * straightness;
                Vector3 perpendicular = Vector3.Cross(direction, Vector3.forward) * waveOffset;
                lineRenderer.SetPosition(segmentIndex, point + perpendicular);
            }
            yield return null;
        }
    }

    public void StopDrawing()
    {
        lineRenderer.enabled = false;
    }

    private void ApplyLineRendererSettings()
    {
        lineRenderer.positionCount = segmentCount;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.startColor = startColor;
        // Optionally set endColor, material, etc.
    }
}
