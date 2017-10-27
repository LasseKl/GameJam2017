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
        //this.transform.position += direction;
        //Rigidbody.MovePosition(Vector3.forward * Time.deltaTime);
        //var moveDirection = transform.TransformDirection(direction);
        ////set the velocity, so you can move
        //var velocity = new Vector3(moveDirection.x, 0, moveDirection.z);)
        //Rigidbody.velocity = velocity;
        //GetComponent<Rigidbody>().AddForce(Vector3.up * -10);

        transform.Translate(direction);
    }

    private Vector3 GetMovementDirection()
    {
        var direction = new Vector3();
        //if (Input.GetKey(KeyCode.A))
        //    direction.x--;
        //if (Input.GetKey(KeyCode.D))
        //    direction.x++;
        //if (Input.GetKey(KeyCode.W))
        //    direction.z++;
        //if (Input.GetKey(KeyCode.S))
        //    direction.z--;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        return direction;
    }

}
