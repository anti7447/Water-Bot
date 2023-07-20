using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        EventManager.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied() {

    }
}
