using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    bool paused = false;

    private void Update()
    {
        Debug.Log(paused);
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            panel.SetActive(true);
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            paused = false;
        }
    }
}
