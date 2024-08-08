using System;
using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage
{
    public event Action<Enemy> DestoyCallback;
    public int EnemyCurrentHealth => _enemyCurrentHealth;

    private int _enemyHealthPoint;
    private int _enemyCurrentHealth;
    private Enemy _enemy;

    public void Init(int enemyHealthPoint, Enemy enemy)
    {
        _enemy = enemy;
        _enemyHealthPoint = enemyHealthPoint;
        _enemyCurrentHealth = _enemyHealthPoint;
    }
    
    public void OnKill(Action<Enemy> destroyCallback)
    {
        DestoyCallback = destroyCallback;
    }

    public void TakeDamage(int damage)
    {
        if (_enemyCurrentHealth >= 0)
        {
            _enemyCurrentHealth -= damage;
        }
        else
        {
            DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        DestoyCallback?.Invoke(_enemy);
    }
}