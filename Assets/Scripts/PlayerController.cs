using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    //[SerializeField] private float jumpheight=2f;
    [SerializeField] private float jumpheight=0.5f;
    [SerializeField] private float gravity =-9.8f;
    //
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.3f;
    private bool isDashing;
    private float dashTimer;
    //
    private CharacterController controller;
    [SerializeField] private GroundCheck groundCheck;
    private Vector2 moveInput;
    private Vector3 velocity;
    //private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput =context.ReadValue<Vector2>();
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && controller.isGrounded)
        {
        velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        // do it
    }
    public void Charge(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
        isDashing = true;
        dashTimer = dashDuration;
        }
    }
    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            Vector3 dashDirection = new Vector3(moveInput.x, 0, moveInput.y);
            if (dashDirection == Vector3.zero)
            {
            dashDirection = transform.forward;
            }
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            if (dashTimer <= 0)
            {
            isDashing = false;
            }
        return; // отключаем обычное движение
        }
        Vector3 move = new Vector3(moveInput.x,0,moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
        //velocity.y =gravity * Time.deltaTime;
        if (controller.isGrounded && velocity.y < 0)
        {
        velocity.y = -2f; // small downward force to keep grounded
        }
        velocity.y += gravity * Time.deltaTime;
        //
        controller.Move(velocity * Time.deltaTime);
    }
void OnControllerColliderHit(ControllerColliderHit hit)
{
    if (isDashing && hit.gameObject.CompareTag("Breakable"))
    {
    Destroy(hit.gameObject);
    }
}
}
