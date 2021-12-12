using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float defDistanceRay = 100;
    public Transform firePoint;
    public LineRenderer m_lineRenderer;

    private void Update()
    {
        ShootLaser();
    }

    public void ShootLaser()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            DrawRay(firePoint.position, hit.point);
        }
        else
        {
            DrawRay(firePoint.position, firePoint.TransformDirection(Vector3.forward) * defDistanceRay);
        }
    }

    void DrawRay(Vector3 startPos, Vector3 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
