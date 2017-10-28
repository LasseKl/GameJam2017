using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillStatus : BaseStatus
{
    public override void Activate()
    {
        Bot.SetNewTargetInRoom();
    }

    public override void Update()
    {
        if(Bot.Agent.TargetReached())
        {
            Activate();
        }
    }
}
