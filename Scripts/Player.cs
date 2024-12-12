using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    public float playerSpeed = 10f;
    public float playerJump = 15f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator; 
    public AudioClip captureSound;


    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            

        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Saltar
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, playerJump);
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * playerSpeed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingObject"))
        {
            GameManager.instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}

