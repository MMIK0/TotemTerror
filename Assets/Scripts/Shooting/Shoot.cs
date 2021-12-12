using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public PooledBehaviour bullet;
    public float speed=2;
    public Animator animator;
    public Transform projectileSpawnPoint;


    public void Fire()
    {
        Projectile projectile = bullet.GetPooledObject().GetComponent<Projectile>();
        projectile.transform.position = projectileSpawnPoint.position;
        projectile.rBody.velocity = projectileSpawnPoint.forward * speed;
        projectile.transform.rotation = projectileSpawnPoint.rotation;
        if (animator)
        {
            animator.SetTrigger("Shoot");
        }
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
}
