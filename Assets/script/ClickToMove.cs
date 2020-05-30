using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    bool reTagWaypoints = true;
    List<Vector3> waypoints = new List<Vector3>();
    public int waypointMaxCount = 10; 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (!reTagWaypoints) reTagWaypoints = true;
                if (waypoints.Count >= waypointMaxCount) return;
                waypoints.Add(hit.point);
            }
        }
        if (waypoints.Count > 0)
        {
            Vector3 newDest = waypoints[0];
            if (agent.transform.position.x != newDest.x || agent.transform.position.z != newDest.z)
            {
                agent.destination = newDest;
            }
            else
            {
                waypoints.RemoveAt(0);
            }



        }
    }
}
