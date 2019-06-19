using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{

    private Animator a;

    public void Start()
    {
        a = gameObject.GetComponent<Animator>();
    }
    public override void Interact()
    {
        base.Interact();
        a.SetBool("IsPressed", !a.GetBool("IsPressed"));

    }
}
