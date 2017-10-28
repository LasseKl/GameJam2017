using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{

    [HideInInspector]
    public float FearLevel;


    private Room currentRoom;
    private NavMeshAgent agent;

    [HideInInspector]
    public Room CurrentRoom
    {
        get
        {
            return currentRoom;
        }
        set
        {
            currentRoom = value;
            agent.destination = currentRoom.RandomPosInRoom;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CurrentRoom = FindObjectOfType<Room>();
    }
}
