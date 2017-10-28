using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillStatus : BaseStatus
{
    void Activate()
    {
        BotStatus = BotStatus.Chill;
    }
}
