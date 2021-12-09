using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitPoints : MonoBehaviour
{
    public float maxHitPoints;
    float currentHitPoints;
    public UnityEvent deathEvent;
    public Damage.DamageType damageImmunity;
    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    public void TakeDamage(Damage damage)
    {
        if (currentHitPoints <= 0 || damageImmunity == damage.damageType||damageImmunity ==Damage.DamageType.all)
            return;
        currentHitPoints -= damage.damage;
        if (currentHitPoints <= 0)
        {
            deathEvent.Invoke();
        }
    }
}
