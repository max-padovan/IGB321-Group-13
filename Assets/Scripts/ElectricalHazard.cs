using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalHazard : MonoBehaviour
{
    private PlayerAvatar playerAvatar;
    // Start is called before the first frame update
    void Start()
    {
        playerAvatar = FindObjectOfType<PlayerAvatar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAvatar.moveSpeed = playerAvatar.moveSpeed * 0.75f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAvatar.moveSpeed = 7.0f;
        }
    }
}
