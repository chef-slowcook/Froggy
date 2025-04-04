using UnityEngine;

public class FrogVisuals : MonoBehaviour
{
    [SerializeField]
    private Transform tonguePivot;
    [SerializeField]
    private float speed = 1;
    // Update is called once per frame
    void Update()
    {
        TongueRotation();
    }

    private void TongueRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        tonguePivot.right = mousePosition - tonguePivot.position;
    }
}
