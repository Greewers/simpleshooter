using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private WaypointController _waypointController;

    private float _enemySpeed;
    private int _currentWaypointIndex = 0;

    public void Init(float enemySpeed)
    {
        _enemySpeed = enemySpeed;
    }

    public void Move()
    {
        Waypoint nextWaypoint = _waypointController.GetNextWaypoint(_currentWaypointIndex);

        if (nextWaypoint == null)
        {
            Debug.Log("Waypoint not found");
            return;
        }

        Vector3 direction = (nextWaypoint.transform.position - transform.position).normalized;
        transform.position += _enemySpeed * Time.deltaTime * direction;
        Rotate(direction);
        if (Vector3.Distance(transform.position, nextWaypoint.transform.position) < nextWaypoint.WaypointRadius)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypointController.WaypointCount; //TODO переделать
        }
    }

    private void Update()
    {
        Move();
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
