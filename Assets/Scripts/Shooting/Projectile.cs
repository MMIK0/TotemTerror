using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rBody;
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
