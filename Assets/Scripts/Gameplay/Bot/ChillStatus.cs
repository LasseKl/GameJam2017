using TinyRoar.Framework;
using UnityEngine;

public class ChillStatus : BaseStatus
{

    int timerId;
    public override void Activate()
    {
        Bot.SetNewTargetInRoom();
        timerId = Timer.Instance.Add(Config.Instance.GetRandomChillDuration(), () => 
        {
            Bot.SetBotStatus<ChangeRoomStatus>();
        });
    }

    public override void Update()
    {
        if(Bot.Agent.TargetReached())
        {
            Activate();
        }
    }

    public override void Deactivate()
    {
        Timer.Instance.Stop(timerId);
    }
}
