using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject levelUI;
    private GameManager gameManager;
    public bool isFinalTrigger;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        activateLevelUI();
    }

    public void activateLevelUI()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) < 5.0f)
        {
            levelUI?.SetActive(true);
        }
    }
    public void deactivateLevelUI()
    {
        Destroy(this.gameObject);
    }
}
