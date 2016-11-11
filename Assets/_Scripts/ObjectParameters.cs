using UnityEngine;
using System.Collections;

public class ObjectParameters : MonoBehaviour
{
   // LaserController laserController;
    public bool canKinetic = true;
    public bool canMass = false;
    public bool canTorque = false;
    public bool canGravity = false;

    public float minMass = 1;
    public float maxMass = 12;
    public float minScale = 0.5f;
    public float maxScale = 5;
    private Rigidbody rb;

    [HideInInspector]
    public float currentMassPercentage, currentScalePercentage;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MassScaler();
    }

    void MassScaler()
    {
        currentScalePercentage = (gameObject.transform.localScale.y / maxScale) *100;
        rb.mass = (currentScalePercentage / 100) * maxMass;
    }
}
