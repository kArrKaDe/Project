using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;

    public float jumpForce;
    public float maxJumpForce;
    public float minJumpForce;

    public float minSpeed;
    public float maxSpeed;
    public float speed;

    private float _fallVelocity = 0;

    private CharacterController _characterController;

    private Vector3 _moveVector;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime); 
    }

    void Update()
    {
        Jump();

        Movement();

        Sprint();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            Debug.Log("Jump");
            _fallVelocity = -jumpForce;
        }
    }

    void Movement()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
    }

    void Sprint()
    {
        jumpForce = minJumpForce;
        speed = minSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            jumpForce = maxJumpForce;
            speed = maxSpeed;
        }
    }
}
