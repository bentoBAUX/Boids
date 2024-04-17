using System;
using System.Collections;
using UnityEngine;


public class Wrap: MonoBehaviour
{
    private float wrapRadius;
    private Transform origin;
    
    private Transform boidTransform;

    [SerializeField]private float epsilon;
    
    
    public void Apply(Transform boidTransform, bool enabled, float wrapRadius, Transform origin)
    {
        this.wrapRadius = wrapRadius;
        this.origin = origin;
        
        if (enabled && isOutside(boidTransform))
        {
            setNewPosition(boidTransform);
        }
    }
    
    public void setNewPosition(Transform boidTransform)
    {
        Vector3 directionToCenter = (origin.position - boidTransform.position).normalized;
        Vector3 newPosition = origin.position + directionToCenter * (wrapRadius - epsilon);
        
        boidTransform.position = newPosition;
    }

    public bool isOutside(Transform boidTransform)
    {
        return Vector3.Distance(boidTransform.position,origin.position)>wrapRadius;
    }
}
