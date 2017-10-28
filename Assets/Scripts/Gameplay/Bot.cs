using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public TextMesh FearLevelText;

    private float _fearLevel;
    public float FearLevel
    {
        get
        {
            return _fearLevel;
        }
        set
        {
            _fearLevel = Mathf.Clamp(value, 0, 100);
            UpdateFearUI();
        }
    }

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
        FearLevel = 0;
    }

    void DoUpdate()
    {
        UpdateFear();
    }

    private void UpdateFear()
    {
        if (FearLevel == 0)
            return;
        var value = FearLevel - Config.Instance.FearLoosePerSecond * Time.deltaTime;
        if (value <= 0)
            value = 0;
        FearLevel = value;
    }

    private void UpdateFearUI()
    {
        FearLevelText.text = ((int)FearLevel).ToString();
    }

}
