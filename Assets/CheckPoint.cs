using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void Start()
    {
        CheckPointManager.instance.AddCheckPoint(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player.instance.gameObject)
            CheckPointManager.instance.SetCurrentCheckPoint(this);
    }
}
