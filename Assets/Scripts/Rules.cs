using UnityEngine;

public class Rules:MonoBehaviour
{
    private float FOVAngle;
    private float enabled;

    private float distanceToOtherBoid;

    private Vector3 separationDirection;
    private Vector3 alignmentDirection;
    private Vector3 cohesionDirection;
    private Vector3 leaderDirection;
    
    private float separationCount;
    private float alignmentCount;
    private float cohesionCount;
    

    public void Apply(Transform thisBoid, bool applySeparation, bool applyAlignment, bool applyCohesion, bool applyLeadership, float FOVAngle,
        float separationThreshold, float proximityThreshold, float separationWeight, float alignmentWeight, float cohesionWeight, float leadershipWeight)
    {
        this.FOVAngle = FOVAngle;
        float leadershipAngle = float.MaxValue;
        Transform leaderBoid = null;
        
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

                if (applyLeadership)
                {
                    if (distanceToOtherBoid < proximityThreshold)
                    {
                        leaderDirection = otherBoid.position - thisBoid.position;
                        var angle = Vector3.Angle(leaderDirection, thisBoid.forward);
                        if (angle < leadershipAngle)
                        {
                            leaderBoid = otherBoid;
                            leadershipAngle = angle;
                        }
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
        

        Vector3 resultantDirection = !ReferenceEquals(leaderBoid,null) ? (-separationDirection.normalized * separationWeight) + (alignmentDirection.normalized * alignmentWeight) +
                                     (cohesionDirection.normalized * cohesionWeight) + (leaderBoid.transform.position - transform.position).normalized * leadershipWeight : 
                                     (-separationDirection.normalized * separationWeight) + (alignmentDirection.normalized * alignmentWeight) + (cohesionDirection.normalized * cohesionWeight) ;
        
        thisBoid.GetComponent<BoidBehaviour>().AddSteer(resultantDirection.normalized);
    }
    
    public bool IsWithinFOV(Transform thisBoid, Transform otherBoid)
    {
        Vector3 directionToOther = otherBoid.position - thisBoid.position;
        float angleToOther = Vector3.Angle(thisBoid.forward, directionToOther);
        return angleToOther <= FOVAngle * 0.5f;
    }
}
