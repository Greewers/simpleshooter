using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMover CharacterMover => _characterMover;
    public PlayerController PlayerController => _playerController;
    public MainPlayerCamera MainPlayerCamera => _mainPlayerCamera;
    public Weapon Weapon => _weapon;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private MainPlayerCamera _mainPlayerCamera;
    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        CharacterMover.Init(_playerStats.PlayerSpeed, _playerStats.PlayerJumpForce);
        PlayerController.Init(_playerInput.Up, _playerInput.Down, _playerInput.Left, _playerInput.Right, _playerInput.Jump, _playerInput.Shoot);
        MainPlayerCamera.Init(_playerInput.MouseSensitivity);
        Weapon.Init(_mainPlayerCamera.PlayerCamera);
    }
}