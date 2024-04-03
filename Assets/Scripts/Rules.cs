using UnityEngine;

public class Rules:MonoBehaviour
{
    private float FOVAngle;
    private float enabled;

    private float distanceToOtherBoid;

    private Vector3 separationDirection;
    private Vector3 alignmentDirection;
    private Vector3 cohesionDirection;
    
    private float separationCount;
    private float alignmentCount;
    private float cohesionCount;

    private float separationWeight;
    private float alignmentWeight;
    private float cohesionWeight;

    public void Apply(Transform thisBoid, bool applySeparation, bool applyAlignment, bool applyCohesion, float FOVAngle,
        float separationThreshold, float proximityThreshold, float separationWeight, float alignmentWeight, float cohesionWeight)
    {
        this.FOVAngle = FOVAngle;
        foreach (Transform otherBoid in RuleManager.Boids)
        {
            distanceToOtherBoid = Vector3.Distance(thisBoid.position, otherBoid.position);
            if (!applySeparation && !applyAlignment && !applyCohesion || (otherBoid == thisBoid))
            {
                continue;
            }


            if ((IsWithinFOV(thisBoid, otherBoid)))
            {
                if (applySeparation)
                {
                    if (distanceToOtherBoid < separationThreshold)
                    {
                        separationDirection = otherBoid.position - thisBoid.position;
                        separationCount++;
                    }
                }

                if (applyAlignment)
                {
                    if (distanceToOtherBoid < proximityThreshold)
                    {
                        alignmentDirection += otherBoid.forward;
                        alignmentCount++;
                    }
                }

                if (applyCohesion)
                {
                    if (distanceToOtherBoid < proximityThreshold)
                    {
                        cohesionDirection = otherBoid.position - thisBoid.position;
                        cohesionCount++;
                    }
                }
            }
        }

        if (separationCount > 0)
            separationDirection /= separationCount;

        if (alignmentCount > 0)
            alignmentDirection /= alignmentCount;

        if (cohesionCount > 0)
            cohesionDirection /= cohesionCount;

        Vector3 resultantDirection = (-separationDirection.normalized * 0.5f) + (alignmentDirection.normalized * 0.34f) +
                                     (cohesionDirection.normalized * 0.16f);
        
        thisBoid.GetComponent<BoidBehaviour>().AddSteer(resultantDirection.normalized);
    }
    
    public bool IsWithinFOV(Transform thisBoid, Transform otherBoid)
    {
        Vector3 directionToOther = otherBoid.position - thisBoid.position;
        float angleToOther = Vector3.Angle(thisBoid.forward, directionToOther);
        return angleToOther <= FOVAngle * 0.5f;
    }
}
