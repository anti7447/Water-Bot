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
    private bool _faceRight = true;

    public void Initialize() {
        
    }

    private void FixedUpdate() {
        MovementPlayer();
        JumpPlayer();
        FlipPlayer();
    }

    private void MovementPlayer() {
        _speedRatio = Input.GetAxis("Horizontal");
        _animator.SetFloat("Movement", Mathf.Abs(_speedRatio));
        _entity.MovementEntity(_speedRatio);
    }

    private void JumpPlayer() {
        _animator.SetBool("Is Ground", _entity._isGrounded);
        if (Input.GetAxis("Jump") > 0) {
            if (_entity._isGrounded) {
                _entity.JumpEntity();
            }
        }
    }

    private void FlipPlayer() {
        _spriteRenderer.flipX = CheckDirection(_speedRatio);
    }

    private bool CheckDirection(float direction) {
        if (direction > 0.1)
            return false;
        else if (direction < -0.1)
            return true;

        return _spriteRenderer.flipX;
    }
}
