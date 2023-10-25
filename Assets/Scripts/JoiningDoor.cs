using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoiningDoor : MonoBehaviour
{
    public Transform leftDoorTransform;
    public Transform rightDoorTransform;
    public float slideSpeed = 2.0f;
    public GameObject player;
    public Vector3 howfartoMoveDoorsright;
    public Vector3 howfartoMoveDoorsleft;
    private Vector3 openPositionright;
    private Vector3 openPositionleft;
    private Vector3 closedPositionright;
    private Vector3 closedPositionleft;

    private bool areDoorsOpen = false;

    private void Start()
    {
        closedPositionleft = leftDoorTransform.position;
        closedPositionright = rightDoorTransform.position;
        openPositionleft = closedPositionleft + howfartoMoveDoorsleft;
        openPositionright = closedPositionright + howfartoMoveDoorsright;
        //CloseDoors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !areDoorsOpen)
        {
            StartCoroutine(OpenDoorsSmoothly());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && areDoorsOpen)
        {
            StartCoroutine(CloseDoorsSmoothly());
        }
    }

    private IEnumerator OpenDoorsSmoothly()
    {
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(leftDoorTransform.position, openPositionleft);
        while (Vector3.Distance(leftDoorTransform.position, openPositionleft) > 0.01f) // Adjust the threshold as needed
        {
            float distanceCovered = (Time.time - startTime) * slideSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            leftDoorTransform.position = Vector3.Lerp(closedPositionleft, openPositionleft, fractionOfJourney);
            rightDoorTransform.position = Vector3.Lerp(closedPositionright, openPositionright, fractionOfJourney);
            yield return null;
        }
        areDoorsOpen = true;
    }

    private IEnumerator CloseDoorsSmoothly()
    {
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(leftDoorTransform.position, closedPositionleft);
        while (Vector3.Distance(leftDoorTransform.position, closedPositionleft) > 0.01f) // Adjust the threshold as needed
        {
            float distanceCovered = (Time.time - startTime) * slideSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            leftDoorTransform.position = Vector3.Lerp(openPositionleft, closedPositionleft, fractionOfJourney);
            rightDoorTransform.position = Vector3.Lerp(openPositionright, closedPositionright, fractionOfJourney);
            yield return null;
        }
        areDoorsOpen = false;
    }

    private void Update()
    {
        // You can add any additional update logic here.
    }
}