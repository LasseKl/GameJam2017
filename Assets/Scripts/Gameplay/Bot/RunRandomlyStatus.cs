using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class RunRandomlyStatus : BaseStatus
{
    int timerId;

    public override void Activate()
    {
        Bot.TargetRoom = Room.GetRandomRoom(Bot.CurrentRoom);

        timerId = Timer.Instance.Add(10, () =>
        {
            Bot.SetBotStatus<ChangeRoomStatus>();
        });

        Bot.Agent.speed = Bot.FearSpeed;
    }

    public override void Update()
    {
        if (Bot.Agent.TargetReached())
        {
            Bot.TargetRoom = Room.GetRandomRoom(Bot.CurrentRoom);
        }
        Bot.FearLevel += Config.Instance.FearIncreasePerSeondAtRage * Time.deltaTime;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Timer.Instance.Stop(timerId);
        Bot.Agent.speed = Bot.BaseSpeed;
    }
}
