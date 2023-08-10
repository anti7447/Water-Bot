using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    // --------------- Fields ------------------------- //

    Rigidbody2D _rigidbody2D;
    
    [SerializeField, Range(1, 100)] private float _speed = 5;
    public float Speed {
        get { return _speed; }
        set {
            if (value > 100)
                _speed = 100;
            else if (value < 1)
                _speed = 1;
            else
                _speed = value;
        }
    }

    [SerializeField] private float _damage = 60;

    // ----------------- Methods ------------------------- //

    private void Start() {
        Destroy(gameObject, 2);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        MovementBullet();
    }

    private void MovementBullet() {
        _rigidbody2D.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            Entity entity = other.gameObject.GetComponent<Entity>();
            entity.Damage(_damage);
        }
        Destroy(gameObject);
    }
}
