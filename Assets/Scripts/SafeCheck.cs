using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCheck : MonoBehaviour
{
    public GameObject Door;
    private Animator _Animator;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            _Animator.SetBool("isSafe", false);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        _Animator.SetBool("isSafe",true);
    }
}
