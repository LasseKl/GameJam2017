using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;

    void Start()
    {
        Inputs.Instance.OnKey += OnKey;
    }

    private void OnKey()
    {
        var direction = GetMovementDirection();
        direction *= Speed;
        direction *= Time.deltaTime;
        transform.Translate(direction);
    }

    private Vector3 GetMovementDirection()
    {
        var direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        return direction;
    }

}
