using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSegment : MonoBehaviour
{
    public float heightOffsetFromGorund = 0.5f;
    public LayerMask mask;

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f,mask))
        {
            transform.position = Vector3.Lerp(transform.position, hit.point + Vector3.up * heightOffsetFromGorund, Time.deltaTime * 10f);
        }
    }
}
