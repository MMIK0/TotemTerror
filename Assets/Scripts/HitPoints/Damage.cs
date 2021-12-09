using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    public DamageType damageType;
    public enum DamageType
    {
        all,
        ally,
        enemy
    }
}
