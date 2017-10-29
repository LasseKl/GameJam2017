using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class GhostItemCollider : MonoBehaviour
{
    [HideInInspector]
    public Item Item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Item = other.GetComponent<Item>();
        }
        else if(other.tag == "Bot" || other.tag == "CrowdLeaver")
        {
            var bot = other.GetComponent<Bot>();
            bot.AnimatePushBotAway(this.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item = null;
    }

}
