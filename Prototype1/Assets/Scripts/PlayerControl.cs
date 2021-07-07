using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float forwardImput;
    public float horizontalImput;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting from player controll");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //horizontalImput = Imput.GetAxis("Horazontal");
        //forwardImput = Imput.GetAxis("Vertical");

        //// moves forward 
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardImput);

        //// rotates around Y-axis to steer 
        //transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalImput);



    }
}
