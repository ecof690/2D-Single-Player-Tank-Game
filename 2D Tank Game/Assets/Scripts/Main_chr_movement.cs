using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_chr_movement : MonoBehaviour
{

    private float horizontalMove = 0f, verticalMove = 0;
    public int movement_speed = 0, rotation_speed = 0;

    Rigidbody2D r_2D;

    private void Start()
    {
        r_2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(Input.GetAxisRaw("Vertical"));

        GetInputs();

    }


    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void GetInputs()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        r_2D.velocity = transform.up * Mathf.Clamp01(verticalMove) * movement_speed;
    }


    private void RotatePlayer()
    {
        float rotation = -horizontalMove * rotation_speed;
        transform.Rotate(Vector3.forward * rotation);
    }
}
