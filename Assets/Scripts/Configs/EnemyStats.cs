using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy stats")]
public class EnemyStats : ScriptableObject
{
    public int EnemyHealthPoint => _enemyHealthPoint;
    public float EnemySpeed => _enemySpeed;

    [SerializeField] private string _typeOfEnemy = "Basic enemy";
    [SerializeField] private int _enemyHealthPoint = 10;
    [SerializeField] private float _enemySpeed = 3f;
}
