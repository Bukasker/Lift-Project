using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject Button;
    private Animator anim;
    public bool canInteract;
    public bool Open;
    public bool test;
    public GameObject ButtonGroundFloor;
    public GameObject ButtonFirstFloor;
    public GameObject ButtonSecondFloor;
    public GameObject ButtonThirdFloor;
    public GameObject Lift;
    public int Floor;
    void Start()
    {
        Open = false;
        GameObject door = GameObject.FindWithTag("Door");
        anim = door.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isEpressed)
        {
            test = true;
        }
        else
        {
            test = false;
        }
        if (PlayerController.isEpressed && canInteract == true && Open == true)
        {
            anim.SetBool("isOpen", true);
            Open = false;
        }
        else if (PlayerController.isEpressed && canInteract == true && Open == false)
        {
            anim.SetBool("isOpen", false);
            Open = true;
        }
        if (Button == ButtonGroundFloor && canInteract == true && PlayerController.isEpressed)
        {
            Floor = 0;
            Lift.transform.position += Lift.transform.up * Time.deltaTime* 20f;
        }
        if (Button == ButtonFirstFloor && canInteract == true && PlayerController.isEpressed)
        {
            Floor = 1;
            Lift.transform.position += Lift.transform.up * Time.deltaTime * 20f;
        }
        if (Button == ButtonSecondFloor && canInteract == true && PlayerController.isEpressed)
        {
            Floor = 2;
        }
        if (Button == ButtonThirdFloor && canInteract == true && PlayerController.isEpressed)
        {
            Floor = 3;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Button")
        {
            Button = col.gameObject;
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Button")
        {
            Button = null;
            canInteract = false;
        }
    }
}
