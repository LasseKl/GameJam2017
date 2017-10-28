using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[Serializable]
public class Crowd
{
    public List<Bot> Bots;
    private Vector3? center;

    public Crowd()
    {
        Bots = new List<Bot>();
    }

    public Vector3 GetCenter()
    {
        if (center == null)
        {
            float[] xVals = Bots.Select(bot => bot.transform.position.x).ToArray();
            float[] zVals = Bots.Select(bot => bot.transform.position.z).ToArray();

            float minX = Mathf.Min(xVals);
            float maxX = Mathf.Max(xVals);
            float minZ = Mathf.Min(zVals);
            float maxZ = Mathf.Max(zVals);

            center = new Vector3(minX + (maxX - minX) / 2, 0, minZ + (maxZ - minZ) / 2);
        }

        return center.Value;
    }

}
