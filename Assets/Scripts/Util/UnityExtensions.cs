﻿using UnityEngine.AI;

namespace UnityEngine
{
    public static class NavMeshExtensions
    {
        public static bool TargetReached(this NavMeshAgent agent)
        {
            float dist = agent.remainingDistance;
            return dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0;
        }

        public static bool TargetReached(this NavMeshAgent agent, float acceptedDst)
        {
            float dist = agent.remainingDistance;
            return dist != Mathf.Infinity && agent.remainingDistance <= acceptedDst;
        }
    }
}