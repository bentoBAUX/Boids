using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour
{
    public BoidController controller;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        transform.Translate(forwardDirection * (controller.speed * Time.deltaTime));
    }
}
