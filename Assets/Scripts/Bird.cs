using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public static Bird Instance {  get; private set; }

    public event EventHandler OnGameOver;

    private Rigidbody2D RigidBody2D;
    [SerializeField] private float upVelocityBird = 10f;
    private float rotationSpeed = 5f;

    private void Awake()
    {
        Instance = this;
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            float VeloctyX = 0f;
            RigidBody2D.linearVelocity = new Vector2(VeloctyX, upVelocityBird);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,rotationSpeed * RigidBody2D.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Pipes") || collision2D.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
