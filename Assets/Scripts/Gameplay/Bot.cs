using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
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
        Updater.Instance.OnUpdate += DoUpdate;
    }

    void DoUpdate()
    {
        UpdateFear();
    }

    private void UpdateFear()
    {
        if (FearLevel == 0)
            return;
        FearLevel -= Config.Instance.FearLoosePerSecond * Time.deltaTime;
        if (FearLevel <= 0)
            FearLevel = 0;
    }

}
