using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Entity _playerEntity;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private MainCamera _mainCamera;

    private void Awake() {
        _playerEntity.Initialize();
        GameObject player = _playerController.Initialize();
        _mainCamera.Initialize(player);
    }

    // This is a crutch and will be removed in the future!!!
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        // I know this is a bad implementation and I will change it
        // In the meantime, let it be so in Alpha
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
