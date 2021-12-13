using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextArea : MonoBehaviour
{
    public int currentScene;
    public int sceneNumber;
    public bool loadScene = false;

    public void Awake()
    {
        if (loadScene)
            SceneManager.LoadScene(sceneNumber);

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == Player.instance.gameObject)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
