using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private BoxCollider boxCollider;
    public List<Bot> Bots;
    public List<Room> Neighbours;

    //[HideInInspector]
    public List<Crowd> crowds;
    public List<Crowd> Crowds
    {
        get
        {
            return crowds;
        }
        set
        {
            crowds = value;
        }
    }

    public Vector3 Size
    {
        get
        {
            return new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
        }
    }
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }

    public Vector2 TopLeft
    {
        get
        {
            return new Vector2(Position.x - Size.x, Position.z - Size.z);
        }
    }

    public Vector2 BottomRight
    {
        get
        {
            return new Vector2(Position.x + Size.x, Position.z + Size.z);
        }
    }

    public Vector3 RandomPosInRoom
    {
        get
        {
            float randomX = Random.Range(TopLeft.x, BottomRight.x);
            float randomZ = Random.Range(BottomRight.y, TopLeft.y);
            return new Vector3(randomX, 0, randomZ);
        }
    }

    void Start()
    {
        Config.Instance.Rooms.Add(this);
        Crowds = new List<Crowd>();
    }

    public void OnTriggerEnter(Collider other)
    {
        var isCrownLeaver = other.tag == "CrownLeaver";
        if (other.tag == "Bot" || isCrownLeaver)
        {
            var bot = other.GetComponent<Bot>();
            this.Bots.Add(bot);
            bot.CurrentRoom = this;
            if (isCrownLeaver)
            {
                other.tag = "Bot";
            }
        }
        //if (other.tag == "Item")
        //{
            //var item = other.GetComponent<Item>();
            //item.Room = this;
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag != "Bot")
            return;
        this.Bots.Remove(other.GetComponent<Bot>());
    }

    public Crowd AddCrowd()
    {
        var crowd = new Crowd();
        this.Crowds.Add(crowd);
        return crowd;
    }

}
