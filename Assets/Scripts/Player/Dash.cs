using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 10f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer;
    private float cooldownTimer = 0f;
    private Vector2 dashDirection;
    
    [SerializeField] Animator animator;
    [SerializeField] private GameObject gun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        animator.SetBool("IsDashing", isDashing);
        
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0 && !isDashing)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
            dashTimer -= Time.fixedDeltaTime;
            if (dashTimer <= 0)
            {
                StopDash();
            }
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTimer = dashTime;
        cooldownTimer = dashCooldown;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        dashDirection = new Vector2(moveX, moveY).normalized;

        if (dashDirection == Vector2.zero)
        {
            dashDirection = transform.right;
        }
    }

    void StopDash()
    {
        isDashing = false;
        rb.velocity = Vector2.zero;
    }
}