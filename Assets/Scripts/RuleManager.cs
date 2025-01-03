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
    private Rules rules;
    private Wrap wrap;

    [System.Serializable]
    public class RulesSettings
    {
        [Space(10)]
        public float FOVAngle;
        [Space(20)]
        public float separationThreshold;
        public float proximityThreshold;
        [Space(20)]
        [Range(0,200)]public float separationWeight;
        [Range(0,200)]public float alignmentWeight;
        [Range(0,200)]public float cohesionWeight;
        [Range(0,200)]public float leadershipWeight;
    }
    
    [System.Serializable]
    public class WrapSettings
    {
        [Space(10)]
        public float wrapRadius;
        [Space(10)]
        public Transform wrapOrigin;
    }

    [System.Serializable]
    public class RulesMenu
    {
        [Space(10)]
        public bool Separation=false;
        public bool Alignment=false;
        public bool Cohesion=false;
        public bool Leadership = false;
        [Space(10)]
        public bool Wrap=false;
    }

    private static Transform[] boids;

    public RulesMenu rulesMenu;
    [Space(10)]
    public RulesSettings rulesSettings;
    [Space(10)]
    public WrapSettings wrapSettings;
  
    
    private void Start()
    {
        this.rules = GetComponent<Rules>();
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
        rules.Apply(boid, rulesMenu.Separation, rulesMenu.Alignment, rulesMenu.Cohesion, rulesMenu.Leadership,
                                        rulesSettings.FOVAngle, rulesSettings.separationThreshold, rulesSettings.proximityThreshold, 
                                        rulesSettings.separationWeight/100f,rulesSettings.alignmentWeight/100f,rulesSettings.cohesionWeight/100f,rulesSettings.leadershipWeight/100f);
        wrap.Apply(boid,rulesMenu.Wrap, wrapSettings.wrapRadius, wrapSettings.wrapOrigin);
        yield return null;
    }

    public static Transform[] Boids => boids;
}
