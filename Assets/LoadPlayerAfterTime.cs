using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadPlayerAfterTime : MonoBehaviour
{
    bool counting = false;
    float counter = 15f;
    public TextMeshProUGUI tmp;

    public void Start()
    {
        StartCoroutine("LoadToMainMenu");
        counting = true;
    }

    public void Update()
    {
        if (counting == true)
        {
            counter -= Time.deltaTime;
            tmp.text = counter.ToString("00");
        }
    }

    public IEnumerator LoadToMainMenu()
    {
        yield return new WaitForSeconds(15f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
