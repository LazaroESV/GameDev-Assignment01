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
    private Animator anim;

    [SerializeField]
    private SaveSystem saveSystem;

    private Vector2 moveInput;
    private bool jumpInput;

    // Having the variables be public makes it so they can be changed directly in the inspector
    public float moveSpeed = 5f;
    public float jumpForce = 8f;


    private bool isGrounded;


    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();

        controls.Enable();

        // Read input
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += _ => jumpInput = true;
    }

    private void Update()
    {
        // Animator parameters
        anim.SetFloat("Speed", Mathf.Abs(moveInput.x));
        anim.SetBool("IsJumping", !isGrounded);

        // Flip Purly horizontally
        if (moveInput.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveInput.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (jumpInput && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpInput = false;
        }

    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Death scenario
        if (collision.gameObject.CompareTag("Snowball"))
        {
            saveSystem.QuitGameWithoutSaving();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
