using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float MoveSpeed;


    private void FixedUpdate() {
        float moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        MovePosition(moveInputHorizontal * MoveSpeed * Time.fixedDeltaTime);
    }
}
