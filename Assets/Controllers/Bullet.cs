using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public event Action<Bullet> DestoyCallback;
    public Rigidbody BulletRigitbody => bulletRigidbody;

    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private Rigidbody bulletRigidbody;

    private float timer;

    private void OnEnable()
    {
        timer = lifeTime;
    }

    public void Init(Action<Bullet> destroyCallback)
    {
        DestoyCallback = destroyCallback;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f )
            DestroyBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            DestroyBullet();
            Destroy(collision.gameObject);
        }
    }

    private void DestroyBullet()
    {
        DestoyCallback?.Invoke(this);
    }
}