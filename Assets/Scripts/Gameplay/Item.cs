using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Range(1, 100)]
    public float FearValue = 50;

    [HideInInspector]
    public Room Room;

    public bool Allowed = true;

    void Start()
    {
        this.Room = this.transform.parent.parent.Find("Trigger").GetComponent<Room>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag != "Ghost")
            return;
        GhostItemCollider.Instance.Item = this;
        //Item = other.GetComponent<Item>();
    }

    private void OnTriggerExit(Collider other)
    {
        GhostItemCollider.Instance.Item = null;
    }

    //private void OnMouseDown()
    //{
    //    House.Instance.DoClick(this);
    //}

}
