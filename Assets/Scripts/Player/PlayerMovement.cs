using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    
    [SerializeField] float moveInput;
    
    [SerializeField] Camera mainCamera;
    [SerializeField] Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("velocityY", rb.velocity.y);
        animator.SetBool("IsGrounded", isGrounded);
        
        if (!isGrounded && rb.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
    
        
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        if (mousePos.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("IsJumping");
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
