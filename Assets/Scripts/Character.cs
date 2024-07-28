using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMover CharacterMover => _characterMover;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private CharacterMover _characterMover;

    private void Awake()
    {
        CharacterMover.Init(_playerStats.PlayerSpeed, _playerStats.PlayerJumpForce);
    }

}
