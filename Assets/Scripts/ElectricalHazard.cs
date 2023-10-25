using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalHazard : MonoBehaviour
{
    public GameObject player;
    private PlayerAvatar playerAvatar;


    void Start()
    {
        playerAvatar = FindObjectOfType<PlayerAvatar>();
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
