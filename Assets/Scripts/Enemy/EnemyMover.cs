using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private WaypointController _waypointController;
    private float _enemySpeed;
    private Waypoint _currentWaypoint;

    public void Update()
    {
        Move();
    }

    public void Init(float enemySpeed)
    {
        _enemySpeed = enemySpeed;
    }

    public void SetWaypointController(WaypointController waypointController)
    {
        _waypointController = waypointController;
    }

    public void Move()
    {
        if (_currentWaypoint == null)
            _currentWaypoint = _waypointController.GetStartWaypoint();

        Vector3 direction = (_currentWaypoint.transform.position - transform.position).normalized;
        transform.position += _enemySpeed * Time.deltaTime * direction;
        Rotate(direction);

        if (Vector3.Distance(transform.position, _currentWaypoint.transform.position) < _currentWaypoint.WaypointRadius)
            _currentWaypoint = _currentWaypoint.NextWaypoint;
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _enemySpeed * Time.deltaTime);
        }
    }
}
