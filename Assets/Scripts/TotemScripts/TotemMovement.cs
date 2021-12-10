using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemMovement : MonoBehaviour
{
    public float MoveSpeed=2,moveInterval=10;
    public float mBoundsWidth=10, mBoundsDeepth=10;
    float intervalTimer;
    Vector3 targetPos;
    Vector3 startPos;
    bool moving;
    private void OnEnable()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (!moving)
            intervalTimer += Time.deltaTime;
        if (intervalTimer >= moveInterval)
        {
            moving = true;
            intervalTimer = 0;
            targetPos=GetNewPos();
        }
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * MoveSpeed);
            if (Vector3.SqrMagnitude(targetPos - transform.position) <= 0.5f)
                moving = false;
        }

    }
    public void SetMoveInterval(float time)
    {
        moveInterval = time;
    }
    private Vector3 GetNewPos()
    {
        float xPos = Random.Range(-mBoundsWidth, mBoundsWidth);
        float zPos = Random.Range(-mBoundsDeepth, mBoundsDeepth);
        return new Vector3(xPos, 0, zPos)+startPos;
    }
}
