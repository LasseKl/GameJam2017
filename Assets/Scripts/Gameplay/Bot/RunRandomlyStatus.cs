using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class RunRandomlyStatus : BaseStatus
{
    public override void Activate()
    {
        Bot.TargetRoom = Room.GetRandomRoom(Bot.CurrentRoom);
    }

    public override void Update()
    {
        if (Bot.Agent.TargetReached())
        {
            Bot.TargetRoom = Room.GetRandomRoom(Bot.CurrentRoom);
        }
    }
}
