using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float WaypointRadius => _waypointRadius;

    [SerializeField] private float _waypointRadius = 1.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, WaypointRadius);
    }
}
