using UnityEngine;


public abstract class Rule: MonoBehaviour
{
    private bool enabled = false;
    public abstract void Apply(Transform boidTransform, bool enabled);
}
