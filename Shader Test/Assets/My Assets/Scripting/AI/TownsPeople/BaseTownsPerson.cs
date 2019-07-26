using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BaseTownsPerson : MonoBehaviour
{

    private NavMeshAgent agent;
    private Destination targetDest;

    public List<Destination> dests;

    private float time;
    public Vector2 timeRange;

    // Start is called before the first frame update
    void Start()
    {
        dests = new List<Destination>();
        dests.AddRange(FindObjectsOfType<Destination>());
        agent = GetComponent<NavMeshAgent>();
        GoToRandomDest();
    }

    // Update is called once per frame
    void Update()
    {
        ApproachingDest();
    }


    void GoToRandomDest()
    {
        while(targetDest == null)
        {
            int rand = Random.Range(0, dests.Count);
            if(dests[rand].occupied == false)
            {
                dests[rand].occupied = true;
                targetDest = dests[rand];
                agent.SetDestination(targetDest.transform.position);
                time = Random.Range(timeRange.x, timeRange.y);
            }
        }
    }

    void ApproachingDest()
    {
        if(agent.remainingDistance > agent.stoppingDistance)
        {

        }
        else
        {
            if(targetDest != null)
            {
                RotateEnd(targetDest.transform);
            }
            time -= Time.deltaTime;
            if(time <= 0)
            {
                targetDest.occupied = false;
                targetDest = null;
                GoToRandomDest();
            }

        }
    }

    void RotateEnd(Transform t)
    {
        transform.LookAt(t);
        //var step = 0.5f * Time.deltaTime;

        // Rotate our transform a step closer to the target's.
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, t.rotation, step);

        // Euler angles are easier to deal with. You could use Quaternions here also
        // C# requires you to set the entire rotation variable. You can't set the individual x and z (UnityScript can), so you make a temp Vec3 and set it back
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        eulerAngles.y = t.rotation.eulerAngles.y;

        // Set the altered rotation back
        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
