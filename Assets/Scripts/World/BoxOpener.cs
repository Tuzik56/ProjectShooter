using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpener : InteractibleItem
{
    [SerializeField] private Animator animator;

    override
    public void Interact()
    {
        Open();
    }

    private void Open()
    {
        animator.SetBool("Open", true);
        gameObject.layer = 11;
    }
}
