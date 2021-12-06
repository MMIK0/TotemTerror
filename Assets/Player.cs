﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity = -13f;
    public float jumpForce = 30f;
    public float airTime;
    CharacterController charControl;
    [Range(0.0f, 0.5f)] float movementSmooth = 0.1f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    float velocityY = 0f;
    float jumpTimer;
    float bunnyHopTimer;
    float bunnyHops = 0;
    bool isJumping = false;
    bool groundState = false;
    public float moveSpeed { get; private set; }

    //Camera controls
    public Transform playerCamera;
    public float mouseSens;
    float cameraPitch = 0.0f;
    [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelo = Vector2.zero;

    public void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        moveSpeed = speed;
    }
    public void Update()
    {
        DefaultMovement();
        UpdateMouseLook();
    }

    public void DefaultMovement()
    {
        Vector2 targetInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetInput.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetInput, ref currentDirVelocity, movementSmooth);

        if (charControl.isGrounded)
            velocityY = 0f;

        velocityY -= gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && charControl.isGrounded)
        {
            isJumping = true;
            jumpTimer = 0f;
            if (bunnyHopTimer > 0)
                bunnyHops += 1.1f;
            else
                bunnyHops = 0;
        }

        if (isJumping)
        {
            velocityY = jumpForce / (jumpTimer + 0.1f);
            jumpTimer += Time.deltaTime;
        }
        if(jumpTimer > airTime)
        {
            isJumping = false;
        }

        if(charControl.isGrounded != groundState && charControl.isGrounded)
        {
            bunnyHopTimer = 0.3f;
            moveSpeed = speed;
        }

        if (bunnyHopTimer > 0)
        {
            bunnyHopTimer -= Time.deltaTime;
            if (!charControl.isGrounded)
            {
                moveSpeed = speed * bunnyHops;
            }
        }

        groundState = charControl.isGrounded;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * moveSpeed + Vector3.up * velocityY;
        charControl.Move(velocity *Time.deltaTime);
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelo, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSens;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSens);
    }
}