using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public PooledBehaviour bullet;
    public float speed=2;
    public Transform projectileSpawnPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
        Projectile projectile = bullet.GetPooledObject().GetComponent<Projectile>();
        projectile.transform.position = projectileSpawnPoint.position;
        projectile.rBody.velocity = projectileSpawnPoint.forward * speed;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
}
