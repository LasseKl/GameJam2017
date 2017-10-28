using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private BoxCollider boxCollider;
    public List<Bot> Bots;
    const float BORDER = 2.5f;
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
            return new Vector3(transform.localScale.x / 2 - BORDER, transform.localScale.y / 2 - BORDER, transform.localScale.z / 2 - BORDER);
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
    void Awake()
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

    public Vector3 GetRandomPosInRoom()
    {
        float randomX = Random.Range(TopLeft.x, BottomRight.x);
        float randomZ = Random.Range(BottomRight.y, TopLeft.y);
        return new Vector3(randomX, 0, randomZ);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="excluded">Room that should be excluded from the random selection</param>
    /// <returns></returns>
    public static Room GetRandomRoom(Room excluded = null)
    {
        List<Room> rooms = new List<Room>();
        rooms.AddRange(Config.Instance.Rooms);
        if (excluded != null)
            rooms.Remove(excluded);
        return rooms[Random.Range(0, rooms.Count)];
    }

    public Crowd AddCrowd()
    {
        var crowd = new Crowd();
        this.Crowds.Add(crowd);
        return crowd;
    }
}
