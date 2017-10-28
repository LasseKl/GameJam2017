using System;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class House : MonoSingleton<House>
{
    void Start()
    {
        //Inputs.Instance.OnLeftMouseDown += OnLeftMouseDown;
    }

    //private void OnDestroy()
    //{
    //    try
    //    {
    //        Inputs.Instance.OnLeftMouseDown -= OnLeftMouseDown;
    //    }
    //    catch(Exception e)
    //    {
    //    }
    //}

    //private void OnLeftMouseDown()
    //{
    //    DoClick();
    //}

    public void DoClick(Item item)
    {
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hitInfo;
        //if (!Physics.Raycast(ray, out hitInfo))
        //    return;
        //if (hitInfo.transform.tag != "Item")
        //    return;
        //var item = hitInfo.transform.GetComponent<Item>();


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
            dist *= 2;
            var relativeDist = 1 - Mathf.Min(dist / maxDist, 1);

            var thrust = 10.0f;
            var rb = bot.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * thrust);
            Print.Log("ADD FORCE");

            bot.SetBotStatus<ChangeRoomStatus>();
            bot.tag = "CrowdLeaver";

            // TODO maybe auslagern später?
            bot.Crowd.Bots.Remove(bot);
            if (bot.Crowd.Bots.Count == 1)
            {
                var otherBot = bot.Crowd.Bots[0];
                otherBot.CurrentRoom.Crowds.Remove(otherBot.Crowd);
                otherBot.Crowd = null;
                bot.Crowd.Bots.Clear();
                otherBot.SetBotStatus<ChangeRoomStatus>();
                otherBot.tag = "CrowdLeaver";
            }

            bot.FearLevel += item.FearValue * relativeDist;

        }

    }


}
