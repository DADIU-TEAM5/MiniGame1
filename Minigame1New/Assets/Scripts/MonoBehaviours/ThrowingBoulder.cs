﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBoulder : MonoBehaviour
{

    public GameObject boulder;
    public GameObject boat;
    public GameObject target;

    PlayerController boatScript;

    public Transform handPosition;

    Vector3 throwPoint;

    public float timeBetweenThrows = 2;

    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        boatScript = boat.GetComponent<PlayerController>();
        cooldown = timeBetweenThrows;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;


        if(cooldown >= timeBetweenThrows)
        {
            cooldown = 0;
            throwPoint = handPosition.position;
            boulder.transform.position = handPosition.position;


           target.transform.position = boat.transform.position + (Vector3.forward*((timeBetweenThrows* boatScript.velocity)-timeBetweenThrows*boatScript.SpeedDecayRate))+Vector3.up +(Vector3.right*Random.Range(-2,2));
            

        }
        else
        {
            moveBoulder();
        }
    }


    void moveBoulder()
    {
        float cTime = cooldown/timeBetweenThrows;
        // calculate straight-line lerp position:
        Vector3 currentPos = Vector3.Lerp(throwPoint, target.transform.position, cTime);
        // add a value to Y, using Sine to give a curved trajectory in the Y direction
        currentPos.y += 40 * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
        // finally assign the computed position to our gameObject:
        boulder.transform.position = currentPos;
    }
}