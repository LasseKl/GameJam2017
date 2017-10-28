using System;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class House : MonoBehaviour
{
    void Start()
    {
        Inputs.Instance.OnLeftMouseDown += OnLeftMouseDown;
    }

    private void OnDestroy()
    {
        try
        {
            Inputs.Instance.OnLeftMouseDown -= OnLeftMouseDown;
        }
        catch(Exception e)
        {

        }

    }

    private void OnLeftMouseDown()
    {
        DoClick();
    }

    private void DoClick()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }


}
