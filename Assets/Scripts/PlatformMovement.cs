using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
