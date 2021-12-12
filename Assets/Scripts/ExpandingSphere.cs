using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingSphere : MonoBehaviour
{
    public float maxSize = 10,expandTime=3;
    float expandTimer;
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        expandTimer = 0;
        
    }
    private void Update()
    {

        expandTimer += Time.deltaTime;
        transform.localScale += Vector3.one * (maxSize / expandTime) * Time.deltaTime;
        if (expandTimer >= expandTime)
            gameObject.SetActive(false);
    }

}
