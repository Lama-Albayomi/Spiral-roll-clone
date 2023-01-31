using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float size;
    [Range(0,20)]
    public float speed;
    public GameObject graphics;
    private Rigidbody rb;
    private Animator animator;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        animator= GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity=Vector3.fwd*speed;
        if(Input.GetMouseButtonDown(0)){
            animator.SetInteger("State",1);
        }
        if (Input.GetMouseButton(0)){
            size++;
        }
        if (Input.GetMouseButtonUp(0)){
            animator.SetInteger("State",0);

        }
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter");
    }
}
