using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyMover EnemyMover => _enemyMover;
    public EnemyController EnemyController => _enemyController;
    public Rigidbody EnemyRigidbody => _enemyRigidbody;

    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private Rigidbody _enemyRigidbody;
    public void Awake()
    {
        EnemyMover.Init(_enemyStats.EnemySpeed);
        EnemyController.Init(_enemyStats.EnemyHealthPoint, this);
    }

    public void Init(Action<Enemy> destroyCallback, WaypointController waypointControler)
    {
        EnemyController.OnDestroy += (e) =>
        {
            EnemyController.OnDestroy -= destroyCallback;
            destroyCallback(e);
        };
        EnemyMover.SetWaypointController(waypointControler);
    }
}