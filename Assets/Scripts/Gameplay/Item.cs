using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Range(1, 100)]
    public float FearValue = 50;

    [HideInInspector]
    public Room Room;

    void Start()
    {
        this.Room = this.transform.parent.parent.Find("Trigger").GetComponent<Room>();
    }

}
