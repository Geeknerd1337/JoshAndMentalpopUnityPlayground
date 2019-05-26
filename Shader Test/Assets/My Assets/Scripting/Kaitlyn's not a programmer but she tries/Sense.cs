using UnityEngine;
using System;
using cakeslice;
public class Sense : MonoBehaviour
{
    public float checkRadius;
    public LayerMask checkLayers;
    public Outline[] outlines;


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
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        if (colliders.Length > 0)
        {
            if (colliders[0].gameObject.GetComponent<Outline>() != null && colliders[0] != null)
            {
                colliders[0].gameObject.GetComponent<Outline>().enabled = true;
            }


            if (Input.GetButtonDown("Steal"))
            {

                colliders[0].gameObject.GetComponent<Interactable>().Interact();
                
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
