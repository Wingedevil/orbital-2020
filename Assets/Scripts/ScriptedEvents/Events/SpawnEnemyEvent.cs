using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyEvent : ScriptedEvent
{
    public GameObject Enemy;
    public GameObject SpawnLocation;

    public override void Trigger() {
        Instantiate(Enemy, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
    }
}
