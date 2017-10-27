using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform Transform;

    void Start()
    {
        Transform = this.GetComponent<Transform>();
        Config.Instance.Rooms.Add(this);
    }
}
