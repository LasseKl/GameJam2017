using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomStatus : BaseStatus
{
    void Activate()
    {
        BotStatus = BotStatus.ChangeRoom;
    }
}
