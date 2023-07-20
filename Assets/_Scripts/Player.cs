using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _rightSpeed = 3f;      
    [SerializeField] private float _upwardForce = 5f;     
    [SerializeField] private float _gravity = 1.5f;

    private int _score = 0;
    private Rigidbody2D _rb;

    public event Action<int> ScoreChanged;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_rightSpeed, _rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _rb.AddForce(new Vector2(0f, _upwardForce), ForceMode2D.Force);
        }

        _rb.AddForce(new Vector2(0f, -_gravity), ForceMode2D.Force);
    }

    public void BonusCollected()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

}
