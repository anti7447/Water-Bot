using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Entity _entity;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _speedRatio = 0;

    private float move;
    private Rigidbody2D _rb;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public bool isGrounded;
    public float jumpForce = 10f;
    private bool doubleJump;

    public int doubleJumpIsTrue;

    public GameObject Zelie;

    public GameObject Initialize() {
        return gameObject;
    }

    private void Update() {
        MovementPlayer();
        JumpPlayer();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
         if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && doubleJump)
        {
             _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            doubleJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && doubleJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            doubleJump = false;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void MovementPlayer() {
        _speedRatio = Input.GetAxis("Horizontal");
        _animator.SetFloat("Movement", Mathf.Abs(_speedRatio));
        _entity.MovementEntity(_speedRatio);
    }

    private void JumpPlayer() {
        _animator.SetBool("Is Ground", _entity.IsGrounded);
        if (Input.GetKeyDown(KeyCode.Space)
            && (_entity.IsGrounded))
        {
            _entity.JumpEntity();
            doubleJump = false;
        }
    }

    private void OnDestroy() {
        EventManager.OnPlayerDied();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DvoinoiPrishok"))
        {
            doubleJumpIsTrue = 10;
            Zelie.SetActive(false);
        }   
    }

    void OnCollisionExit2D()
    {
        if(doubleJumpIsTrue == 10)
        {
            doubleJump = true;
        }
    }
}
