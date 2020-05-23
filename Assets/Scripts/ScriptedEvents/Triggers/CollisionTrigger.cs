using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionTrigger : MonoBehaviour
{
    public ScriptedEvent Event;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Event.Trigger();
        }
    }
}
