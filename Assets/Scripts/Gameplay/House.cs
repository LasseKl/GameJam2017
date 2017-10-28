using System;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class House : MonoBehaviour
{
    void Start()
    {
        Inputs.Instance.OnLeftMouseDown += OnLeftMouseDown;
    }

    private void OnDestroy()
    {
        try
        {
            Inputs.Instance.OnLeftMouseDown -= OnLeftMouseDown;
        }
        catch(Exception e)
        {
        }
    }

    private void OnLeftMouseDown()
    {
        DoClick();
    }

    private void DoClick()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (!Physics.Raycast(ray, out hitInfo))
            return;
        if (hitInfo.transform.tag != "Item")
            return;
        var item = hitInfo.transform.GetComponent<Item>();


        // find room r
        // find all bots b[] in r
        var bots = item.Room.Bots;

        // float maxDist = room.halbeBreite/Höhe = 100%.
        var size = item.Room.Size;
        var maxDist = (size.x + size.z) / 2;

        // find Distance zwischen item und bot und dies * maxDist in prozent.
        // aber d max=100%
        foreach (var bot in bots)
        {
            var dist = Vector3.Distance(bot.transform.position, item.transform.position);
            var relativeDist = 1 - Mathf.Min(dist / maxDist, 1);

            bot.SetBotStatus<ChangeRoomStatus>();
            bot.tag = "GroupLeaver";
            bot.FearLevel += item.FearValue * relativeDist;

        }

    }


}
