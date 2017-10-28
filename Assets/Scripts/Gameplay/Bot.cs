using System;
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
    private float PanicTimeout;
    private BaseStatus CurBotStatus;
    public float BaseSpeed = 2;
    public float FearSpeed = 2;

    public float ActualSpeed
    {
        get
        {
            return BaseSpeed + FearSpeed * FearLevel;
        }
    }

    public float AttentionBaseRadius;

    public float ActualAttenRadius
    {
        get
        {
            return (AttentionBaseRadius - AttentionBaseRadius * FearLevel/100) + 0.5f;
        } 
    }

    //private Dictionary<BotStatus, BaseStatus> _botStatus;

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

            if(TargetRoom == null)
            {
                SetupChillStatus();
            }
        }
    }

    private Room targetRoom;
    public Room TargetRoom
    {
        get
        {
            return targetRoom;
        }
        set
        {
            targetRoom = value;
            SetNewTargetInRoom();
        }
    }

    public NavMeshAgent Agent
    {
        get
        {
            return agent;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Updater.Instance.OnUpdate += DoUpdate;
        FearLevel = 0;
    }

    private void SetupChillStatus()
    {
        TargetRoom = CurrentRoom;
        SetBotStatus<ChillStatus>();
    }

    void DoUpdate()
    {
        UpdateFear();

        if(CurBotStatus != null)
        {
            CurBotStatus.Update();
        }

        //Teste Raum verlassen
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetBotStatus<ChangeRoomStatus>();
        }
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

    public void SetBotStatus<T>() where T : BaseStatus, new()
    {
        if(CurBotStatus != null)
            CurBotStatus.Deactivate();

        var baseStatus = new T();
        baseStatus.Bot = this;
        baseStatus.Activate();
        CurBotStatus = baseStatus;
    }

    public void SetNewTargetInRoom()
    {
        agent.destination = TargetRoom.GetRandomPosInRoom();
    }

}
