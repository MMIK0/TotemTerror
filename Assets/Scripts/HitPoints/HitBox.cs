using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public HitPoints MainHitPoints;

    private void OnCollisionEnter(Collision collision)
    {
        Damage damage = collision.collider.GetComponent<Damage>();
        if (!damage)
            return;
        MainHitPoints.TakeDamage(damage);
    }
}
