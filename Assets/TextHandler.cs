using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    float timer = 7f;

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            gameObject.SetActive(false);
    }
}
