using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float WaypointRadius => _waypointRadius;

    public Waypoint NextWaypoint { get; private set; }
    public Waypoint PreviousWaypoint { get; private set; }

    [SerializeField] private float _waypointRadius = 1.0f;

    public void SetNextWaypoint(Waypoint nextWaypoint)
        => NextWaypoint = nextWaypoint;

    public void SetPreviousWaypoint(Waypoint previousWaypoint) 
        => PreviousWaypoint = previousWaypoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, WaypointRadius);
    }
}