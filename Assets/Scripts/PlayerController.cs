using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string MOUSE_X = "Mouse X";

    [SerializeField] private Character _character;

    private float _moveHorizontal;
    private float _moveVertical;
    private KeyCode _up;
    private KeyCode _down;
    private KeyCode _left;
    private KeyCode _right;
    private KeyCode _jump;

    public void Init(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode jump)
    {
        _up = up;
        _down = down;
        _left = left;
        _right = right;
        _jump = jump;
    }

    private void FixedUpdate()
    {
        _moveHorizontal = 0;
        _moveVertical = 0;
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(_up))
            _moveVertical = 1;
        if (Input.GetKey(_down))
            _moveVertical = -1;
        if (Input.GetKey(_left))
            _moveHorizontal = -1;
        if (Input.GetKey(_right))
            _moveHorizontal = 1;
        _character.CharacterMover.Move(_moveHorizontal, _moveVertical);
    }

    private void PlayerJump()
    {
        if (Input.GetKey(_jump))
            _character.CharacterMover.Jump();
    }
}