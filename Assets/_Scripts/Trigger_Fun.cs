using UnityEngine;
using System.Collections;

public class Trigger_Fun : MonoBehaviour
{
    public GameObject funStuff;

    void OnTriggerEnter()
    {
        funStuff.SetActive(true);
        gameObject.SetActive(false);
    }
}
