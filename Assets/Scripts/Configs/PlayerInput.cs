using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "Player input")]
public class PlayerInput : ScriptableObject
{
    public KeyCode Down => _down;
    public KeyCode Left => _left;
    public KeyCode Right => _right;
    public KeyCode Jump => _jump;
    public KeyCode Up => _up;
    public KeyCode Shoot => _shoot;
    public float MouseSensitivity => _mouseSensitivity;

    [SerializeField] private KeyCode _up = KeyCode.W;
    [SerializeField] private KeyCode _down = KeyCode.S;
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;
    [SerializeField] private float _mouseSensitivity = 0.5f;
}