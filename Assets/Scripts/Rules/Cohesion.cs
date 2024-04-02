using UnityEngine;


public class Cohesion : Rule
{
    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.enabled = enabled;
        if (enabled)
            Debug.Log("Cohesion On");
    }
    
    
}
