using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<Bullet> bullets = new List<Bullet>();

    public Bullet bulletToInstantiate;
    public int poolSize = 8;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            AddBulletInPool();
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (bullets[i].gameObject.activeInHierarchy == false)
            {
                bullets[i].gameObject.SetActive(true);
                return bullets[i];
            }
        }
        var bullet = AddBulletInPool();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private Bullet AddBulletInPool()
    {
        var bullet = Instantiate(bulletToInstantiate);
        bullets.Add(bullet);
        bullet.transform.parent = gameObject.transform;
        bullet.gameObject.SetActive(false);
        bullet.Init(ReturnBulletInPool);
        return bullet;
    }

    public void ReturnBulletInPool(Bullet bullet)
    {
        bullet.BulletRigitbody.velocity = Vector3.zero;
        bullet.BulletRigitbody.angularVelocity = Vector3.zero;
        bullet.gameObject.SetActive(false);
        bullet.transform.parent = gameObject.transform;
    }
}
