using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDoor : MonoBehaviour
{
    private GameObject door;
    public GameObject player;
    public float openTime = 2.0f;
    public Vector3 endPos;
    private Vector3 startPos;

    void Start()
    {
        door = GameObject.Find("Door");
        startPos = door.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            door.transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime);
        }
    }
}