using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;
    public GhostItemCollider GhostItemCollider;

    void Start()
    {
        Inputs.Instance.OnKey += OnKey;
        Inputs.Instance.OnKeyDown += OnKeyDown;
    }

    private void OnKey()
    {
        // Movement
        var direction = GetMovementDirection();
        direction *= Speed;
        direction *= Time.deltaTime;
        //Rigidbody.velocity = direction * 100;
        transform.Translate(direction);
    }

    private void OnKeyDown()
    {
        ItemActivation();
    }

    private void ItemActivation()
    {
        // Space -> activate Items
        if (!Input.GetKey(KeyCode.Space))
            return;
        // get nearest item
        var item = GhostItemCollider.Item;
        if (item == null)
            return;
        item.Used();
        House.Instance.DoClick(item);
    }

    private Vector3 GetMovementDirection()
    {
        var direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        return direction;
    }

}
