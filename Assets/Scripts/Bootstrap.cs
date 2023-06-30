using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Entity _playerEntity;
    [SerializeField] private PlayerController _playerController;

    private void Awake() {
        _playerEntity.Initialize();
        _playerController.Initialize();
    }
}
