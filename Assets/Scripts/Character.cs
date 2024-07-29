using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMover CharacterMover => _characterMover;
    public PlayerController PlayerController => _playerController;
    public MainPlayerCamera MainPlayerCamera => _mainPlayerCamera;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private MainPlayerCamera _mainPlayerCamera;

    private void Awake()
    {
        CharacterMover.Init(_playerStats.PlayerSpeed, _playerStats.PlayerJumpForce);
        PlayerController.Init(_playerInput.Up, _playerInput.Down, _playerInput.Left, _playerInput.Right, _playerInput.Jump);
        MainPlayerCamera.Init(_playerInput.MouseSensitivity);
    }
}