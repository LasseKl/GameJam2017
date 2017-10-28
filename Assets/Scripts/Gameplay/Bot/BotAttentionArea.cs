using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class BotAttentionArea : MonoBehaviour
{
    [HideInInspector]
    public Bot Bot;

    private CapsuleCollider _collider; 

    public void SetRadius(float radius)
    {
        if(_collider == null)
            _collider = GetComponent<CapsuleCollider>();
        _collider.radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var myName = Bot.name;
        if(other.tag != "Bot")
            return;
        var hasCrowd = Bot.Crowd != null;
        if (hasCrowd)
            return;
        // if other.bot is in a crowd
        var otherBot = other.GetComponent<Bot>();
        var otherName = otherBot.name;
        if (otherBot.Crowd == null)
        {
            //Print.Log("Add Crowd " + myName + " / " + otherName);
            // start crowd and join bot
            var crowd = Bot.CurrentRoom.AddCrowd();
            crowd.Bots.Add(Bot);
            crowd.Bots.Add(otherBot);
            Bot.Crowd = crowd;
            otherBot.Crowd = crowd;
            otherBot.SetBotStatus<GroupChillStatus>();
        }
        else
        {
            //Print.Log("Join Crowd " + myName + " / " + otherName);
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
