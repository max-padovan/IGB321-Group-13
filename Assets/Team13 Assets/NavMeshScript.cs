using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] patrolPoints = new GameObject[4];
    private int patrolPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveNavMesh();   
    }

    private void MoveNavMesh()
    {
        if (patrolPointIndex >= patrolPoints.Length)
        {
            patrolPointIndex = 0;
        }

        agent.SetDestination(patrolPoints[patrolPointIndex].transform.position);

        if(agent.remainingDistance < 0.5f)
        {
            patrolPointIndex++;
            Debug.Log(patrolPointIndex);
        }
    }
}
