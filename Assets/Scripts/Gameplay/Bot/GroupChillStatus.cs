using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class GroupChillStatus : BaseStatus
{
    int timerId;
    public override void Activate()
    {
        timerId = Timer.Instance.Add(Config.Instance.GetRandomGroupChillDuration(), () =>
        {
            Bot.SetBotStatus<ChangeRoomStatus>();
        });
    }
    public override void Deactivate()
    {
        Timer.Instance.Stop(timerId);
    }
}

