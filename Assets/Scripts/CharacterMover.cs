using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private GroundChecker _bottom;

    private float _playerSpeed;
    private float _playerJumpForce;

    public void Init(float playerSpeed, float playerJumpForce)
    {
        _playerSpeed = playerSpeed;
        _playerJumpForce = playerJumpForce;
    }

    public void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        Vector3 smoothMovment = _playerRigidbody.position + move * _playerSpeed * Time.deltaTime;
        _playerRigidbody.MovePosition(smoothMovment);
    }

    public void Jump()
    {
        if (_bottom.IsGrounded)
            _playerRigidbody.AddForce(Vector3.up * _playerJumpForce, ForceMode.Impulse);
    }
}