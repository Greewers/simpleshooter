using UnityEngine;

public class MainPlayerCamera : MonoBehaviour
{
    private const string MOUSE_X = "Mouse X";
    private const string MOUSE_Y = "Mouse Y";
    public Camera PlayerCamera => _playerCamera;

    [SerializeField] private Transform _player;
    [SerializeField] private Camera _playerCamera;

    private Vector2 _turn;
    private float _mouseSensitivity;

    public void Init(float mouseSensitivity)
    {
        _mouseSensitivity = mouseSensitivity;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CameraRotate(gameObject.transform);
    }

    private void CameraRotate(Transform transformPlayer)
    {
        _turn.x += Input.GetAxis(MOUSE_X) * _mouseSensitivity;
        _turn.y += Input.GetAxis(MOUSE_Y) * _mouseSensitivity;
        _turn.y = Mathf.Clamp(_turn.y, -90, 90);
        _player.localRotation = Quaternion.Euler(0, _turn.x, 0);
        transformPlayer.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
    }
}