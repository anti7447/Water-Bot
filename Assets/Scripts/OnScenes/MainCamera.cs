using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _cameraSpeed = 5;
    public void Initialize(GameObject player) {
        _player = player.GetComponent<Transform>();
    }

    private void FixedUpdate() {
        if (_player) {
            MovingToPlayer();
        }
    }

    private void MovingToPlayer() {
        Vector3 movement = new Vector3(_player.position.x, _player.position.y + 3, -10); 
        transform.position = Vector3.MoveTowards(transform.position, movement, _cameraSpeed);
    }
}
