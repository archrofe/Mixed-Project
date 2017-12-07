﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI; // For artificial intellengce

namespace MOBA
{
    public class PathFollowing : SteeringBehaviour
    {
        public Transform target; // Get to the target
        public float nodeRadius = .1f; // How big each node is fo the agent to seek to
        public float targetRadius = 3f; // Separate from the nodes that the agent follows
        public int currentNode = 0; // Keep trach of the individual nodes
        public bool isAtTarget = false; // Has the agent reached the target node?

        private NavMeshAgent nav; // Reference to the agent component
        private NavMeshPath path; // Stores the calculated path in this variable

        private void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
        }

        Vector3 Seek(Vector3 target)
        {
            Vector3 force = Vector3.zero;

            // Get Distance to target
            Vector3 desiredForce = target - transform.position;
            // Calculate distance <condition> ? <statement a> : <statement v>
            float distance = isAtTarget ? targetRadius : nodeRadius;
            // Is the magnitude greater than distance?
            if (desiredForce.magnitude > distance)
            {
                // Apply weighting to force
                desiredForce = desiredForce.normalized * weighting;
                // Apply desired force to force (removing current owner's velocity)
                force = desiredForce - owner.velocity;
            }

            return force;
        }

        void Update()
        {
            // Is the path calculated?
            if (path != null)
            {
                Vector3[] corners = path.corners;
                if (corners.Length > 0)
                {
                    Vector3 targetPos = corners[corners.Length - 1];

                    // Calculate distance from agent to target
                    float distance = Vector3.Distance(transform.position, targetPos);
                    // If the distance is greater than target radius
                    if (distance >= targetRadius)
                    {
                        for (int i = 0; i < corners.Length - 1; i++)
                        {
                            Vector3 nodeA = corners[i];
                            Vector3 nodeB = corners[i + 1];
                        }
                    }
                }
            }
        }

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;

            // Is there not a target?
            if (!target)
                return force;

            // Calculate path using the nav agent
            if (nav.CalculatePath(target.position, path))
            {
                // Check if the path is finished calulating
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    // Corner are the individual nodes calculated by the nav
                    Vector3[] corners = path.corners;
                    // Is there any corners in the path?
                    if (corners.Length > 0)
                    {
                        int lastIndex = corners.Length - 1;
                        // Is currentNode at the end of the list?
                        if (currentNode >= corners.Length)
                        {
                            // Cap currentNode to end of array (target node)
                            currentNode = lastIndex;
                        }

                        // Get the current corner position
                        Vector3 currentPos = corners[currentNode];
                        // Get distance to current pos
                        float distance = Vector3.Distance(transform.position, currentPos);
                        // Is the distance within the node radius?
                        if (distance <= nodeRadius)
                        {
                            // Move to next node
                            currentNode++;
                        }

                        // Is the agent at the target?
                        float distanceToTarget = Vector3.Distance(transform.position, target.position);
                        isAtTarget = distanceToTarget <= targetRadius;

                        // Seek towards node's position
                        force = Seek(currentPos);
                    }
                }
            }

            return force;
        }
    }
}