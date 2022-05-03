using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject Lift;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    // Update is called once per frame
    void Update()
    {
        var ObjBPos = LeftDoor.transform.position;

        var targetY = Vector3.LerpUnclamped(LeftDoor.transform.position, Lift.transform.position, 2f).z;

        ObjBPos.z = targetY;

        RightDoor.transform.position = ObjBPos;
    }
}
