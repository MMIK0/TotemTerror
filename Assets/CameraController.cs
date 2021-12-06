using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float mouseSens;

    float cameraPitch = 0.0f;

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
    }
    
    void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraPitch -= mouseDelta.y * mouseSens;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSens);
    }
}
