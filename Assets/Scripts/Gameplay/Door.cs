using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Linq;

public class Door : MonoBehaviour
{
    private List<Ghost> blockingGhosts = new List<Ghost>();
    private bool closed = false;
    public GameObject openObj;
    public GameObject closedObj;
    private NavMeshObstacle obstacle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ghost")
        {
            blockingGhosts.Add(other.GetComponent<Ghost>());
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
            blockingGhosts.Remove(other.GetComponent<Ghost>());
        }
    }

    private void Update()
    {
        bool containsFp = blockingGhosts.Where(ghost => ghost.PlayerId == 1).Any();
        bool containsSp = blockingGhosts.Where(ghost => ghost.PlayerId == 2).Any();

        if ((containsFp && Input.GetKeyDown(KeyCode.Space))||(containsSp && Input.GetKeyDown(KeyCode.Return)))
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
