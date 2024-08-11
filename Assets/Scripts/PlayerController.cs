using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Character _character;
    private float _moveHorizontal;
    private float _moveVertical;
    private PlayerInput _playerInput;

    public void Init(PlayerInput playerInput, Character character)
    {
        _playerInput = playerInput;
        _character = character;
    }

    private void FixedUpdate()
    {
        _moveHorizontal = 0;
        _moveVertical = 0;
        PlayerMove();
        PlayerJump();
        PlayerShoot();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(_playerInput.Up))
            _moveVertical = 1;
        if (Input.GetKey(_playerInput.Down))
            _moveVertical = -1;
        if (Input.GetKey(_playerInput.Left))
            _moveHorizontal = -1;
        if (Input.GetKey(_playerInput.Right))
            _moveHorizontal = 1;
        _character.CharacterMover.Move(_moveHorizontal, _moveVertical);
    }

    private void PlayerJump()
    {
        if (Input.GetKey(_playerInput.Jump))
            _character.CharacterMover.Jump();
    }

    private void PlayerShoot()
    {
        if (Input.GetKey(_playerInput.Shoot))
            _character.Weapon.Shoot();
    }
}