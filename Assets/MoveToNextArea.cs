using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextArea : MonoBehaviour
{
    public int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == Player.instance.gameObject)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
