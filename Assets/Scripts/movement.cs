using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;
    public Rigidbody2D _playerRb;

    public void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        walk();
    }

    public void walk()
    {
        if (Input.GetKey(KeyCode.D)) {
            _playerRb.velocity = new Vector2(MoveSpeed, _playerRb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A)){
            _playerRb.velocity = new Vector2(-MoveSpeed, _playerRb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W)) {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpSpeed);
        }
        if (Input.GetKey(KeyCode.S)) {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, -JumpSpeed);
        }
    }
}
