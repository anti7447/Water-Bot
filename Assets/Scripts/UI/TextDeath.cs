using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDeath : MonoBehaviour
{
    private TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
        EventManager.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied() {
        _text.enabled = true;
    }
}
