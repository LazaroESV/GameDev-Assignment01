using UnityEngine;
using UnityEngine.InputSystem;


// Ensures the player has a Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    // Having the variables be public makes it so they can be changed directly in the inspector
    public float moveSpeed = 5f;
    public float rotationAmount = 15f;

    private float rotateInput;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        controls.Enable();

        // Read input
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Rotate.performed += _ => rotateInput = 1f;
        controls.Player.Rotate.canceled += _ => rotateInput = 0f;
    }

    private void Update()
    {
        if (rotateInput != 0f)
        {
            transform.Rotate(0f, rotationAmount * Time.deltaTime, 0f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
