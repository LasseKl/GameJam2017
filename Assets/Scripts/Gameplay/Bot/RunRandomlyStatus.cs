using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRandomlyStatus : BaseStatus
{
    void Activate()
    {
        BotStatus = BotStatus.RunRandomly;
    }
}
