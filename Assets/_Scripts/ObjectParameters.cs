using UnityEngine;
using System.Collections;

public class ObjectParameters : MonoBehaviour
{
   // LaserController laserController;
    public bool canKinetic = true;
    public bool canMass = false;
    public bool canTorque = false;
    public bool canGravity = false;

    public bool noScale = false;

    public float minMass;
    public float maxMass;
    public float minScale;
    public float maxScale;
    private Rigidbody rb;

    [HideInInspector]
    public float currentMassPercentage, currentScalePercentage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (!noScale)   MassScaler();
    }

    void MassScaler()
    {
        currentScalePercentage = (gameObject.transform.localScale.y / maxScale) *100;
        rb.mass = (currentScalePercentage / 100) * maxMass;
    }
}
