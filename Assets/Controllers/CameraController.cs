using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const string mouseXAxis = "Mouse X";
    private const string mouseYAxis = "Mouse Y";

    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Camera playerCamera;
    public Camera PlayerCamera => playerCamera;

    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = player.rotation;
    }

    private void LateUpdate()
    {
        CameraRotate(gameObject.transform);
    }

    private void CameraRotate(Transform transform)
    {
        var mouseX = Input.GetAxis(mouseXAxis) * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis(mouseYAxis) * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}