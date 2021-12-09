using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public HitPoints MainHitPoints;
    float immunityTimer;
    float immunityDuration = 0.5f;
    private void OnTriggerEnter(Collider collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (!damage)
            return;

        if(immunityTimer <= 0)
        {
            MainHitPoints.TakeDamage(damage);
            immunityTimer = immunityDuration;
        }
    }

    private void Update()
    {
        if (immunityTimer > 0)
            immunityTimer -= Time.deltaTime;
    }

}
