using UnityEngine;


public class Separation:Rule
{
    public override void Apply(Transform boidTransform, bool enabled, float FOVAngle, float boundaryRadius)
    {
        this.enabled = enabled;
        this.FOVAngle = FOVAngle;

        Vector3 directionToBoids = Vector3.zero;
        float numberOfBoidsToAvoid = 0;
        
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
                        directionToBoids += boid.position - boidTransform.position;
                        numberOfBoidsToAvoid++;
                    }
                }
                
            }

            if (numberOfBoidsToAvoid > 0)
            {
                directionToBoids /= numberOfBoidsToAvoid;
            }
            
            boidTransform.GetComponent<BoidBehaviour>().AddSteer(-directionToBoids.normalized);
        }
    }

    


}
