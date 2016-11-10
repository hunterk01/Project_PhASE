using UnityEngine;
using System.Collections;

public class ObjectHandler : MonoBehaviour
{
    public bool canKinetic = true;
    public bool canMass = false;
    public bool canTorque = false;
    public bool canGravity = false;

    public float minMass = 1;
    public float maxMass = 12;
    public float minScale = 0.5f;
    public float maxScale = 5;

    Vector3 vMinMass, vMaxMass, vCurrentMass;
    Vector3 vMinScale, vMaxScale, vCurrentScale;

    private float objectChangePercentage;

    void Start()
    {
        vMinMass = new Vector3(minMass, minMass, minMass);
        vMaxMass = new Vector3(maxMass, maxMass, maxMass);
        vMinScale = new Vector3(minScale, minScale, minScale);
        vMaxScale = new Vector3(maxScale, maxScale, maxScale);

        vCurrentScale = transform.localScale;

        // Calculate the change percentage of scale and apply it to mass

    }

    public void UpdateMass(float _percentage)
    {
        // Apply percentage change to scale and mass

    }
}
