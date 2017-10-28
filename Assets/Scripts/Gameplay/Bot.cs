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
            UpdateAttentionArea();
            CheckRage();
        }
    }

    private Room currentRoom;
    private NavMeshAgent agent;
    private BaseStatus CurBotStatus;
    public float BaseSpeed = 3.5f;
    public float FearSpeed = 6f;

    public void ActivateTimeout()
    {

    }

    private Crowd crowd;

    public Crowd Crowd
    {
        get
        {
            return crowd;
        }
        set
        {
            crowd = value;
        }
    }

    public float ActualSpeed
    {
        get
        {
            return BaseSpeed + FearSpeed * FearLevel;
        }
    }

    public float AttentionBaseRadius;

    public float ActualAttentionRadius
    {
        get
        {
            return (AttentionBaseRadius - AttentionBaseRadius * FearLevel / 100) + 0.5f;
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

            if (TargetRoom == null)
            {
                SetupChillStatus();
                AttentionArea.gameObject.SetActive(true);
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
        AttentionArea.Bot = this;

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

        if (CurBotStatus != null)
        {
            CurBotStatus.Update();
        }

        //Teste Raum verlassen
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetBotStatus<RunRandomlyStatus>();
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
        if (CurBotStatus != null)
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

    private void UpdateAttentionArea()
    {
        var radius = ActualAttentionRadius;
        AttentionArea.SetRadius(radius);
    }

    private void CheckRage()
    {
        if(FearLevel >= Config.Instance.RageAtFearLevel)
        {
            SetBotStatus<RunRandomlyStatus>();
        }
    }

    private bool isPushingAway = false;
    private Vector3 _direction;
    private Rigidbody rigidbody;

    public void DoPush(Vector3 direction)
    {
        rigidbody = GetComponent<Rigidbody>();
        Updater.Instance.OnUpdate += PushUpdate;
        _direction = direction;
        if (isPushingAway)
            return;
        Timer.Instance.Add(0.2f, () =>
        {
            isPushingAway = false;
            Updater.Instance.OnUpdate -= PushUpdate;
        });
    }

    private void PushUpdate()
    {
        var thrust = 20f;
        rigidbody.AddForce(_direction * thrust);
    }
}
