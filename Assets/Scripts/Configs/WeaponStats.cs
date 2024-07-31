using UnityEngine;

[CreateAssetMenu(fileName = "Weaponstats", menuName = "Weapon stats")]
public class WeaponStats : ScriptableObject
{
    public float ShootDelay => _shootDelay;
    public float ShootingRange => _shootingRange;

    [SerializeField] private int _weaponId = 0;
    [SerializeField] private float _shootingRange = 100f;
    [SerializeField] private float _shootDelay = 1f;
    [SerializeField] private Bullet _tipeOfAmmo = null;
}
