using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    // --------------- Fields -------------- //
    protected Rigidbody2D Rigidbody2;
    protected bool _isGrounded;

    public float Speed = 10f;
    [SerializeField, Range(0, 300)] protected float _jumpForce = 300f;
    public float JumpForce {
        get {
            return _jumpForce;
        }
        set {
            if (value < 0)
                _jumpForce = 0;
            else if (value > 300)
                _jumpForce = 300;
            else
                _jumpForce = value;
        }
    }
    
    // ------------------- Methods -------------------------- //
    public virtual void Initialize() {
        Rigidbody2 = GetComponent<Rigidbody2D>();
    }

    protected void MovementEntity(Vector2 movement) {
        Rigidbody2.AddForce(movement * Speed);
    }

    protected void JumpEntity() {
        Rigidbody2.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision) {
        IsGroundedUpate(collision, true);
    }

    virtual protected void OnCollisionExit2D(Collision2D collision) {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision2D collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
