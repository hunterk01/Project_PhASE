using UnityEngine;
using System.Collections;

public class Trigger_Door : MonoBehaviour
{
    public Transform door;

    public float doorOffset = 3;
    public float doorTotalTime = 4;
    public bool moveUp = true;

    public Vector3 doorStartPosition;
    public Vector3 doorUpPosition, doorDownPosition;

    private float doorElapsedTime;
    private bool gateOn = false;
    private bool gateRaised = false;

    void Start()
    {
        doorStartPosition = door.localPosition;
        doorUpPosition = door.localPosition + (Vector3.up * doorOffset);
        doorDownPosition = door.localPosition + (Vector3.up * -doorOffset);
    }

    void Update()
    {
        if (gateOn && !gateRaised)
        {
            if (moveUp)
                RaiseDoor();
            else
                LowerDoor();
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
}
