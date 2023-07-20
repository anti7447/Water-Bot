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
    // private bool _faceRight = true;


    public GameObject Initialize() {
        return gameObject;
    }

    private void FixedUpdate() {
        MovementPlayer();
        JumpPlayer();
        // CheckFace();
        // ChangeFlip();
    }

    private void MovementPlayer() {
        _speedRatio = Input.GetAxis("Horizontal");
        _animator.SetFloat("Movement", Mathf.Abs(_speedRatio));
        _entity.MovementEntity(_speedRatio);
    }

    private void JumpPlayer() {
        _animator.SetBool("Is Ground", _entity.IsGrounded);
        if (Input.GetAxis("Jump") > 0) {
            if (_entity.IsGrounded) {
                _entity.JumpEntity();
            }
        }
    }

    private void OnDestroy() {
        EventManager.OnPlayerDied();
    }
}
