using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitPoints : MonoBehaviour
{
    public float maxHitPoints;
    [HideInInspector]
    public float currentHitPoints;
    public bool isPlayer;
    public UnityEvent deathEvent;
    public Damage.DamageType damageImmunity;
    private void Start()
    {
        currentHitPoints = maxHitPoints;
        if (isPlayer)
            PlayerHealthBar.instance.UpdateHealthbar(currentHitPoints, maxHitPoints);
    }
    public void TakeDamage(Damage damage)
    {
        if (currentHitPoints <= 0 || damageImmunity == damage.damageType||damageImmunity == Damage.DamageType.all)
            return;
        currentHitPoints -= damage.damage;
        if (isPlayer)
            PlayerHealthBar.instance.UpdateHealthbar(currentHitPoints, maxHitPoints);
        Debug.Log(currentHitPoints);
        if (currentHitPoints <= 0)
        {
            deathEvent.Invoke();
        }
    }
}
