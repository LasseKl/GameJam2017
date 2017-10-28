using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Range(1, 100)]
    public float FearValue = 50;

    [HideInInspector]
    public Room Room;

    [HideInInspector]
    public bool Allowed = true;

    public float ReactivateTime = 10.0f;

    void Start()
    {
        this.Room = this.transform.parent.parent.Find("Trigger").GetComponent<Room>();
    }

    //private void OnMouseDown()
    //{
    //    House.Instance.DoClick(this);
    //}

    public void Used()
    {
        Allowed = false;
        Timer.Instance.Add(ReactivateTime, () =>
        {
            Allowed = true;
        });
    }

}
