using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int MaxHP;
    public GameObject Deathrattle;

    private int curHP;

    // Start is called before the first frame update
    void Start()
    {
        curHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg) {
        curHP -= dmg;
        if (curHP <= 0) {
            Debug.Log("I died");
            Instantiate(Deathrattle, this.transform.position, this.transform.rotation);
            // Destroy(this.gameObject);

            if (this.gameObject.tag == "Player") {
                GameManager.GetInstance().DefferedResetLevel();
            }

            var animator = GetComponent<Animator>();
            if (animator != null) {
                animator.SetTrigger("Die");
                Destroy(GetComponent<PatrollingBehavior>());
                Destroy(GetComponent<Damager>());
                Destroy(GetComponent<Rigidbody2D>());
            }
        }
    }
}
