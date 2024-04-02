using UnityEngine;


public class Separation:Rule
{
    private float FOVAngle;
    
    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.enabled = enabled;
    }

    public void Apply(Transform boidTransform, bool enabled, float FOVAngle)
    {
        this.enabled = enabled;
        this.FOVAngle = FOVAngle;
        if (enabled)
        {
            Debug.Log("Separation On");
            foreach (Transform boid in RuleManager.Boids)
            {
                if (IsWithinFOV(boidTransform, boid))
                {
                    
                }
            }
        }
    }

    bool IsWithinFOV(Transform thisBoid, Transform otherBoid)
    {
        Vector3 directionToOther = otherBoid.position - thisBoid.position;
        float angleToOther = Vector3.Angle(thisBoid.forward, directionToOther);
        return angleToOther <= FOVAngle * 0.5f;
    }


}
