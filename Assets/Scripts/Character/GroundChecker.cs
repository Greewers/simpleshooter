using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded => _isGrounded;
    private const string GROUND_TAG = "Ground";
    private bool _isGrounded;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = false;
        }
    }
}
