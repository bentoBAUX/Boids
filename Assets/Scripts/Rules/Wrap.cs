﻿using System;
using System.Collections;
using UnityEngine;


public class Wrap: Rule
{
    private float wrapRadius;
    private Vector3 origin;
    
    private Transform boidTransform;

    [SerializeField]private float epsilon;
    
    

    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.boidTransform = boidTransform;
        this.enabled = enabled;
    }

    public void Apply(Transform boidTransform, bool enabled, float wrapRadius, Vector3 origin)
    {
        this.enabled = enabled;
        this.wrapRadius = wrapRadius;
        this.origin = origin;
        
        if (enabled && isOutside(boidTransform))
        {
            setNewPosition(boidTransform);
        }
    }
    
    public void setNewPosition(Transform boidTransform)
    {
        Vector3 directionToCenter = (origin - boidTransform.position).normalized;
        Vector3 newPosition = origin + directionToCenter * (wrapRadius - epsilon);
        
        boidTransform.position = newPosition;
    }

    public bool isOutside(Transform boidTransform)
    {
        return Vector3.Distance(boidTransform.position,origin)>wrapRadius;
    }
}