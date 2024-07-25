using UnityEngine;

public class Player : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";

    private MovingController _controller;
    private bool _isGrounded;
    
    [SerializeField]private Rigidbody _rigidbody;
    [SerializeField]private GameObject _go;

    private void Start()
    {
        _controller = new MovingController();
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
        _controller.Move(_rigidbody, _go);
    }

    private void PlayerJump()
    {
        _controller.Jump(_rigidbody, _isGrounded);
    }

    private void PlayerRotate()
    {
        _controller.Rotate(_rigidbody);
    }
}