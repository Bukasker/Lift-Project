using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movmentControl;
    [SerializeField]
    private InputActionReference Interaction;
    [SerializeField]
    public float playerSpeed;
    [SerializeField]
    private float rotationSpeed = 200f;
    [SerializeField]
    private float gravityValue = 9.8f;


    private CharacterController controller;
    [SerializeField]
    private Vector3 playerVelocity;

    private Transform cameraMainTransform;
    private Transform Player;
    private Animator anim;

    [SerializeField]
    public static bool isEpressed;

    private void OnDisable()
    {
        Interaction.action.Disable();
        movmentControl.action.Disable();
    }
    private void OnEnable()
    {
        Interaction.action.Enable();
        movmentControl.action.Enable();
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cameraMainTransform = Camera.main.transform;
        Player = this.GetComponent<Transform>();
    }

    void Update()
    {
        //MOVMENT
        if (Interaction.action.triggered)
        {
            isEpressed = true;
        }
        else
        {
            isEpressed = false;
        }
        playerVelocity.y -= gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        Vector2 movment = movmentControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movment.x, 0, movment.y);

        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;

        controller.Move(move * Time.deltaTime * playerSpeed);
        //PLAYER ROTATION
        if (movment != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movment.x, movment.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            controller.Move(move * Time.deltaTime * playerSpeed);
            anim.SetBool("isMoving", true);
            anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
            anim.SetBool("isMoving", false);
        }
    }
}