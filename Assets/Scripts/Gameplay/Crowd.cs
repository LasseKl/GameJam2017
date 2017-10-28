using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class Crowd
{
    public List<Bot> Bots;

    public Crowd()
    {
        Bots = new List<Bot>();
    }

}
