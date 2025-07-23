using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _rawInput;
    [SerializeField] private float moveSpeed = 4.0f;
    
    private Vector2 _minBounds, _maxBounds;
    
    [SerializeField] private float leftPadding = 0.5f;
    [SerializeField] private float rightPadding = 0.5f;
    [SerializeField] private float topPadding = 5.0f;
    [SerializeField] private float bottomPadding = 1.0f;

    void Start()
    {
        InitBounds();
    }
    
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = _rawInput*(moveSpeed*Time.deltaTime);
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x+delta.x, _minBounds.x+leftPadding, _maxBounds.x-rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y+delta.y, _minBounds.y+bottomPadding, _maxBounds.y-topPadding);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }
}
