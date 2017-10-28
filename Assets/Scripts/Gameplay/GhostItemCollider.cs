using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class GhostItemCollider : MonoSingleton<GhostItemCollider>
{
    [HideInInspector]
    public Item Item;

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        Debug.Log(other.name);
    //        if (other.tag != "Item")
    //            return;
    //        Item = other.GetComponent<Item>();
    //    }

    //    private void OnTriggerExit(Collider other)
    //    {
    //        Item = null;
    //    }

}
