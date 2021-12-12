using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerShooting : Shoot
{
    public int ammo = 5;
    private int currentAmmo;
    public float shotCooldown = .7f, cylinderRotationPerShot = 72, reloadTime=2f;
    private float cooldown = 0, rotationAmount,reloadTimer;
    public Transform cylinder;

    private void OnEnable()
    {
        currentAmmo = ammo;
        rotationAmount = cylinderRotationPerShot;
    }
    private void Update()
    {
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            return;
        }
        if (cooldown>=0)
            cooldown -= Time.deltaTime;
        if (rotationAmount < cylinderRotationPerShot)
        {
            float rotation = cylinderRotationPerShot / shotCooldown;
            rotationAmount += rotation* Time.deltaTime*2;
            if(rotationAmount>cylinderRotationPerShot)
                cylinder.transform.Rotate(new Vector3(0, 0, -rotationAmount/cylinderRotationPerShot));
            else
                cylinder.transform.Rotate(new Vector3(0, 0, -rotation*Time.deltaTime*2));
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0 && cooldown <= 0)
            {
                Fire();
                cooldown = shotCooldown;
                currentAmmo--;
                rotationAmount = 0;
            }
            else if (currentAmmo <= 0)
                Reload();
        }
         
    }
    void Reload()
    {
        reloadTimer = reloadTime;
        currentAmmo = ammo;
        animator.SetTrigger("Reload");
    }
    
}
