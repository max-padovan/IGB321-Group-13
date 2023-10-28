using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firextinguisher : MonoBehaviour
{

    private float extRadius;
    public GameObject steamParticleEffect;
    private GameObject player;
    private float countdownTimer = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        steamParticleEffect.SetActive(false);
        extRadius = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) < extRadius)
        {
            steamParticleEffect.SetActive(true);
            Destroy(steamParticleEffect, countdownTimer);
            Destroy(this.gameObject, countdownTimer );
        }
    }
}
