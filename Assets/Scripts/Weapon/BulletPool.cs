using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private readonly List<Bullet> _bullets = new();
    private readonly int _bulletPoolSize = 8;
    private readonly GameObject _bulletPoolVault;
    private readonly Bullet _bulletToInstantiate;
    public void Start()
    {
        for (int i = 0; i < _bulletPoolSize; i++)
        {
            AddBulletInPool();
        }
    }

    public BulletPool(PoolConfig poolConfig)
    {
        _bulletPoolVault = poolConfig.PoolVault;
        _bulletPoolSize = poolConfig.PoolSize;
        _bulletToInstantiate = poolConfig.ObjectToInstantiate.GetComponent<Bullet>();

        for (int i = 0; i < _bulletPoolSize; i++)
        {
            AddBulletInPool();
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].gameObject.activeInHierarchy == false)
            {
                _bullets[i].gameObject.SetActive(true);
                Debug.Log(_bullets[i].gameObject.GetInstanceID());
                return _bullets[i];
            }
        }
        var bullet = AddBulletInPool();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBulletInPool(Bullet bullet)
    {
        bullet.BulletRigitbody.velocity = Vector3.zero;
        bullet.BulletRigitbody.angularVelocity = Vector3.zero;
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = _bulletPoolVault.transform;
    }

    private Bullet AddBulletInPool()
    {
        var bullet = Object.Instantiate(_bulletToInstantiate);
        _bullets.Add(bullet);
        bullet.transform.parent = _bulletPoolVault.transform;
        bullet.gameObject.SetActive(false);
        bullet.Init(ReturnBulletInPool);
        return bullet;
    }
}