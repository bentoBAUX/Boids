using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    public BoidController controller;
    [SerializeField] private float steeringSpeed;
    
    void Update()
    {
        var steering = Vector3.zero;

        if (steering != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(steering), steeringSpeed * Time.deltaTime );
        }
        
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        transform.Translate(forwardDirection * (controller.speed * Time.deltaTime));
    }

    public float SteeringSpeed
    {
        get => steeringSpeed;
        set => steeringSpeed = value;
    }
}
