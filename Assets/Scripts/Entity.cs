using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    protected Rigidbody2D Rigidbody2;

    public void Initialize() {
        Rigidbody2 = GetComponent<Rigidbody2D>();
    }

    protected void MovePosition(float speed) {
        Vector2 moveVector = new Vector2(speed, 0f);

        Rigidbody2.MovePosition(Rigidbody2.position + moveVector);
    }
}
