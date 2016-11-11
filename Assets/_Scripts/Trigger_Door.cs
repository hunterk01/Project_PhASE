using UnityEngine;
using System.Collections;

public class Trigger_Door : MonoBehaviour
{
    public Transform door;

    public float doorOffset = 3;
    public float doorTotalTime = 4;
    public bool isVertical = true;

    public bool moveUp = true;
    public bool moveRight = false;

    public Vector3 doorStartPosition;
    public Vector3 doorUpPosition, doorDownPosition;

    private float doorElapsedTime = 0;
    private bool gateOn = false;
    private bool gateRaised = false;



    void Start()
    {
        doorStartPosition = door.localPosition;

        if (isVertical)
        {
            doorUpPosition = door.localPosition + (Vector3.up * doorOffset);
            doorDownPosition = door.localPosition + (Vector3.up * -doorOffset);
        }
        else
        {
            doorUpPosition = door.localPosition + (Vector3.right * doorOffset);
            doorDownPosition = door.localPosition + (Vector3.right * -doorOffset);
        }
    }

    void Update()
    {
        if (gateOn && !gateRaised)
        {
            if (isVertical)
            {
                if (moveUp)
                    RaiseDoor();
                else
                    LowerDoor();
            }
            else
            {
                if (moveRight)
                    MoveRight();
                else
                    MoveLeft();
            }
        }
    }

    void OnTriggerEnter()
    {
        gateOn = true;
        gameObject.GetComponent<Collider>().enabled = false;
    }

    void RaiseDoor()
    {
        doorElapsedTime += Time.deltaTime;
        door.localPosition = Vector3.Lerp(doorStartPosition, doorUpPosition, doorElapsedTime / doorTotalTime);

        if (door.localPosition.y >= doorUpPosition.y)
        {
            gateRaised = true;
            door.localPosition = doorUpPosition;
        }
    }

    void LowerDoor()
    {
        doorElapsedTime += Time.deltaTime;
        door.localPosition = Vector3.Lerp(doorStartPosition, doorDownPosition, doorElapsedTime / doorTotalTime);

        if (door.localPosition.y <= doorDownPosition.y)
        {
            gateRaised = true;
            door.localPosition = doorDownPosition;
        }
    }

    void MoveRight()
    {
        doorElapsedTime += Time.deltaTime;
        door.localPosition = Vector3.Lerp(doorStartPosition, doorUpPosition, doorElapsedTime / doorTotalTime);

        if (door.localPosition.z >= doorUpPosition.z)
        {
            gateRaised = true;
            door.localPosition = doorUpPosition;
        }
    }

    void MoveLeft()
    {
        doorElapsedTime += Time.deltaTime;
        door.localPosition = Vector3.Lerp(doorStartPosition, doorDownPosition, doorElapsedTime / doorTotalTime);

        if (door.localPosition.x <= doorDownPosition.x)
        {
            gateRaised = true;
            door.localPosition = doorDownPosition;
        }
    }
}
