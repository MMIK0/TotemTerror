using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivation : MonoBehaviour
{
    public GameObject[] lights;

    public void LightOn()
    {
        foreach(GameObject light in lights)
            light.SetActive(true);
    }
}
