//karakter hareketleri
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charc : MonoBehaviour
{
    public CharacterController characterController;
    public float jumpSpeed = 1.6f;
    public float speed = 6.0f;
    public float gravity = 9.81f;
    private Vector3 move = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {

            move = transform.right * x + transform.forward * z;

            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }
        }
        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * speed * Time.deltaTime);
    }
}