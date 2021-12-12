using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArenaTrigger : MonoBehaviour
{
    public Animator anim;
    BoxCollider boxCollider;

    public void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("DoorEnter");
        boxCollider.enabled = false;
        Shake();
    }

    public void Shake()
    {
        StartCoroutine(Player.instance.CameraShake(2f, .4f));
    }
}
