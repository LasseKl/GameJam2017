﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    void Start()
    {
        Config.Instance.Rooms.Add(this);
    }
}
