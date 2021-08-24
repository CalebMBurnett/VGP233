using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    private int direction = 1;
    void Start()
    {
        if(transform.position.x > 0)
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * direction);
        
        if(transform.position.x < -25 || transform.position.x > 45)
        {
            Destroy(gameObject);
        }
    }
}
