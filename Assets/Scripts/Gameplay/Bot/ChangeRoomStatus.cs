using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomStatus : BaseStatus
{
    public override void Activate()
    {
        Bot.TargetRoom = Room.GetRandomRoom(Bot.CurrentRoom);
    }

    public override void Update()
    {
        if (Bot.Agent.TargetReached())
        {
            Bot.SetBotStatus<ChillStatus>();
            Bot.tag = "Bot";
        }
    }
}
