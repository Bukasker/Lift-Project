using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    private Animator _animator;
    private CharacterController _characterController;
    private Rigidbody _Rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
    [SerializeField] private float gravity = -9.81f;
    Vector3 lastPos;
    Vector3 velocity;

    private void Awake()
    {
        _animator = Player.GetComponent<Animator>() ?? throw new NullReferenceException();
        _characterController = GetComponent<CharacterController>() ?? throw new NullReferenceException();
    }

    private void Update()
    {
        MovePlayerVertically();
        MovePlayerHorizontally();

        var xMouseInput = Input.GetAxis("Mouse X");
        RotatePlayer(xMouseInput);
        var yMouseInput = Input.GetAxis("Mouse Y");
        RotateCamera(yMouseInput);
        if (Player.transform.position != lastPos)
        {
            _animator.SetBool("isMoving", true);
            _animator.SetFloat("Speed", 1f, 0.1f, 1f);
        }
        else
        {
            _animator.SetBool("isMoving", false);
            _animator.SetFloat("Speed", 0f, 0.1f, 0f);
        }
        lastPos = Player.transform.position;

        velocity.y += gravity * Time.deltaTime;
        _characterController.Move(velocity *Time.deltaTime);
    }
    private void MovePlayerHorizontally()
    {
        var moveDirection = transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        _characterController.Move(moveDirection);
    }

    private void RotatePlayer(float xMouseInput)
    {
        transform.Rotate(0, xMouseInput * mouseSensitivityX * Time.deltaTime, 0);
    }
    private void RotateCamera(float yMouseInput)
    {
        Camera.main.transform.Rotate(-yMouseInput * mouseSensitivityY * Time.deltaTime, 0, 0);
    }
    private void MovePlayerVertically()
    {
        var moveDirection = transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        _characterController.Move(moveDirection);
    }
}