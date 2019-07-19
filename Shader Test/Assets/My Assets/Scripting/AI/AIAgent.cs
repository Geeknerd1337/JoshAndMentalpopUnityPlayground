using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class AIAgent : MonoBehaviour
{


    private NavMeshAgent agent;

    public List<Transform> nodes;

    private int index;

    public ThirdPersonCharacter character;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(nodes[index].position);
        agent.updateRotation = false;

    }

    // Update is called once per frame
    void Update()
    {
        MoveNPC();
    }


    void MoveNPC()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            character.Move(Vector3.zero, false, false);
            Debug.Log("Reached this node");
            index++;
            if (index >= nodes.Count)
            {
                index = 0;
            }
            agent.SetDestination(nodes[index].position);
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }

    }
}
