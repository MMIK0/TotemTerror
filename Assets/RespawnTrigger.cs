using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform spawnPoint;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Player.instance.gameObject)
        {
            collider.GetComponent<Player>().enabled = false;
            collider.transform.position = spawnPoint.position;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        other.GetComponent<Player>().enabled = true;
    }
}
