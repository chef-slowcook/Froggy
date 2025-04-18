using System;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveButton : MonoBehaviour
{
    [Header("Event Subscribers")]
    [SerializeField] private UnityEvent frogEnterEvent;
    [SerializeField] private UnityEvent frogExitEvent;
    [SerializeField] private String collisionTag = "Frog";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the frog
        if (collision.gameObject.CompareTag(collisionTag))
        {
            // Invoke the event when frog enters
            frogEnterEvent.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the exiting object is the frog
        if (collision.gameObject.CompareTag(collisionTag))
        {
            // Invoke the event when frog exits
            frogExitEvent.Invoke();
        }
    }

}
