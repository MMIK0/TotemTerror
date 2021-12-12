using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float rotationOffset = 0;
    private void Update()
    {        Vector2 dir = new Vector2(transform.position.x - target.position.x, transform.position.z - target.position.z);
        float angle = Vector2.SignedAngle(Vector2.up, dir);
        transform.rotation=Quaternion.Euler(0,360-angle +rotationOffset,0);
    }
}
