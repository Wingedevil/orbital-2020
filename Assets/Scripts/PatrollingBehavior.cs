using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingBehavior : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rigidBody;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rigidBody.velocity = this.transform.localScale.x * Speed * new Vector3(1, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Reverse");
        if (collision.collider.tag == "EnemyPatrolBox") {
            var scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }
    }
}
