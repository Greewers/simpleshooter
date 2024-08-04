using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action<Bullet> DestoyCallback;
    public Rigidbody BulletRigitbody => _bulletRigidbody;
    public float BulletSpeed => _bulletSpeed;

    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private float _bulletSpeed = 2f;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody _bulletRigidbody;

    private float _timer;

    private void OnEnable()
    {
        _timer = _lifeTime;
    }

    public void Init(Action<Bullet> destroyCallback)
    {
        DestoyCallback = destroyCallback;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            DestroyBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target") && collision.gameObject.TryGetComponent<ITakeDamage>(out var takeDamage))
        {
            DestroyBullet();
            takeDamage.TakeDamage(_damage);
        }
    }

    private void DestroyBullet()
    {
        DestoyCallback?.Invoke(this);
    }
}