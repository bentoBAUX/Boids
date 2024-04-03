using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (0.2f * Time.deltaTime);
    }
}
