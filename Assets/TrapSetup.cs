using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetup : MonoBehaviour
{
    public Animator[] animators;
    public bool notTriggeredByPlayer;
    public void OnTriggerEnter(Collider collision)
    {
        if (notTriggeredByPlayer)
            if (!collision.gameObject.CompareTag("TrapTrigger"))
                return;
        foreach(Animator anim in animators)
        {
            anim.SetTrigger("Step");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (notTriggeredByPlayer)
            if (!other.gameObject.CompareTag("TrapTrigger"))
                return;
        foreach (Animator anim in animators)
        {
            anim.ResetTrigger("Step");
        }
    }
}
