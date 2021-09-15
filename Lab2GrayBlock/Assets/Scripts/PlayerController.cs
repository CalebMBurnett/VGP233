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

    private int flipped = 1;
    private bool upSide = true;
    private float gChangeLevel = 14.25f;
    private Vector3 scaleChangeDown;
    private Vector3 scaleChangeUp;

    void Start()
    {
        transform.Rotate(rotationOffset);
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();

        scaleChangeDown = new Vector3(0.0f, transform.localScale.y * -2, 0.0f);
        scaleChangeUp = new Vector3(0.0f, transform.localScale.y * 2, 0.0f);

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bounds();
        Flip();
    }

    private void Movement()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y, 0);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0.0f, 0.0f));
        
        if (Input.GetKeyDown(KeyCode.Space) && OnGroud()) 
        {
            if(upSide)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else playerRb.AddForce(Vector3.up * -jumpForce, ForceMode.Impulse);

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
        if(upSide)
        {
            return Physics.CheckCapsule(playerCollider.bounds.center
            , new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y, playerCollider.bounds.center.z)
            , playerCollider.size.y / 2 * 0.95f, jumpLayers);
        }
        else
        {
            return Physics.CheckCapsule(playerCollider.bounds.center
            , new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.max.y, playerCollider.bounds.center.z)
            , playerCollider.size.y / 2 * 0.95f, jumpLayers);
        }
        


        
    }

    private void Flip()
    {
        if (transform.position.y > gChangeLevel)
        {
            upSide = false;
            if(flipped == 1)
            {
                flipped *= -1;
                transform.localScale += scaleChangeDown;
                Physics.gravity *= -1;
            }
        }
        else if(transform.position.y < gChangeLevel && upSide == false)
        {
            upSide = true;
            if(flipped == -1)
            {
                flipped *= -1;
                transform.localScale += scaleChangeUp;
                Physics.gravity *= -1;
            }
        }

    }

}
