using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string MOUSE_X = "Mouse X";

    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _playerJumpForce = 5f;
    //[SerializeField] private Rigidbody _playerRigidbody;
    public void Move(Rigidbody playerRigidbody, GameObject playerGameObject)
    {
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);

        Vector3 move = playerGameObject.transform.right * moveHorizontal + playerGameObject.transform.forward * moveVertical; //вектор перемещения
        Vector3 smoothMovment = playerRigidbody.position + move * _playerSpeed * Time.deltaTime; //вектор плавного перемещения
        playerRigidbody.MovePosition(smoothMovment);
    }
    public void Jump(Rigidbody playerRigidbody, bool isGrounded)
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            playerRigidbody.AddForce(Vector3.up * _playerJumpForce, ForceMode.Impulse);
    }
    public void Rotate(Rigidbody playerRigidbody)
    {
        float verticalRotate = Input.GetAxis(MOUSE_X);
        playerRigidbody.transform.Rotate(0, verticalRotate, 0);
    }
}
