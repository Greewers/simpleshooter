using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player stats")]
public class PlayerStats : ScriptableObject
{
    public float PlayerSpeed  => _playerSpeed;
    public float PlayerJumpForce => _playerJumpForce;

    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _playerJumpForce = 5f;

}
