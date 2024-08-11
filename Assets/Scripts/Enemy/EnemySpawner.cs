using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly List<Enemy> _enemys = new();

    [SerializeField] private WaypointController _waypointController;
    [SerializeField] private Enemy _enemyToInstantiate;
    [SerializeField] private int _enemyPoolSize = 3;

    public Enemy GetEnemy()
    {
        for (int i = 0; i < _enemys.Count; i++)
        {
            if (_enemys[i].gameObject.activeInHierarchy == false)
            {
                _enemys[i].gameObject.SetActive(true);
                return _enemys[i];
            }
        }
        var enemy = AddEnemyInPool();
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    public void ReturnEnemyInPool(Enemy enemy)
    {
        enemy.EnemyRigidbody.velocity = Vector3.zero;
        enemy.EnemyRigidbody.angularVelocity = Vector3.zero;
        enemy.gameObject.SetActive(false);
        enemy.transform.parent = gameObject.transform;
    }

    private void Start()
    {
        for (int i = 0; i < _enemyPoolSize; i++)
        {
            AddEnemyInPool();
        }
    }

    private Enemy AddEnemyInPool()
    {
        var enemy = Instantiate(_enemyToInstantiate);
        _enemys.Add(enemy);
        enemy.transform.parent = gameObject.transform;
        enemy.gameObject.SetActive(false);
        enemy.Init(ReturnEnemyInPool, _waypointController);
        return enemy;
    }
}