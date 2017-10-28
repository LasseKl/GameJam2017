using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine.SceneManagement;

public class Config : MonoSingleton<Config>
{
    // Config
    public Vector2i BaseScreenSize;

    public float FearLoosePerSecond = 0.1f;
    public float FearIncreasePerSeondAtRage = 0.2f;
    public float RageAtFearLevel = 60;

    [HideInInspector]
    public List<Room> Rooms;

    public float chillDurationMin = 10;
    public float chillDurationMax = 20;
    public float groupChillDurationMin = 10;
    public float groupChillDurationMax = 30;

    public Vector3 runOutOfHouseTarget;

    public float GetRandomGroupChillDuration()
    {
        return Random.Range(groupChillDurationMin, groupChillDurationMax);
    }

    public float GetRandomChillDuration()
    {
        return Random.Range(chillDurationMin, chillDurationMax);
    }

}