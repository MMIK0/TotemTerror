using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedText : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public void Start()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.text = Player.instance.moveSpeed.ToString();
    }
}
