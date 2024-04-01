using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    private Separation separation;
    private Alignment alignment;
    private Cohesion cohesion;

    private Transform[] boids;
    
    [System.Serializable]
    public class Rules
    {
        public bool Separation;
        public bool Alignment;
        public bool Cohesion;
    }

    public Rules rules;
  
    
    private void Start()
    {
        this.separation = GetComponent<Separation>();
        this.alignment = GetComponent<Alignment>();
        this.cohesion = GetComponent<Cohesion>();

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
            separation.Apply(boid,rules.Separation);
            alignment.Apply(boid,rules.Alignment);
            cohesion.Apply(boid,rules.Cohesion);
        }
    }

}
