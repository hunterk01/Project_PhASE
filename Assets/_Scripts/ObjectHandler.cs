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

    Vector3 vMinMass, vMaxMass;
    Vector3 vMinScale, vMaxScale;

    void Start()
    {
        vMinMass = new Vector3(minMass, minMass, minMass);
        vMaxMass = new Vector3(maxMass, maxMass, maxMass);
        vMinScale = new Vector3(minScale, minScale, minScale);
        vMaxScale = new Vector3(maxScale, maxScale, maxScale);
    }

    void Update()
    {

    }

    void UpdateMass()
    {

    }
}
