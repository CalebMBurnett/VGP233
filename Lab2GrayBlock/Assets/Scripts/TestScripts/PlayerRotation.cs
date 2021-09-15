using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float currentTime;
    public float rotationTime;
    private float rotationAngle = 180;
    private bool rotated = false;
    private int command;
    private Vector3 scaleChangeDown;
    private Vector3 scaleChangeUp;
    private int flipped = 1;
    void Start()
    {
        scaleChangeDown = new Vector3(0.0f, transform.localScale.y * -2, 0.0f);
        scaleChangeUp = new Vector3(0.0f, transform.localScale.y * 2, 0.0f);
    }

    /*
      currentTime += Time.deltaTime;
      if(currentTime > totalTime)
      {
      currentTime = 0.0f;
      destinationAngle = 0.0f;
      }
      Quaternion quat = new Quaternion();
      quat.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Mathf.LerpAngle(transform.rotation.z, 180.0f, currentTime / totalTime));
      transform.rotation = quat;*/
    void Update()
    {
        if(currentTime > rotationTime)
        {
            currentTime = 0.0f;
            command = 0;
            //rotated = true;
            //rotationAngle = 0.0f;
        }
        if(command == 1)
        {
            currentTime += Time.deltaTime;
            Quaternion gRotation = new Quaternion();
                gRotation.eulerAngles = new Vector3(transform.rotation.x, 
                transform.rotation.y, 
                Mathf.LerpAngle(transform.rotation.z, rotationAngle, currentTime / rotationTime));
            transform.rotation = gRotation;
            
        }
        if(command == 2)
        {
            currentTime += Time.deltaTime;
            Quaternion gRotation = new Quaternion();
            gRotation.eulerAngles = new Vector3(transform.rotation.x,
            transform.rotation.y,
            Mathf.LerpAngle(180f, 360f, currentTime / rotationTime));
            transform.rotation = gRotation;
        }
        
        if(Input.GetKey(KeyCode.Mouse0))
        {
            //rotated = false;
            command = 1;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //rotated = false;
            command = 2;
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            //rotated = false;
            command = 0;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            flipped *= -1;
            if(flipped == -1)
            {
                transform.localScale += scaleChangeDown;
            }
            else
            {
                transform.localScale += scaleChangeUp;
            }

            
        }

    }
}
