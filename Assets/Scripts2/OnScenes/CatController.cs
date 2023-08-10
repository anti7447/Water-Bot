using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Animator _catAnimator;
    [SerializeField] private Entity _catEntity;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet") {
            _catAnimator.SetTrigger("Is Surprised");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Entity entity = other.gameObject.GetComponent<Entity>();
            entity.Damage(_catEntity.DamageForce);
        }
    }
}
