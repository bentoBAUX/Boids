using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    private Separation separation;
    private Alignment alignment;
    private Cohesion cohesion;
    private Wrap wrap;

    //Separation
    public float FOVAngle;
    public float personalSpaceRadius;
    
    //Alignment
    public float neighbourRadius;
    
    //Wrap 
    public float wrapRadius;
    public Vector3 wrapOrigin;


    private static Transform[] boids;

    [System.Serializable]
    public class Rules
    {
        public bool Separation=false;
        public bool Alignment=false;
        public bool Cohesion=false;
        public bool Wrap=false;
    }

    public Rules rules;
  
    
    private void Start()
    {
        this.separation = GetComponent<Separation>();
        this.alignment = GetComponent<Alignment>();
        this.cohesion = GetComponent<Cohesion>();
        this.wrap = GetComponent<Wrap>();

        boids = FindObjectsOfType<BoidBehaviour>().Select(b => b.transform).ToArray();
        
    }

    private void Update()
    {
        ApplyRules();
    }


    // Apply rules to a specific boid
    public void ApplyRules()
    {
        foreach (var boid in boids)
        {
            StartCoroutine(applyRules(boid));
        }
    }

    IEnumerator applyRules(Transform boid)
    {   
        separation.Apply(boid,rules.Separation,FOVAngle,personalSpaceRadius);
        alignment.Apply(boid,rules.Alignment,FOVAngle, neighbourRadius);
        cohesion.Apply(boid,rules.Cohesion, FOVAngle, neighbourRadius);
        wrap.Apply(boid,rules.Wrap, wrapRadius, wrapOrigin);
        yield return null;
    }

    public static Transform[] Boids => boids;
}
