using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Entity _entity;

    public void Initialize() {
        
    }

    private void FixedUpdate() {
        MovementPlayer();
        JumpPlayer();
    }

    private void MovementPlayer() {
        float speedRatio = Input.GetAxis("Horizontal");
        _entity.MovementEntity(speedRatio);
    }

    private void JumpPlayer() {
        if (Input.GetAxis("Jump") > 0) {
            if (_entity._isGrounded) {
                _entity.JumpEntity();
            }
        }
    }
}
