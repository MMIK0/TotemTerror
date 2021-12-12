﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rBody;
    public bool doNotDestroyOnHit;
    public float lifeTime = 20f;
    private float lifeDuration=0;
    private void Update()
    {
        lifeDuration += Time.deltaTime;
        if (lifeDuration >= lifeTime)
        {
            lifeDuration = 0;
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (doNotDestroyOnHit||collision.gameObject.CompareTag("TrapTrigger"))
            return;
        Damage damage = collision.gameObject.GetComponent<Damage>();
        Damage ownDamage = GetComponent<Damage>();
        if (damage && ownDamage)
        {
            if (damage.damageType == ownDamage.damageType && damage.damageType != Damage.DamageType.all)
                return;
        }
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();
        Damage ownDamage = GetComponent<Damage>();
        if (damage && ownDamage)
        {
            if (damage.damageType == ownDamage.damageType && damage.damageType != Damage.DamageType.all)
                return;
        }
        if (doNotDestroyOnHit || other.gameObject.CompareTag("TrapTrigger"))
            return;
        gameObject.SetActive(false);
    }
}
