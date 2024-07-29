using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";

    [SerializeField] private Rigidbody _playerRigidbody;

    private float _playerSpeed;
    private float _playerJumpForce;
    private bool _isGrounded;

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
        if (_isGrounded)
            _playerRigidbody.AddForce(Vector3.up * _playerJumpForce, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            _isGrounded = false;
    }
}