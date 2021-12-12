using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlightHome : MonoBehaviour
{
    public Rigidbody rBody;
    public float homingStrenght=5f;
    void Update()
    {
        Vector3 dir = Vector3.Normalize(Player.instance.transform.position - (transform.position+ Vector3.up));
        dir = transform.InverseTransformDirection(dir);
        dir.z = 0;
        dir = transform.TransformDirection(dir);
        rBody.velocity += dir * homingStrenght * Time.deltaTime;
    }
}
