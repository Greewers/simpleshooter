using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemyRigidbody;
    [SerializeField] private List<Transform> _enemyWaypoints;

    private float _enemySpeed;
    private int _currentWaypoint = 0;

    public void Init(float enemySpeed)
    {
        _enemySpeed = enemySpeed;
    }

    public void Move()
    {
        if (_enemyWaypoints.Count == 0)
            return;

        Transform targetWaypoint = _enemyWaypoints[_currentWaypoint];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _enemySpeed * Time.deltaTime);
        Rotate(direction);
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _currentWaypoint++;
            if (_currentWaypoint >= _enemyWaypoints.Count)
            {
                _currentWaypoint = 0;
            }
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
