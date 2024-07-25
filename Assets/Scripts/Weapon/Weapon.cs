using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2f;
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private BulletPool bulletPool;

    private float shootTime;

    private void Update()
    {
        Shoot();
    }

    private void LateUpdate()
    {
        transform.LookAt(playerCamera.transform.position + playerCamera.transform.forward * int.MaxValue);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && shootTime <= 0)
        {
            shootTime = shootDelay;
            var currentBullet = bulletPool.GetBullet();
            currentBullet.transform.position = weaponPoint.position;
            currentBullet.transform.LookAt(playerCamera.transform.position + playerCamera.transform.forward * int.MaxValue);
            currentBullet.BulletRigitbody.AddForce(transform.forward * 1000 * bulletSpeed);
        }
        shootTime -= Time.deltaTime;
    }
}