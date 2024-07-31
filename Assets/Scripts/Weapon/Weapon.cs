using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 2f;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private WeaponStats _weaponStats;

    private float _shootDelay;
    private Camera _playerCamera;
    private float _shootTime;

    public void Init(Camera playerCamera)
    {
        _shootDelay = _weaponStats.ShootDelay;
        _playerCamera = playerCamera;
        Debug.Log("AaA");
    }
    private void Update()
    {
        _shootTime -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.LookAt(_playerCamera.transform.position + _playerCamera.transform.forward * int.MaxValue);
    }

    public void Shoot()
    {
        if (_shootTime <= 0)
        {
            _shootTime = _shootDelay;
            var currentBullet = _bulletPool.GetBullet();
            currentBullet.transform.position = _weaponPoint.position;
            currentBullet.transform.LookAt(_playerCamera.transform.position + _playerCamera.transform.forward * int.MaxValue);
            currentBullet.BulletRigitbody.AddForce(transform.forward * 1000 * _bulletSpeed);
        }
    }
}