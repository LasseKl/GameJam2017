using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttentionArea : MonoBehaviour
{
    [HideInInspector]
    public Bot Bot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Bot")
            return;
        var hasCrowd = Bot.Crowd != null;
        if (hasCrowd)
            return;
        // if other.bot is in a crowd
        var otherBot = other.GetComponent<Bot>();
        if(otherBot.Crowd == null)
        {
            // start crowd and join bot
            var crowd = Bot.CurrentRoom.AddCrowd();
            crowd.Bots.Add(Bot);
            crowd.Bots.Add(otherBot);
        }
        else
        {
            // join his crown
            otherBot.Crowd.Bots.Add(Bot);
            Bot.Crowd = otherBot.Crowd;
        }
        Bot.SetBotStatus<GroupChillStatus>();
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
