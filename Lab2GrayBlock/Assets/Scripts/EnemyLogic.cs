using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    //private Rigidbody enemyRb;
    public float speed;
    void Start()
    {
        if (transform.position.x > 0)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (transform.position.x < -25 || transform.position.x > 45)
        {
            Destroy(gameObject);
        }
    }
}
