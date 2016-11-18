using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
    public Rigidbody rb;
    public float torqueForce = 10;
   
    void Start () {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rb.AddRelativeTorque(Vector3.up * torqueForce);
        rb.AddRelativeTorque(Vector3.right * torqueForce);
    }
	
	
}
