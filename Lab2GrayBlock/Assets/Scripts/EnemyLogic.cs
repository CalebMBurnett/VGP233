using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public ParticleSystem explosion;

    public float speed;
    private float gChangeLevel = 14.25f;
    private Vector3 scaleFlip;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            explosion.Play();
            Destroy(gameObject);
        }
    }
}
