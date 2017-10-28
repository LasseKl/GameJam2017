using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHouseStatus : BaseStatus
{
    public override void Activate()
    {
        Bot.Agent.destination = Config.Instance.runOutOfHouseTarget;
    }
}
