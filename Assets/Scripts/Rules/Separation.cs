using UnityEngine;


public class Separation:Rule
{
    public override void Apply(Transform boidTransform, bool enabled)
    {
        this.enabled = enabled;
    }

    private void Update()
    {
        if (enabled)
        {
            Debug.Log("Separation On");
        }
    }
}
