using UnityEngine;

public class Player : MonoBehaviour
{
    private const string horizontalAxis = "Horizontal";
    private const string verticalAxis = "Vertical";
    private const string groundTag = "Ground";

    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerJumpForce = 5f;
    [SerializeField] private Rigidbody playerRigidbody;

    private bool isGrounded;

    private void Update()
    {
        PlayerMove();
        PlayerRotate();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical; //вектор перемещения
        Vector3 smoothMovment = playerRigidbody.position + move * playerSpeed * Time.deltaTime; //вектор плавного перемещения
        playerRigidbody.MovePosition(smoothMovment);
    }

    private void PlayerJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
            playerRigidbody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
    }

    private void PlayerRotate()
    {
        float verticalRotate = Input.GetAxis("Mouse X");
        transform.Rotate(0, verticalRotate, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag(groundTag))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
            isGrounded = false;
    }
}
