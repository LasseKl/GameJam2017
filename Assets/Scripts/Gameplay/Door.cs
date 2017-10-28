using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    private List<Collider> blockingGhosts = new List<Collider>();
    private bool closed = false;
    public GameObject openObj;
    public GameObject closedObj;
    private NavMeshObstacle obstacle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            blockingGhosts.Add(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (closed && blockingGhosts.Count == 0 && other.GetComponent<Bot>() != null)
        {
            closed = false;
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ghost")
        {
            blockingGhosts.Remove(other);
        }
    }

    private void Update()
    {
        if(blockingGhosts.Count != 0
            && Input.GetMouseButtonDown(0))
        {
            closed = true;
            CloseDoor();
        }
    }

    private void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
        OpenDoor();
    }

    private void OpenDoor()
    {
        openObj.SetActive(true);
        closedObj.SetActive(false);
        obstacle.enabled = false;
    }

    private void CloseDoor()
    {
        openObj.SetActive(false);
        closedObj.SetActive(true);
        obstacle.enabled = true;
    }
}
