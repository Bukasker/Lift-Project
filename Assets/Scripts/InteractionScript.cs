using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public static GameObject Button;
    public static GameObject CallButton;
    public GameObject door;
    public GameObject OpenDoorButton;

    public GameObject Lift;

    public static Animator _anim;

    public static bool canInteract;
    public static bool OpenTheDoor;

    public static bool Open;

    public AudioClip OpenDoorSound;
    public AudioClip CloseDoorSound;
    public AudioClip LiftSound;

    public AudioSource LiftAudio;
    public AudioSource LiftSoud;

    void Start()
    {
        Open = false;
        LiftAudio = Lift.GetComponent<AudioSource>();
        LiftSoud = Camera.main.GetComponent<AudioSource>();
        _anim = door.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && OpenTheDoor == true && Open == true && !LiftController.isMoving)
        {
            _anim.SetBool("isOpen", true);
            LiftAudio.PlayOneShot(OpenDoorSound, 0.2f);
            Open = false;
        }
        else if (Input.GetKey(KeyCode.E) && OpenTheDoor == true && Open == false && !LiftController.isMoving)
        {
            _anim.SetBool("isOpen", false);
            LiftAudio.PlayOneShot(CloseDoorSound, 0.2f);
            Open = true;
        }
        if (LiftController.isMoving)
        {
            LiftSoud.Play();
            _anim.SetBool("isOpen", false);
            LiftAudio.PlayOneShot(CloseDoorSound, 0.2f);
            Open = true;
        }
        else
        {
            LiftSoud.Stop();
            _anim.SetBool("isOpen", true);
            LiftAudio.PlayOneShot(OpenDoorSound, 0.2f);
            Open = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Button")
        {
            Button = col.gameObject;
            canInteract = true;
        }
        if (col.tag == "CallButton")
        {
            CallButton = col.gameObject;
            OpenTheDoor = true;
        }
        if(col.tag == "OpenDoorButton")
        {
            OpenTheDoor = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Button")
        {
            Button = null;
            canInteract = false;
        }
        if (col.tag == "CallButton")
        {
            CallButton = null;
            OpenTheDoor = false;
        }
        if (col.tag == "OpenDoorButton")
        {
            OpenTheDoor = false;
        }
    }
}
