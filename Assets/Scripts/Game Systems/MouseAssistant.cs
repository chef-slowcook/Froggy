using UnityEngine;

public static class MouseAssistant
{
     /// <summary>
     /// Returns the direction from origin to the mouse, normalized.
     public static Vector3 DirectionToMouse(Transform origin)
     {
          Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          mousePosition.z = 0;
          return (mousePosition - origin.position).normalized;
     }
}
