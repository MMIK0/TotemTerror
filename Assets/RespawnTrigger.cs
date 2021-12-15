using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    public bool isBossFight = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == Player.instance.gameObject)
        {
            if (isBossFight == true)
                Player.instance.Die();
            else
            {
                Player.instance.ResetBunnyHops();
                collider.GetComponent<Player>().enabled = false;
                collider.transform.position = CheckPointManager.instance.spawnPoint.transform.position;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        other.GetComponent<Player>().enabled = true;
    }
}
