using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject Active;
    public GameObject Inactive;

    [Range(1, 100)]
    public float FearValue = 50;

    [HideInInspector]
    public Room Room;

    [HideInInspector]
    public bool Allowed = true;

    public float ReactivateTime = 2.0f;

    void Start()
    {
        this.Room = this.transform.parent.GetComponent<Room>();
    }

    //private void OnMouseDown()
    //{
    //    House.Instance.DoClick(this);
    //}

    public void Used()
    {
        Allowed = false;
        SetActive(true);
        Timer.Instance.Add(ReactivateTime, () =>
        {
            SetActive(false);
            Allowed = true;
        });

        // play sound
        MultiSound asrc = GetComponent<MultiSound>();
        if (asrc != null) {
            asrc.playSound();
        }
    }

    private void SetActive(bool status)
    {
        Active.SetActive(status);
        Inactive.SetActive(!status);
    }

}
