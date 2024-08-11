using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterMover CharacterMover => _characterMover;
    public PlayerController PlayerController => _playerController;
    public MainPlayerCamera MainPlayerCamera => _mainPlayerCamera;
    public Weapon Weapon => _weapon;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private WeaponStats _weaponStats;
    [SerializeField] private CharacterMover _characterMover;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private MainPlayerCamera _mainPlayerCamera;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private BulletPool _bulletPool;

    private void Awake()
    {
        CharacterMover.Init(_playerStats.PlayerSpeed, _playerStats.PlayerJumpForce);
        PlayerController.Init(_playerInput, this);
        MainPlayerCamera.Init(_playerInput.MouseSensitivity);
        Weapon.Init(_mainPlayerCamera.PlayerCamera, _bulletPool, _weaponStats);
    }
}