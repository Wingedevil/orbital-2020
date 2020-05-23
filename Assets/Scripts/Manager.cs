using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; 

    void Awake()
    {
        if (instance == null) {
            instance = this as T;
        }
    }

    public static T GetInstance() {
        return instance;
    }
}
