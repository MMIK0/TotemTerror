using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetup : MonoBehaviour
{
    public Animator[] animators;

    public void OnTriggerEnter(Collider collision)
    {
        foreach(Animator anim in animators)
        {
            anim.SetTrigger("Step");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        foreach (Animator anim in animators)
        {
            anim.ResetTrigger("Step");
        }
    }
}
