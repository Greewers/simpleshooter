using UnityEngine;

public class MainPlayerCamera : MonoBehaviour
{
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";
    public Camera PlayerCamera => _playerCamera;

    [SerializeField] private Transform _player;
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Camera _playerCamera;

    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = _player.rotation;
    }

    private void LateUpdate()
    {
        CameraRotate(gameObject.transform);
    }

    private void CameraRotate(Transform transform)
    {
        var mouseX = Input.GetAxis(MOUSE_X) * _mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis(MOUSE_Y) * _mouseSensitivity * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}