using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;
    public GhostItemCollider GhostItemCollider;
    public int PlayerId;

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
        //var status = true;
        // Space -> activate Items
        if (PlayerId == 1 && !Input.GetKey(KeyCode.Space))
            return;
        if (PlayerId == 2 && !Input.GetKey(KeyCode.Return))
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
        direction.x = Input.GetAxis("Horizontal" + PlayerId);
        direction.z = Input.GetAxis("Vertical" + PlayerId);
        return direction;
    }

}
