﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float forwardVel;
    public float rotateVel;
    public float boostFactor;
    private float boostInput;
    private float mvFactor;
    private float volume;
    private CharacterController pController;
    private Vector3 forwardMove;

    // Start is called before the first frame update
    void Start()
    {
        pController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        volume = GetComponent<MicrophoneInputv2>().volume;
        Debug.Log(volume);
        forwardVel = volume;
        Movement();
    }

    public void Movement()
    {
        mvFactor = 1f;

        if (Input.GetButton("Jump"))
        {
            boost();
        }

        //Debug.Log(forwardVel);

        forwardMove = new Vector3(0, 0, forwardVel + mvFactor * Time.deltaTime);

        forwardMove = transform.TransformDirection(forwardMove);
        


        transform.Rotate(Vector3.up * GetComponent<GyroController>().rotation.y * rotateVel);

        pController.Move(forwardMove);

    }


    public float boost()
    {
        // Get input from keys/controller
        boostInput = Input.GetAxis("Jump");

        // Set the factor for the input
        mvFactor = boostFactor * boostInput;

        return mvFactor;
               
    }

}
