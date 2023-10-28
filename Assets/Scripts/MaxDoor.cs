using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxDoor : MonoBehaviour
{
    private GameObject player;
    private Transform door;
    private Vector3 openPos, closedPos;
    public float speed, distanceToDoor;
    private bool doorIsOpen;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = transform.Find("Door");

        closedPos = new Vector3(0f, 0f, 0f);
        openPos = new Vector3(0f, -10f, 0f);

        doorIsOpen = false;
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < distanceToDoor && doorIsOpen == false) //if your close enough to the door
        {
            if (door.transform.position.y >= openPos.y) //if the door is greater than the open pos
            {
                door.transform.Translate(0, -speed * Time.deltaTime, 0); //move the door down
            }

            if (door.transform.position.y <= openPos.y) //if the door is at the open pos
            {
                doorIsOpen = true;
            }
        }

        if (Vector3.Distance(player.transform.position, transform.position) > distanceToDoor && doorIsOpen == true)
        {
            if (door.transform.position.y <= closedPos.y) // if the door is less than the closed position
            {
                door.transform.Translate(0, speed * Time.deltaTime, 0); //move the door up
            }

            if (door.transform.position.y >= closedPos.y) //if the door is at the closed pos
            {
                doorIsOpen = false;
            }
        }
    }
}