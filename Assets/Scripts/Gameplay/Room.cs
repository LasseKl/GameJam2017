using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private BoxCollider boxCollider;

    public Vector3 Size
    {
        get
        {
            return boxCollider.size;
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
            float randomZ = Random.Range(TopLeft.y, BottomRight.y);
            return new Vector3(randomX, 0, randomZ);
        }
    }

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        Config.Instance.Rooms.Add(this);
    }
}
