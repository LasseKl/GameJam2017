using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour
{
    void Update()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0.5f);
        //Debug.Log("animating");
    }
}
