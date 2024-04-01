using System;
using UnityEngine;


public class Alignment:Rule 
{
    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.enabled = enabled;
    }

    private void Update()
    {
        if (enabled)
        {
            Debug.Log("Alignment On");
        }
    }
}
