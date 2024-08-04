using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyMover EnemyMover => _enemyMover;
    public EnemyController EnemyController => _enemyController;

    [SerializeField] private EnemyStats _enemyStats;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyController _enemyController;

    private void Awake()
    {
        EnemyMover.Init(_enemyStats.EnemySpeed);
        EnemyController.Init(_enemyStats.EnemyHealthPoint, this);
    }
}
