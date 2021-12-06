using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject playerCam;
    public bool isStaticBB;

    public void Start()
    {
        playerCam = Player.instance.playerCamera.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStaticBB)
            transform.LookAt(playerCam.transform);
        else
            transform.rotation = playerCam.transform.rotation;

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0);
    }
}
