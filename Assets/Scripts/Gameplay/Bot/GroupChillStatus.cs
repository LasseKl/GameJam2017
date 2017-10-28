using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupChillStatus : BaseStatus
{
    void Activate()
    {
        BotStatus = BotStatus.GroupChill;
    }
}
