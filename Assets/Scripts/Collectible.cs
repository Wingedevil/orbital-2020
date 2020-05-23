using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            GameManager.GetInstance().IncrementScore(1);
            GetComponent<AudioSource>().Play();
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject, 2);
        }
    }
}
