using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipTrigger : MonoBehaviour
{
    public string text;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            Player.instance.panel.SetActive(true);
            Player.instance.tipText.text = text;
        }  
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player.instance.gameObject)
        {
            Player.instance.panel.SetActive(false);
        }
    }
}
