using System;
using UnityEngine;


public class Alignment:Rule
{
    public override void Apply(Transform boidTransform, bool enabled, float FOVAngle, float boundaryRadius)
    {
        this.enabled = enabled;
        this.FOVAngle = FOVAngle;

        Vector3 directionToBoids = Vector3.zero;
        float numberOfBoids = 0;
        
        if (enabled)
        {
            Debug.Log("Separation On");
            foreach (Transform boid in RuleManager.Boids)
            {
                if (boid == boidTransform)
                    continue;
                
                if (IsWithinFOV(boidTransform, boid))
                {
                    float distanceToBoids = Vector3.Distance(boid.position,boidTransform.position);
                    
                    if (distanceToBoids <= boundaryRadius)
                    {
                        Debug.Log("AVOID");
                        directionToBoids += boid.forward;
                        numberOfBoids++;
                    }
                }
                
            }

            if (numberOfBoids > 0)
            {
                directionToBoids /= numberOfBoids;
            }
            
            boidTransform.GetComponent<BoidBehaviour>().AddSteer(directionToBoids.normalized);
        }
    }
}
