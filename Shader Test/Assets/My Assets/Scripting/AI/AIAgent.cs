using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIAgent : MonoBehaviour
{


    private NavMeshAgent agent;

    public List<Transform> nodes;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(nodes[index].position);

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < agent.stoppingDistance)
        {
            index++;
            if(index >= nodes.Count)
            {
                index = 0;
            }
            agent.SetDestination(nodes[index].position);
        }
    }
}
