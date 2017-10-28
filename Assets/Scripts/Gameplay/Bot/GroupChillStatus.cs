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
            if (Bot.Crowd != null)
            {
                Bot.SetBotStatus<ChangeRoomStatus>();
                Bot.tag = "CrowdLeaver";

                Bot.Crowd.Bots.Remove(Bot);

                if (Bot.Crowd.Bots.Count == 1)
                {
                    var otherBot = Bot.Crowd.Bots[0];
                    otherBot.CurrentRoom.Crowds.Remove(otherBot.Crowd);
                    otherBot.Crowd = null;
                    Bot.Crowd.Bots.Clear();
                    otherBot.SetBotStatus<ChangeRoomStatus>();
                    otherBot.tag = "CrowdLeaver";
                }

                Bot.Crowd = null;
            }
        });

        Bot.Agent.destination = Bot.Crowd.GetCenter();
    }
    public override void Deactivate()
    {
        Timer.Instance.Stop(timerId);
    }
}

