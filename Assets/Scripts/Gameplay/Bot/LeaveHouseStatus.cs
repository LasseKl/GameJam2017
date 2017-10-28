using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHouseStatus : BaseStatus
{
    void Activate()
    {
        BotStatus = BotStatus.LeaveHouse;
    }
}
