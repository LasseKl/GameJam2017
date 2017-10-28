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

    [HideInInspector]
    public List<Room> Rooms;



}