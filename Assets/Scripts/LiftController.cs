using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class LiftController : MonoBehaviour
{
    public GameObject ButtonGroundFloor;
    public GameObject ButtonFirstFloor;
    public GameObject ButtonSecondFloor;
    public GameObject ButtonThirdFloor;

    public GameObject CallButtonGroundFloor;
    public GameObject CallButtonFirstFloor;
    public GameObject CallButtonSecondFloor;
    public GameObject CallButtonThirdFloor;

    public GameObject Lift;
    public GameObject Door;

    private UnityAction onComplete;

    public int _YourFloor = 0;
    public int _ToTheFloor;

    public static bool isMoving = false;

    public static bool test;

    private Animator _animator;

    Vector3 lastPos;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 finalPos;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (InteractionScript.Button == ButtonGroundFloor && Input.GetKey(KeyCode.E) && InteractionScript.canInteract)
        {
            _ToTheFloor = 0;
            Animation(_YourFloor, _ToTheFloor);
            if (!isMoving)
            {
                StartCoroutine(CheckMoving());
            }
        }
        if (InteractionScript.Button == ButtonFirstFloor && Input.GetKey(KeyCode.E) && InteractionScript.canInteract)
        {
            _ToTheFloor = 1;
            Animation(_YourFloor, _ToTheFloor);
            if (!isMoving)
            {
                StartCoroutine(CheckMoving());
            }
        }
        if (InteractionScript.Button == ButtonSecondFloor && Input.GetKey(KeyCode.E) && InteractionScript.canInteract)
        {
            _ToTheFloor = 2;
            Animation(_YourFloor, _ToTheFloor);
            if (!isMoving)
            {
                StartCoroutine(CheckMoving());
            }
        }
        if (InteractionScript.Button == ButtonThirdFloor && Input.GetKey(KeyCode.E) && InteractionScript.canInteract)
        {
            _ToTheFloor = 3;
            Animation(_YourFloor, _ToTheFloor);
            if (!isMoving)
            {
                StartCoroutine(CheckMoving());
            }
        }
        if (InteractionScript.CallButton == CallButtonGroundFloor && Input.GetKey(KeyCode.E) )
        {
            _ToTheFloor = 0;
            Animation(_YourFloor, _ToTheFloor);
        }
        if (InteractionScript.CallButton == CallButtonFirstFloor && Input.GetKey(KeyCode.E) && InteractionScript.OpenTheDoor)
        {
            _ToTheFloor = 1;
            Animation(_YourFloor, _ToTheFloor);
        }
        if (InteractionScript.CallButton == CallButtonSecondFloor && Input.GetKey(KeyCode.E) && InteractionScript.OpenTheDoor)
        {
            _ToTheFloor = 2;
            Animation(_YourFloor, _ToTheFloor);
        }
        if (InteractionScript.CallButton == CallButtonThirdFloor && Input.GetKey(KeyCode.E) && InteractionScript.OpenTheDoor)
        {
            _ToTheFloor = 3;
            Animation(_YourFloor, _ToTheFloor);
        }
        if (Lift.transform.position == lastPos)
        {
            _YourFloor = _ToTheFloor;
        }
        lastPos = Lift.transform.position;
    }
    private void Animation(int _YourFloor, int _ToTheFloor)
    {
        _animator.SetInteger("FromFloor", _YourFloor);
        _animator.SetInteger("ToTheFloor", _ToTheFloor);
    }
    public IEnumerator CheckMoving()
    {
        startPos = Lift.transform.position;
        yield return new WaitForSeconds(0.5f);
        finalPos = Lift.transform.position;
        if (startPos.x != finalPos.x || startPos.y != finalPos.y
            || startPos.z != finalPos.z)
            isMoving = true;
        yield return new WaitForSeconds(4.5f);
        startPos = finalPos;
        isMoving = false;
    }
}

