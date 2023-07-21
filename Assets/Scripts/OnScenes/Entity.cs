using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    // --------------- Fields -------------- //
    [Header("Objects")]
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public bool IsGrounded { get; private set; }

    [Header("Numeric Fields")]
    [SerializeField] private float _health = 100;
    [SerializeField] private float _damageForce = 10;
    public float DamageForce {
        get { return _damageForce; }
    }

    [SerializeField, Range(-50, 50)] private float _speed = 20f;
    public float Speed {
        get { return _speed; }
        set {
            if (_speed < -50)
                _speed = -50;
            if (_speed > 50)
                _speed = 50;
            else
                _speed = value;
        }
    }
    [SerializeField, Range(0, 100)] private float _jumpForce = 15f;
    public float JumpForce {
        get {
            return _jumpForce;
        }
        set {
            if (value < 0)
                _jumpForce = 0;
            else if (value > 100)
                _jumpForce = 100;
            else
                _jumpForce = value;
        }
    }
    
    // ------------------- Methods -------------------------- //
    public void Initialize() {

    }

    public void MovementEntity(float speedRatio) {
        if (speedRatio < -1)
            speedRatio = -1;
        if (speedRatio > 1)
            speedRatio = 1;
        Vector2 movement = new Vector2(speedRatio * _speed, _rigidbody2D.velocity.y);

        // movement
        _rigidbody2D.velocity = movement;
    }

    public void Damage(float damage) {
        if (damage < 0)
            damage = 0;
        
        _health -= damage;

        if (_health < 0)
            Destroy(gameObject);
    }

    public void JumpEntity() {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        IsGroundedUpate(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collider2D collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            IsGrounded = value;
        }
    }
}
