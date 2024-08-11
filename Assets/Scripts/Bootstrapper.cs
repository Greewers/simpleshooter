using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PoolConfig _bulletPoolConfig;
    private void Awake()
    {
        new BulletPool(_bulletPoolConfig);
    }
}