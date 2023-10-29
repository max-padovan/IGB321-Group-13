using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorBehaviour : MonoBehaviour
{
    public Transform doorTransform;
    public bool isOpen = false;
    public float slideSpeed = 2.0f;
    public GameObject interactionPanel;
    public GameObject player;
    public Vector3 howfartoMoveDoor;
    private Vector3 openPosition;
    private Vector3 closedPosition;

    // Initialize the open and closed positions
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        closedPosition = doorTransform.position;
        openPosition = closedPosition + howfartoMoveDoor;
        HideInteractionPanel();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for player interaction (e.g., pressing a switch)
        if (isplayerCloseEnoughttoPanel())
        {
            //Debug.Log("Close enough");
            ShowInteractionPanel();

            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                //Debug.Log("Opening");
            }
        }
        else
        {
            HideInteractionPanel();
        }

        // Interpolate the door's position to create a smooth sliding effect
        if (isOpen)
        {
            doorTransform.position = Vector3.Lerp(doorTransform.position, openPosition, Time.deltaTime * slideSpeed);
        }
        else
        {
            doorTransform.position = Vector3.Lerp(doorTransform.position, closedPosition, Time.deltaTime * slideSpeed);
        }
    }

    private bool isplayerCloseEnoughttoPanel()
    {
        return (Vector3.Distance(player.transform.position, interactionPanel.transform.position) < 5.0f);
    }

    private void ShowInteractionPanel()
    {
        interactionPanel.SetActive(true);
    }

    private void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }
}
