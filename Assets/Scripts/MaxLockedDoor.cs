using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxLockedDoor : MonoBehaviour
{
    private Transform door;
    private Transform statusLight;
    private Vector3 openPos;
    public float speed;
    public string keyCardName;

    void Start()
    {
        door = transform.Find("Door");
        statusLight = transform.Find("status");
        openPos = new Vector3(0f, -10f, 0f);
    }

    void Update()
    {
        GameObject x = GameObject.Find(keyCardName);
        
        if (x == null)
        {
            if (door.transform.position.y >= openPos.y) //if the door is greater than the open pos
            {
                door.transform.Translate(0, -speed * Time.deltaTime, 0); //move the door down
                if (statusLight != null)
                {
                    Destroy(statusLight.gameObject);
                }
            }
        }
    }
}