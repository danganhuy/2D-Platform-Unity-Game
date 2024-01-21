using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; 
    private int current;

    [SerializeField] private float speed = 2f;
    
    private void Update()
    {
        if (waypoints.Length != 0)
        {
            if (Vector2.Distance(waypoints[current].transform.position, transform.position) < .1f)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
}
