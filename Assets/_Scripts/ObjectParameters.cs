using UnityEngine;
using System.Collections;

public class ObjectParameters : MonoBehaviour
{
    public bool canKinetic = true;
    public bool canMass = false;
    public bool canTorque = false;
    public bool canGravity = false;

    public float minMass = 1;
    public float maxMass = 12;
    public float minScale = 0.5f;
    public float maxScale = 5;
}
