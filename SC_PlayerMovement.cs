using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = false; 
    public Transform GroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor; 
    float lastTimeGrounded;
    void Start() {
        rb = GetComponent<Rigidbody2D>(); 
    } 
    void Update() 
{ 
    Move(); 
    Jump();
    CheckIfGrounded();
    JumpModifier();
} 
void Move() { 
    float x = Input.GetAxisRaw("Horizontal"); 
    float moveBy = x * speed; 
    rb.velocity = new Vector2(moveBy, rb.velocity.y); 
}
void Jump() { 
    if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
void CheckIfGrounded() { 
    Collider2D colliders = Physics2D.OverlapCircle(GroundedChecker.position, checkGroundRadius, groundLayer); 
    if (colliders != null) { 
        isGrounded = true; 
    } else { 
        if (isGrounded) { 
            lastTimeGrounded = Time.time; 
        } 
        isGrounded = false; 
    } 
}
void JumpModifier() {
    if (rb.velocity.y < 0) {
        rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
        rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }   
}
}
