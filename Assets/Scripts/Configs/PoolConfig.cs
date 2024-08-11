using UnityEngine;

[CreateAssetMenu(fileName = "PoolConfig", menuName = "Pool Config")]
public class PoolConfig : ScriptableObject
{
    public int PoolSize => _poolSize;
    public GameObject ObjectToInstantiate => _objectToInstantiate;
    public GameObject PoolVault => _poolVault;

    [SerializeField] private int _poolSize;
    [SerializeField] private GameObject _objectToInstantiate;
    [SerializeField] private GameObject _poolVault;
}