using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string MOUSE_X = "Mouse X";

    [SerializeField] private Character _character;

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);
        _character.CharacterMover.Move(moveHorizontal, moveVertical);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _character.CharacterMover.Jump();
    }

    private void PlayerRotate()
    {
        float verticalRotate = Input.GetAxis(MOUSE_X);
        _character.CharacterMover.Rotate(verticalRotate);
    }
}