using UnityEngine;
using System;
using System.Collections.Generic;
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

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));
        List<Collider> colliderList = new List<Collider>();

        for(int _i = 0; _i < colliders.Length; _i++)
        {
            if (IsTransformInCone(colliders[_i].transform, transform.position, transform.forward, 45))
            {
                colliderList.Add(colliders[_i]);
            }
        }


        if (colliderList.Count > 0)
        {
            if (colliderList[0].gameObject.GetComponent<Outline>() != null && colliderList[0] != null)
            {
                colliderList[0].gameObject.GetComponent<Outline>().enabled = true;
            }


            if (Input.GetButtonDown("Steal"))
            {

                colliderList[0].gameObject.GetComponent<Interactable>().Interact();

            }
        }

        /*
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
        }*/
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

    bool IsTransformInCone(Transform t, Vector3 coneTipPos, Vector3 coneDirection, float coneHalfAngle)
    {
        Vector3 directionTowardT = t.position - coneTipPos;
        float angleFromConeCenter = Vector3.Angle(directionTowardT, coneDirection);
        return angleFromConeCenter <= coneHalfAngle;
    }

}
