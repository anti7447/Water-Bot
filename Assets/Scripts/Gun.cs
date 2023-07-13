using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private SpriteRenderer _gunSprite;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _placeForBullet;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootBullet();
    }

    private void FixedUpdate() {
        FollowMouse();

        if (transform.rotation.z > 0.7 || transform.rotation.z < -0.7)
            FlipGun(true);
        else
            FlipGun(false);
    }

    private void ShootBullet() {
        Instantiate(_bullet, _placeForBullet.position, _placeForBullet.rotation);
    }

    private void FollowMouse() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    private void FlipGun(bool flip) {
        _gunSprite.flipY = flip;
        _playerSprite.flipX = flip;
    }
}
