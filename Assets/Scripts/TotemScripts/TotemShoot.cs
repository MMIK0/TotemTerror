using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemShoot : MonoBehaviour
{
    public List<Shoot> shoot = new List<Shoot>();
    public float fireRate = 0.5f,rotaionSpeed=3;
    float timeSinceShot;
    void Update()
    {
        transform.Rotate(new Vector3(0,rotaionSpeed * Time.deltaTime,0));
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot >= fireRate)
        {
            foreach(Shoot s in shoot)
                s.Fire();
            timeSinceShot = 0;
        }
    }
    public void SetProjectileSpeed(float speed)
    {
        foreach (Shoot s in shoot)
            s.SetSpeed(speed);
    }
    public void SetRotationSpeed(float speed)
    {
        rotaionSpeed = speed;
    }
    public void SetFireRate(float rate)
    {
        fireRate = rate;
    }
}
