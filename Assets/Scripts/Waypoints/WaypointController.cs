using System;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public int WaypointCount => _waypoints.Length;

    private Waypoint[] _waypoints;

    public void Awake()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();

        if (_waypoints.Length == 0)
            throw new ArgumentOutOfRangeException("Waypoint pull is empty");

        for (int i = 0; i < _waypoints.Length; i++)
        {
            _waypoints[i].SetNextWaypoint(GetNextWaypoint(i));
            _waypoints[i].SetPreviousWaypoint(GetPreviousWaypoint(i));
        }
    }

    public Waypoint GetStartWaypoint() 
        => _waypoints[0];

    private Waypoint GetNextWaypoint(int currentWaypointIndex) 
        => _waypoints[(currentWaypointIndex + 1) % _waypoints.Length];

    private Waypoint GetPreviousWaypoint(int currentWaypointIndex) 
        => _waypoints[(currentWaypointIndex - 1) % _waypoints.Length];
}