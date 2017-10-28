using System;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public TextMesh FearLevelText;
    public BotAttentionArea AttentionArea;

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

    [HideInInspector]
    public Crowd Crowd;

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
            agent.destination = currentRoom.RandomPosInRoom;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CurrentRoom = FindObjectOfType<Room>();
        Updater.Instance.OnUpdate += DoUpdate;
        FearLevel = 0;
        InitStatus();
        AttentionArea.Bot = this;

        //CurBotStatus = BotStatus.Chill;
        SetBotStatus<ChillStatus>();
    }

    private void InitStatus()
    {
        //_botStatus = new Dictionary<BotStatus, BaseStatus>();
        //foreach (BotStatus botStatus in Enum.GetValues(typeof(BotStatus)))
        //{
        //    if (botStatus == BotStatus.None)
        //        continue;
        //    var baseStatus = CodeHelper.CreateInstance<BaseStatus>(botStatus+"Status");
        //    baseStatus.Bot = this;
        //    _botStatus.Add(botStatus, baseStatus);
        //}

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

    public void SetBotStatus<T>() where T : BaseStatus, new()
    {
        if(CurBotStatus != null)
            CurBotStatus.Deactivate();

        var baseStatus = new T();
        baseStatus.Bot = this;
        baseStatus.Activate();
        CurBotStatus = baseStatus;
    }

}
