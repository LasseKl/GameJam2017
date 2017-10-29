using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TinyRoar.Framework;
using System.Linq;

public class Light : MonoBehaviour
{
    private List<Ghost> ghostsInArea = new List<Ghost>();
    public GameObject lightOnObj;
    public GameObject lightOffObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            ghostsInArea.Add(other.GetComponent<Ghost>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ghost")
        {
            ghostsInArea.Remove(other.GetComponent<Ghost>());
        }
    }

    private void Update()
    {
        bool containsFp = ghostsInArea.Where(ghost => ghost.PlayerId == 1).Any();
        bool containsSp = ghostsInArea.Where(ghost => ghost.PlayerId == 2).Any();

        if ((containsFp && Input.GetKeyDown(KeyCode.Space)) || (containsSp && Input.GetKeyDown(KeyCode.Return)))
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

        //audio
        MultiSound msnd = GetComponent<MultiSound>();
        if (msnd != null)
            msnd.playSound(0);
    }

    private void SwitchOff()
    {
        lightOnObj.SetActive(false);
        lightOffObj.SetActive(true);
        Timer.Instance.Add(10, SwitchOn);

        //audio
        MultiSound msnd = GetComponent<MultiSound>();
        if (msnd != null)
            msnd.playSound(1);
    }
}
