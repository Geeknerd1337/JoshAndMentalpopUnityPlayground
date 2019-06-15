using UnityEngine;
using System;
using cakeslice;
public class Sense : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checkLayers;
    public Outline[] outlines;
    public float radius;
    public float depth;
    public float angle;
    private Physics physics;

    public void Start()
    {
        outlines = FindObjectsOfType<Outline>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Sense"))
        {

        }
        ResetAllOutlines();
        GetNearestObject();

      
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }


    void GetNearestObject()
    {
        RaycastHit[] coneHits = physics.ConeCastAll(transform.position, radius, transform.forward, depth, angle, checkLayers);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        //Array.Sort(coneHits, new DistanceComparer(transform));
        System.Array.Sort(coneHits, (x, y) => x.distance.CompareTo(y.distance));

        if (colliders.Length > 0)
        {
            if (coneHits[0].transform.gameObject.GetComponent<Outline>() != null && colliders[0] != null)
            {
                coneHits[0].transform.gameObject.GetComponent<Outline>().enabled = true;
            }


            if (Input.GetButtonDown("Steal"))
            {

                coneHits[0].transform.gameObject.GetComponent<Interactable>().Interact();
                
            }
        }
    }

    void ResetAllOutlines()
    {
        foreach (Outline o in outlines)
        {
            if (o != null)
            {
                o.enabled = false;
            }
        }
    }

}
