using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedTrigger : MonoBehaviour
{
    public ScriptedEvent Event;
    public float TriggerTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TriggerEvent", TriggerTime);
    }

    void TriggerEvent() {
        Event.Trigger();
    }
}
