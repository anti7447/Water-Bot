using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private void FixedUpdate() {
        MovementPlayer();
        JumpPlayer();
    }

    private void MovementPlayer() {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        MovementEntity(movement);
    }

    private void JumpPlayer() {
        if (Input.GetAxis("Jump") > 0) {
            if (_isGrounded) {
                JumpEntity();
            }
        }
    }
}
