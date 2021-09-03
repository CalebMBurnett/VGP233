using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravityMod;
    public LayerMask jumpLayers;

    private bool gameOver = false;

    private Rigidbody playerRb;
    private BoxCollider playerCollider;
    private Animator playerAnimator;
    private Vector3 inputVector;
    private Vector3 rotationOffset = new Vector3(0.0f, -90.0f, 0.0f);
    private float gChangeLevel = 13.75f;

    private float currentTime = 0.0f;
    private float rotationTime = 2.0f;
    private float angle = 180f;
    private bool upsideDown = false;


    void Start()
    {
        transform.Rotate(rotationOffset);
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        Physics.gravity *= -gravityMod;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bounds();
        //GravityChange();
        currentTime += Time.deltaTime;
        if(currentTime > rotationTime)
        {
            upsideDown = true;
            currentTime = 0;
        }
        if(!upsideDown)
        {
            Quaternion gRotation = new Quaternion();
            gRotation.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Mathf.LerpAngle(transform.rotation.z, angle, currentTime / rotationTime));
            transform.rotation = gRotation;
        }
    }

    private void Movement()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y, 0);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0.0f, 0.0f));

        if (Input.GetKeyDown(KeyCode.Space) && OnGroud())
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Bounds()
    {
        if (transform.position.x < -15.4f || transform.position.x > 35f) // out of bounds 
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
    private void FixedUpdate()
    {
        playerRb.velocity = inputVector;
    }

    private bool OnGroud()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center
            , new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y, playerCollider.bounds.center.z)
            , playerCollider.size.y / 2 * 0.95f, jumpLayers);
    }

    private void GravityChange()
    {
        if (transform.position.y > gChangeLevel)
        {
            Physics.gravity *= -gravityMod;
            //currentTime += Time.deltaTime;
            //if(currentTime > rotationTime)
            //{
            //    upsideDown = true;
            //    currentTime = 0;
            //}
            //if(!upsideDown)
            //{
            //    Quaternion gRotation = new Quaternion();
            //    gRotation.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Mathf.LerpAngle(transform.rotation.z, angle, currentTime / rotationTime));
            //    transform.rotation = gRotation;
            //}
        }
        
        //if(upsideDown && transform.position.y < gChangeLevel)
        //{
        //    currentTime += Time.deltaTime;
        //    if (currentTime > rotationTime)
        //    {
        //        upsideDown = false;
        //        currentTime = 0;
        //    }
        //    Quaternion gRotation = new Quaternion();
        //    gRotation.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, Mathf.LerpAngle(transform.rotation.z, angle, currentTime / rotationTime));
        //    transform.rotation = gRotation;
        //}

    }

}
