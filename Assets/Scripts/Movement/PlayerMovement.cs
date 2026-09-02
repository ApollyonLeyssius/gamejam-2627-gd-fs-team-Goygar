using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float Speed = 5f;
    [SerializeField]private float JumpingHeight = 8f;
    private float horizontal;

    [SerializeField]private LayerMask GroundLayer;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Rigidbody2D rb;


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * Speed, rb.linearVelocity.y);
    }
    public void PlayerMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpingHeight);
        }
    }
    private bool IsGrounded() 
    {
        return Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(1f, 0.05f), CapsuleDirection2D.Horizontal, 0, GroundLayer) != null;
    }
}
