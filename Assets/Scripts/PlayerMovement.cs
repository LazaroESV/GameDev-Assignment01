using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


// Ensures the player has a Rigidbody2D
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;

    [SerializeField]
    private SaveSystem saveSystem;

    private Vector2 moveInput;
    private float rotateInput;

    // Having the variables be public makes it so they can be changed directly in the inspector
    public float moveSpeed = 5f;
    public float rotationAmount = 200f; 


    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        controls.Enable();

        // Read input
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Rotate.performed += _ => rotateInput = _.ReadValue<float>();
        controls.Player.Rotate.canceled += _ => rotateInput = 0f;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        if (rotateInput != 0f)
        {
            rb.MoveRotation(rb.rotation + rotateInput * rotationAmount * Time.fixedDeltaTime);
        }

    }

    // Death scenario
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            saveSystem.QuitGameWithoutSaving();
        }
    }
}
