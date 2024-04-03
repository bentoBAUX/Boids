using UnityEngine;


public class Cohesion : Rule
{
    public override void Apply(Transform boidTransform, bool enabled, float FOVAngle, float boundaryRadius)
    {
        base.Apply(boidTransform, enabled, FOVAngle, boundaryRadius);
    }
}
