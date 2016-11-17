using UnityEngine;
using System.Collections;

public class RisingPlatform : MonoBehaviour
{
    public float platformTop;
    public float platformBottom;
    public float platformSpeed = 1.5f;

    private Rigidbody rb;
    public Vector3 upPosition;
    public Vector3 downPosition;

    public float angVel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upPosition = new Vector3(transform.position.x, platformTop, transform.position.z);
        downPosition = new Vector3(transform.position.x, platformBottom, transform.position.z);
    }

	void Update ()
    {
        MovePlatform();
	}

    void MovePlatform()
    {
        angVel = rb.angularVelocity.y;

        if (rb.angularVelocity.y < 0)
        {
            if (transform.position.y < platformTop)
            {
                transform.position = Vector3.MoveTowards(transform.position, upPosition, platformSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = upPosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            }
        }
        else if (rb.angularVelocity.y > 0)
        {
            if (transform.position.y > platformBottom)
            {

                transform.position = Vector3.MoveTowards(transform.position, downPosition, platformSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = downPosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            }
        }
        else
        {
            if (rb.velocity.y == 0)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                 RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
        }
    }
}
