using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    public BoidController controller;
    [SerializeField] private float steeringSpeed;

    private Vector3 steerDirection;

    private void Start()
    {
        steerDirection = Vector3.zero;
    }

    void Update()
    {
        transform.position += transform.forward * (controller.speed * Time.deltaTime);
    }

    public void AddSteer(Vector3 steerDirection)
    {
        this.steerDirection += steerDirection;
        
        if (steerDirection != Vector3.zero)
        {
            Debug.Log("Steering");
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(this.steerDirection), steeringSpeed * Time.deltaTime );
        }
    }

    public float SteeringSpeed
    {
        get => steeringSpeed;
        set => steeringSpeed = value;
    }
}
