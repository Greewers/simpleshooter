using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;

    private BulletPool _bulletPool;
    private WeaponStats _weaponStats;
    private float _shootDelay;
    private Camera _playerCamera;
    private float _shootTime;

    public void Init(Camera playerCamera, BulletPool bulletPool, WeaponStats weaponStats)
    {
        _weaponStats = weaponStats;
        _shootDelay = _weaponStats.ShootDelay;
        _playerCamera = playerCamera;
        _bulletPool = bulletPool;
    }
    private void Update()
    {
        if(_shootTime > 0)
            _shootTime -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.LookAt(_playerCamera.transform.position + _playerCamera.transform.forward * int.MaxValue);
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        if (_shootTime <= 0)
        {
            _shootTime = _shootDelay;
            var currentBullet = _bulletPool.GetBullet();
            currentBullet.transform.position = _weaponPoint.position;
            currentBullet.transform.LookAt(_playerCamera.transform.position + _playerCamera.transform.forward * int.MaxValue);
            currentBullet.BulletRigitbody.AddForce(1000 * currentBullet.BulletSpeed * transform.forward);
        }
    }
}