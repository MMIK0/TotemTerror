using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;
    public CheckPoint currentCheckPoint;
    public GameObject spawnPoint;
    public List<CheckPoint> checkPoints = new List<CheckPoint>();

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void AddCheckPoint(CheckPoint checkPoint)
    {
        checkPoints.Add(checkPoint);
    }

    public void SetCurrentCheckPoint(CheckPoint cp)
    {
        currentCheckPoint = cp;
        spawnPoint.transform.position = new Vector3(currentCheckPoint.transform.position.x, currentCheckPoint.transform.position.y + 1f, currentCheckPoint.transform.position.z);
    }
}
