using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamagingHitBox : MonoBehaviour
{
    public CapsuleCollider capsuleCollider;

    public void Start()
    {
        capsuleCollider.enabled = false;
    }

    public void SpikeActive()
    {
        capsuleCollider.enabled = true;
    }

    public void SpikeDown()
    {
        capsuleCollider.enabled = false;
    }

}
