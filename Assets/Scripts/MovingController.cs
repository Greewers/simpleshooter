using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _playerJumpForce = 5f;
    private Player _player;
    private Rigidbody _playerRigidbody;
    public void Init(Player player, Rigidbody rb)
    {
        _player = player;
        _playerRigidbody = rb;
    }
    public void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 move = _player.transform.right * moveHorizontal + _player.transform.forward * moveVertical;
        Vector3 smoothMovment = _playerRigidbody.position + move * _playerSpeed * Time.deltaTime;
        _playerRigidbody.MovePosition(smoothMovment);
    }
    public void Jump()
    {
        _playerRigidbody.AddForce(Vector3.up * _playerJumpForce, ForceMode.Impulse);
    }
    public void Rotate(float verticalRotate)
    {
        _playerRigidbody.transform.Rotate(0, verticalRotate, 0);
    }
}
