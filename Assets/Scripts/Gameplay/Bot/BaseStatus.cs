using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStatus
{
    public Bot Bot;


    public abstract void Activate();
    public virtual void Deactivate()
    {
    }

}
