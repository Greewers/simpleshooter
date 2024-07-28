using UnityEngine;

public class Player : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string MOUSE_X = "Mouse X";
    private bool _isGrounded;
    [SerializeField]private MovingController _controller;
    [SerializeField]private Rigidbody _playerRigidbody;
    [SerializeField]private Player _player;

    private void Start()
    {
        _controller.Init(_player, _playerRigidbody);
    }
    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
        PlayerJump(); 
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
    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);
        _controller.Move(moveHorizontal, moveVertical);
    }
    private void PlayerJump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            _controller.Jump();
    }
    private void PlayerRotate()
    {
        float verticalRotate = Input.GetAxis(MOUSE_X);
        _controller.Rotate(verticalRotate);
    }
}