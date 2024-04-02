using System;
using UnityEngine;


public class Alignment:Rule 
{
    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.enabled = enabled;
        if (enabled)
            Debug.Log("Alignment On");
    }

}
