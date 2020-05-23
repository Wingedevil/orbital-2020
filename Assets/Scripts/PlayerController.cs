using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 5.0f;
    public GameObject Bullet;
    public GameObject ProjectileSpawnPoint;

    private Rigidbody2D rigidBody;
    private bool onGround = true;

    private bool hasDoubleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (GameManager.GetInstance().IsPaused) {
            return;
        }

        if (!onGround) {
            Debug.DrawRay(transform.position + new Vector3(0, -0.3f, 0), Vector2.down * .1f, Color.red, .05f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.3f, 0), Vector2.down, .1f);
            if (hit.collider != null) {
                var tag = hit.collider.tag;
                Debug.Log(tag);
                if (tag == "Ground") {
                    onGround = true;
                    hasDoubleJump = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            Fire();
        }

        if (Input.GetKey(KeyCode.A)) {
            var initialVelocity = rigidBody.velocity;
            initialVelocity.x = -1 * PlayerSpeed;
            rigidBody.velocity = initialVelocity;
            var scale = this.transform.localScale;
            scale.x = -1;
            this.transform.localScale = scale;
        } else if (Input.GetKey(KeyCode.D)) {
            var initialVelocity = rigidBody.velocity;
            initialVelocity.x = 1 * PlayerSpeed;
            rigidBody.velocity = initialVelocity;
            var scale = this.transform.localScale;
            scale.x = 1;
            this.transform.localScale = scale;
        } else {
            var initialVelocity = rigidBody.velocity;
            initialVelocity.x = 0;
            rigidBody.velocity = initialVelocity;
        }

        if (Input.GetKeyDown(KeyCode.W) && onGround) {
            var initialVelocity = rigidBody.velocity;
            initialVelocity.y = 1 * PlayerSpeed;
            rigidBody.velocity = initialVelocity;
            onGround = false;
        } else if (Input.GetKeyDown(KeyCode.W) && hasDoubleJump) {
            var initialVelocity = rigidBody.velocity;
            initialVelocity.y = 1 * PlayerSpeed;
            rigidBody.velocity = initialVelocity;
            hasDoubleJump = false;
        }
    }

    private void Fire() {
        var bullet = Instantiate(Bullet, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
        bullet.transform.localScale = this.transform.localScale;
        var bulletrigidbody = bullet.GetComponent<Rigidbody2D>();
        if (bulletrigidbody != null) {
            bulletrigidbody.velocity = this.transform.localScale.x * 5f * new Vector3(1, 0, 0);
        }
    }
}