using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Light : MonoBehaviour
{
    private List<Collider> ghostsInArea = new List<Collider>();
    public GameObject lightOnObj;
    public GameObject lightOffObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            ghostsInArea.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ghost")
        {
            ghostsInArea.Remove(other);
        }
    }

    private void Update()
    {
        if (ghostsInArea.Count != 0
            && Input.GetMouseButtonDown(0))
        {
            SwitchOff();
        }
    }

    private void Start()
    {
        SwitchOn();
    }

    private void SwitchOn()
    {
        lightOnObj.SetActive(true);
        lightOffObj.SetActive(false);
    }

    private void SwitchOff()
    {
        lightOnObj.SetActive(false);
        lightOffObj.SetActive(true);
    }
}
