using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    private GameObject ClosestEnemy;

    // Start is called before the first frame update
    void Start()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = float.PositiveInfinity;
        foreach (var e in enemies) {
            if (Vector3.Distance(this.transform.position, e.transform.position) < closestDistance) {
                closestDistance = Vector3.Distance(this.transform.position, e.transform.position);
                ClosestEnemy = e;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        Vector3 dir = ClosestEnemy.transform.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 180 * Time.deltaTime);
    }
}