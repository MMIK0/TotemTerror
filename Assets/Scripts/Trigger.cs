using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent call;
    private void OnTriggerEnter(Collider other)
    {
        call.Invoke();
    }
    private void OnCollisionEnter(Collision collision)
    {
        call.Invoke();
    }
}
