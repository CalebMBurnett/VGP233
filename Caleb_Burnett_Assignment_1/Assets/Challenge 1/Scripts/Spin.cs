using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private float rotationSpeed = 300.0f;
    private Vector3 rotation = new Vector3(0.0f, 0.0f, 1.0f);
    void Update()
    {
        // Rotate Propeller 
        transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
    }
}
