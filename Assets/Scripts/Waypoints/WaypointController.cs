using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public int WaypointCount => _waypoints.Length;

    private Waypoint[] _waypoints;

    public Waypoint GetNextWaypoint(int currentWaypointIndex)
    {
        if (_waypoints.Length == 0)
        {
            return null;
        }
        return _waypoints[(currentWaypointIndex + 1) % _waypoints.Length];
    }

    private void Awake()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();
    }
}